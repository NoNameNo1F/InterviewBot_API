using Interviewbot_API.Modules.Auth.Domain.Entities;
using Interviewbot_API.Modules.Auth.Domain.Repositories;
using Interviewbot_API.Modules.Chat.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Interviewbot_API.Modules.Chat.Infrastructure.Domain.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AuthContext _authContext;

    public UserRepository(AuthContext authContext)
    {
        _authContext = authContext;
    }
    
    public async Task<bool> IsUserExistsByEmailAsync(string email)
    {
        return await _authContext.Users.AnyAsync(u => u.Email == email);
    }

    public async Task<bool> IsUserExistsByIdAsync(Guid userId)
    {
        return await _authContext.Users.AnyAsync(u => u.Id == userId);
    }

    public async Task<User> GetUserByEmailAsync(string email)
    {
        return await _authContext.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User> GetUserByIdAsync(Guid userId)
    {
        return await _authContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
    }

    public async Task CreateUserAsync(User user)
    {
        await _authContext.Users.AddAsync(user);
        
    }

    public Task UpdateUserAsync(User user)
    {
        _authContext.Users.Update(user);
        return Task.CompletedTask;
    }

    public Task DeleteUserAsync(User user)
    {
        _authContext.Users.Remove(user);
        return Task.CompletedTask;
    }
}