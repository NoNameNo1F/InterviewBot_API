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
[Route("api/v{version:apiVersion}/token")]
public class TokenController : ControllerBase
{
    private readonly IAuthModule _authModule;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public TokenController(IAuthModule authModule, IHttpContextAccessor httpContextAccessor)
    {
        _authModule = authModule;
        _httpContextAccessor = httpContextAccessor;
    }

    [Authorize]
    [HttpPost("refresh")]
    public async Task<IActionResult> RefreshAccessToken([FromBody] RefreshAccessTokenRequestDto request)
    {
        var refreshToken = _httpContextAccessor.HttpContext.Request.Cookies["refresh"];
        var newAccessToken = await _authModule.ExecuteCommandAsync(
            new RefreshAccessTokenCommand(request.UserId, refreshToken)
        );

        return Ok(new ApiResponse
        {
            StatusCode = HttpStatusCode.OK,
            Result = newAccessToken
        });
    }
}