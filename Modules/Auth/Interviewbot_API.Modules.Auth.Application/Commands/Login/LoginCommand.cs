using Interviewbot_API.Modules.Auth.Application.Contracts;

namespace Interviewbot_API.Modules.Auth.Application.Commands;

public class LoginCommand : CommandBase<LoginResponse>
{
    public LoginCommand(string email, string password)
    {
        Email = email;
        Password = password;
    }
    
    public string Email { get; }
    public string Password { get; }
}