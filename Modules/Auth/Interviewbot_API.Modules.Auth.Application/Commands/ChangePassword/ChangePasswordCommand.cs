using Interviewbot_API.Modules.Auth.Application.Contracts;

namespace Interviewbot_API.Modules.Auth.Application.Commands;

public class ChangePasswordCommand : CommandBase
{
    public ChangePasswordCommand(
        string email,
        string oldPassword,
        string newPassword,
        string reNewPassword
    )
    {
        Email = email;
        OldPassword = oldPassword;
        NewPassword = newPassword;
        ReNewPassword = reNewPassword;
    }
    
    public string Email { get; }
    public string OldPassword { get; }
    public string NewPassword { get; }
    public string ReNewPassword { get; }
}