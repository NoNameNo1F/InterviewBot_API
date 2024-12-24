using Interviewbot_API.Modules.Auth.Application.Contracts;

namespace Interviewbot_API.Modules.Auth.Application.Commands;

public class ForgotPasswordCommand : CommandBase
{
    public ForgotPasswordCommand(string email, int otpType)
    {
        Email = email;
        OtpType = otpType;
    }
    public string Email { get; }
    public int OtpType { get; }
}