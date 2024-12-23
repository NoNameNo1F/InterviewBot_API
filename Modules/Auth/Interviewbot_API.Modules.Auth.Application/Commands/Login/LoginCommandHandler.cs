using AdsManagement.Modules.Auth.Domain.Repositories;
using Interviewbot_API.BuildingBlocks.Application.Constrains.Constains;
using Interviewbot_API.BuildingBlocks.Application.Constrains.Enums;
using Interviewbot_API.Modules.Auth.Application.Configuration.Commands;
using Interviewbot_API.Modules.Auth.Application.Tokens;
using Interviewbot_API.Modules.Auth.Domain.Entities;
using Interviewbot_API.Modules.Auth.Domain.Repositories;

namespace Interviewbot_API.Modules.Auth.Application.Commands;

internal class LoginCommandHandler : ICommandHandler<LoginCommand, LoginResponse>
{
    private readonly ITokenService _tokenService;
    private readonly ITokenRepository _tokenRepository;
    private readonly IUserRepository _userRepository;

    public LoginCommandHandler(ITokenService tokenService, ITokenRepository tokenRepository, IUserRepository userRepository)
    {
        _tokenService = tokenService;
        _tokenRepository = tokenRepository;
        _userRepository = userRepository;
    }

    public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByEmailAsync(request.Email);
        var access = _tokenService.CreateAccessToken(user, TokenTypeNames.Access);

        if (await _tokenRepository.IsRefreshTokenExistsByUserIdAsync(user.Id))
        {
            var previousRefresh = await _tokenRepository.GetRefreshTokenByUserIdAsync(user.Id);
            if (previousRefresh.ExpireAt < DateTime.UtcNow)
            {
                DateTime createdAt = DateTime.UtcNow;
                var tokenId = Guid.NewGuid();
                var refresh = _tokenService.CreateRefreshToken(user, tokenId, createdAt, TokenTypeNames.Refresh);
                
                await _tokenRepository.AddRefreshTokenAsync(new RefreshToken
                {
                    TokenId = tokenId,
                    Secret = refresh,
                    IsUsed = false,
                    ExpireAt = createdAt.AddMinutes((int)TokenLifeTimeDurations.RefreshLifeTimeDuration),
                    UserId = user.Id
                });
                return new LoginResponse(access, refresh);
            }
            
            return new LoginResponse(access, previousRefresh.Secret);
        }
        else
        {
            DateTime createdAt = DateTime.UtcNow;
            var tokenId = Guid.NewGuid();
            var refresh = _tokenService.CreateRefreshToken(user, tokenId, createdAt, TokenTypeNames.Refresh);
            
            await _tokenRepository.AddRefreshTokenAsync(new RefreshToken
            {
                TokenId = tokenId,
                Secret = refresh,
                IsUsed = false,
                ExpireAt = createdAt.AddMinutes((int)TokenLifeTimeDurations.RefreshLifeTimeDuration),
                UserId = user.Id
            });
            return new LoginResponse(access, refresh);
        }
    }
}