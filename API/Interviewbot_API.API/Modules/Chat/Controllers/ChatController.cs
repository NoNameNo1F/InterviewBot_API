using System.Net;
using Asp.Versioning;
using Interviewbot_API.API.Common;
using Interviewbot_API.Modules.Chat.Application.Contracts;
using Interviewbot_API.Modules.Chat.Infrastructure.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Interviewbot_API.API.Modules.Chat.Controllers;

[ApiVersion(ApiVersions.Version1)]
[ApiController]
[Route("api/v{version:apiVersion}/chat")]
public class ChatController : ControllerBase
{
    private readonly IChatModule _chatModule;

    private readonly IHttpContextAccessor _httpContextAccessor;

    public ChatController(IChatModule chatModule, IHttpContextAccessor httpContextAccessor)
    {
        _chatModule = chatModule;
        _httpContextAccessor = httpContextAccessor;
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> LoadAllThread()
    {
        return Ok(new ApiResponse
        {
            StatusCode = HttpStatusCode.OK,
            // Result = listThreads
        }); 
    }
    // create thread [post]
    // rename thread [post]
    // delete thread [delete]

    // check-openai-key post

    // ask [post message]


    // get threads [get]

    // get thread id [get]

    // process/documentation [post file]

    // ('/api/chat-stream', methods=['GET'])
    // ('/api/chat-stream', methods=['POST'])
}