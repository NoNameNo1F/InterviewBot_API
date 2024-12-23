using AdsManagement.Modules.Auth.Domain.Repositories;
using Interviewbot_API.Modules.Auth.Application.Configuration.Commands;

namespace Interviewbot_API.Modules.Auth.Application.Commands.Logout;

public class LogoutCommandHandler : ICommandHandler<LogoutCommand>
{
    private readonly ITokenRepository _tokenRepository;

    public LogoutCommandHandler(ITokenRepository tokenRepository)
    {
        _tokenRepository = tokenRepository;
    }
    
    public async Task Handle(LogoutCommand request, CancellationToken cancellationToken)
    {
        var token = await _tokenRepository.GetRefreshTokenByUserIdAsync(request.UserId);
        await _tokenRepository.RemoveRefreshTokenAsync(token);
    }
}