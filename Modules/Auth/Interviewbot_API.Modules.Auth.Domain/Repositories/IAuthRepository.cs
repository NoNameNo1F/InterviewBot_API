using Interviewbot_API.Modules.Auth.Domain.Entities;

namespace Interviewbot_API.Modules.Auth.Domain.Repositories;

public interface IAuthRepository
{
    Task<Otp> GenerateOtpAsync(User user, int type);
    Task<bool> ValidateOtpAsync(Guid userId, string otpCode);
    
}