using Interviewbot_API.Modules.Auth.Application.Contracts;
using Interviewbot_API.Modules.Auth.Domain.Entities;

namespace Interviewbot_API.Modules.Auth.Application.Commands.CreateUser;

public class CreateUserCommand : CommandBase
{
    public string Email { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public DateTime DoB { get; }
    public string Password { get; }
    public string RePassword { get; }

    public CreateUserCommand(
        string email,
        string firstName,
        string lastName,
        DateTime doB,
        string password,
        string rePassword
    )
    {
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        DoB = doB;
        Password = password;
        RePassword = rePassword;
    }
}