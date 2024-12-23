using Interviewbot_API.Modules.Auth.Application.Contracts;

namespace Interviewbot_API.Modules.Auth.Application.Commands.Logout;

public class LogoutCommand : CommandBase
{
    public Guid UserId { get; }
    public string Token { get; }

    public LogoutCommand(Guid userId, string token)
    {
        UserId = userId;
        Token = token;
    }
}