using Interviewbot_API.Modules.Auth.Domain.Entities;

namespace AdsManagement.Modules.Auth.Domain.Repositories;

public interface ITokenRepository
{
    Task<RefreshToken> GetRefreshTokenByUserIdAsync(Guid userId);
    Task<bool> IsRefreshTokenExistsByUserIdAsync(Guid userId);
    
    Task AddRefreshTokenAsync(RefreshToken refreshToken);
    Task RemoveRefreshTokenAsync(RefreshToken refreshToken);
}