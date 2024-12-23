using Interviewbot_API.Modules.Auth.Domain.Entities;
using Interviewbot_API.Modules.Auth.Domain.Repositories;
using Interviewbot_API.Modules.Chat.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Interviewbot_API.Modules.Chat.Infrastructure.Domain.Repositories;

public class AuthRepository : IAuthRepository
{
    private readonly AuthContext _authContext;

    public AuthRepository(AuthContext authContext)
    {
        _authContext = authContext;
    }
    
    public async Task<Otp> GenerateOtpAsync(User user, int type)
    {
        var otp = new Otp
        {
            OtpId = new Guid(),
            UserId = user.Id,
            Code = new Random().Next(100000, 999999).ToString(),
            ExpireAt = DateTime.UtcNow.AddMinutes(5),
            OtpType = type
        };

        await _authContext.Otps.AddAsync(otp);
        return otp;
    }

    public async Task<bool> ValidateOtpAsync(Guid userId, string otpCode)
    {
        var otp = await _authContext.Otps.FirstOrDefaultAsync(o => o.UserId == userId && o.Code == otpCode);

        if (otp != null && otp.ExpireAt >= DateTime.UtcNow)
        {
            _authContext.Remove(otp);
            return true;
        }
        else if (otp.ExpireAt < DateTime.UtcNow)
        {
            _authContext.Remove(otp);
            return false;
        }
        else
        {
            return false;
        }
    }
}