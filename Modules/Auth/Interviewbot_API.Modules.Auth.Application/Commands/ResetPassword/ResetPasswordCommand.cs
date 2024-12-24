using Interviewbot_API.Modules.Auth.Application.Contracts;

namespace Interviewbot_API.Modules.Auth.Application.Commands;

public class ResetPasswordCommand : CommandBase
{
    public ResetPasswordCommand(string email, string newPassword, string reNewPassword)
    {
        Email = email;
        NewPassword = newPassword;
        ReNewPassword = reNewPassword;
    }
    public string Email { get; }
    public string NewPassword { get; }
    public string ReNewPassword { get; }
}