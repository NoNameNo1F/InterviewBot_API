using AdsManagement.Modules.Auth.Domain.Repositories;
using Interviewbot_API.Modules.Auth.Domain.Entities;
using Interviewbot_API.Modules.Chat.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Interviewbot_API.Modules.Chat.Infrastructure.Domain.Repositories;

public class TokenRepository : ITokenRepository
{
    private readonly AuthContext _authContext;

    public TokenRepository(AuthContext authContext)
    {
        _authContext = authContext;
    }
    
    public async Task<RefreshToken> GetRefreshTokenByUserIdAsync(Guid userId)
    {
        return await _authContext.Tokens.FirstOrDefaultAsync(o => o.UserId == userId);
    }

    public async Task<bool> IsRefreshTokenExistsByUserIdAsync(Guid userId)
    {
        return await _authContext.Tokens.AnyAsync(o => o.UserId == userId);
    }

    public async Task AddRefreshTokenAsync(RefreshToken refreshToken)
    {
        await _authContext.Tokens.AddAsync(refreshToken);
    }

    public Task RemoveRefreshTokenAsync(RefreshToken refreshToken)
    {
        _authContext.Tokens.Remove(refreshToken);
        return Task.CompletedTask;
    }
}