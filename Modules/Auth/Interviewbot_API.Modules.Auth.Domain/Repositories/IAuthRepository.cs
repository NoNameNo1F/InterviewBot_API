using Interviewbot_API.Modules.Auth.Domain.Entities;

namespace Interviewbot_API.Modules.Auth.Domain.Repositories;

public interface IAuthRepository
{
    Task GenerateOtpAsync(User user, int otpType);
    Task<bool> ValidateOtpAsync(Guid userId, int otpType, string otpCode);
    Task<Otp> GetOtpByUserId(Guid userId, int otpType);
    Task RemoveOtpAsync(Otp otp);
}