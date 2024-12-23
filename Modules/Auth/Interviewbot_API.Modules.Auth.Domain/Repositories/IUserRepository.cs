using  Interviewbot_API.Modules.Auth.Domain.Entities;

namespace Interviewbot_API.Modules.Auth.Domain.Repositories;

public interface IUserRepository
{
    Task<bool> IsUserExistsByEmailAsync(string email);
    Task<bool> IsUserExistsByIdAsync(Guid userId);
    Task<User> GetUserByEmailAsync(string email);
    Task<User> GetUserByIdAsync(Guid userId);
    Task CreateUserAsync(User user);
    Task UpdateUserAsync(User user);
    Task DeleteUserAsync(User user);
}