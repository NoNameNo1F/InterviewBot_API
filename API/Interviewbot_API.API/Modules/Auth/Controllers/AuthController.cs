using System.Net;
using Asp.Versioning;
using Interviewbot_API.API.Common;
using Interviewbot_API.API.Modules.Auth.Dtos;
using Interviewbot_API.Modules.Auth.Application.Commands;
using Interviewbot_API.Modules.Auth.Application.Commands.CreateUser;
using Interviewbot_API.Modules.Auth.Application.Commands.Logout;
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
    public async Task<IActionResult> Logout(LogoutRequestDto request)
    {
        // string refreshToken = _httpContextAccessor.HttpContext.Request.Cookies["refresh"];
        string accessToken = _httpContextAccessor.HttpContext.Request.Headers["Authorization"]!;
        await _authModule.ExecuteCommandAsync(new LogoutCommand(request.UserId, accessToken));
        return Ok(new ApiResponse { StatusCode = HttpStatusCode.OK, Result = "Logged out successfully" });
    }
    
    // Register User Account [POST]
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
    public async Task<IActionResult> ResetPassword(string email)
    {
        // await _authModule.ExecuteCommandAsync(new ResetPasswordCommand(email));
        return Ok(new ApiResponse { StatusCode = HttpStatusCode.OK});
    }
    
    // Forgot 
    
    // [AllowAnonymous]
    // [HttpPost("token/refresh")]
    // public async Task<IActionResult> CreateNewAccessToken()
    // {
    //     string refreshToken = _httpContextAccessor.HttpContext.Request.Cookies["refresh"];
    //     var newAccessToken =
    //         await _authModule.ExecuteCommandAsync(new CreateNewAccessTokenByRefreshTokenCommand(refreshToken));
    //     return Ok(new ApiResponse { StatusCode = HttpStatusCode.OK, Result = newAccessToken });
    // }
}