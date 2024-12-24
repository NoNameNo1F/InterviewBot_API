using System.Net;
using Asp.Versioning;
using Interviewbot_API.API.Common;
using Interviewbot_API.API.Modules.Auth.Dtos;
using Interviewbot_API.Modules.Auth.Application.Commands;
using Interviewbot_API.Modules.Auth.Application.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Interviewbot_API.API.Modules.Auth.Controllers;

[ApiVersion(ApiVersions.Version1)]
[ApiController]
[Route("api/v{version:apiVersion}/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthModule _authModule;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthController(
        IAuthModule authModule,
        IHttpContextAccessor httpContextAccessor)
    {
        _authModule = authModule;
        _httpContextAccessor = httpContextAccessor;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
    {
        var token = await _authModule.ExecuteCommandAsync(new LoginCommand(request.Email, request.Password));
        
        return Ok(new ApiResponse
        {
            StatusCode = HttpStatusCode.OK,
            Result = token
        });
    }
    [Authorize]
    [HttpPost("logout")]
    public async Task<IActionResult> Logout([FromBody] LogoutRequestDto request)
    {
        string accessToken = _httpContextAccessor.HttpContext.Request.Headers["Authorization"]!;
        await _authModule.ExecuteCommandAsync(new LogoutCommand(request.UserId, accessToken));
        
        return Ok(new ApiResponse
        {
            StatusCode = HttpStatusCode.OK,
            Result = "Logged out successfully"
        });
    }
    
    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterUserRequestDto request)
    {
        await _authModule.ExecuteCommandAsync(new CreateUserCommand(
            request.Email,
            request.FirstName,
            request.LastName,
            request.DoB,
            request.Password,
            request.RePassword));
        return Ok(new ApiResponse { StatusCode = HttpStatusCode.Created, Result = "Created User Successfully" });
    }
    
    [AllowAnonymous]
    [HttpPost("reset-password")]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequestDto request)
    {
        await _authModule.ExecuteCommandAsync(new ResetPasswordCommand(request.Email, request.NewPassword, request.ReNewPassword));
        return Ok(new ApiResponse
        {
            StatusCode = HttpStatusCode.OK,
            Result = "Password reset successfully! Please log in to continue!!!"
        });
    }

    [AllowAnonymous]
    [HttpPost("forgot-password")]
    public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequestDto request)
    {
        await _authModule.ExecuteCommandAsync(new ForgotPasswordCommand(request.Email, request.OtpType));
        
        return Ok(new ApiResponse
        {
            StatusCode = HttpStatusCode.OK,
            Result = "Otp was sent"
        });
    }
    
    [Authorize]
    [HttpPost("change-password")]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequestDto request)
    {
        await _authModule.ExecuteCommandAsync(
            new ChangePasswordCommand(
                request.Email,
                request.OldPassword,
                request.NewPassword, 
                request.ReNewPassword
            ));
        
        return Ok(new ApiResponse
        {
            StatusCode = HttpStatusCode.OK,
            Result = "Password changed successfully! Please log in to continue!!!"
        });
    }
}