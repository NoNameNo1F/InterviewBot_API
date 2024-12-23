using System.Data;
using FluentValidation;
using Interviewbot_API.Modules.Auth.Domain.Repositories;

namespace Interviewbot_API.Modules.Auth.Application.Commands.CreateUser;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator(IUserRepository userRepository)
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email can't be empty")
            .EmailAddress()
            .WithMessage("Email is not valid")
            .MustAsync(async (request, email, cancellationToken) =>
            {
                return !await userRepository.IsUserExistsByEmailAsync(email);
            })
            .WithMessage("Email already exists!");

        RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage("Firstname cannot be null");
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage("Lastname cannot be null");

        RuleFor(x => x.DoB)
            .LessThan(DateTime.UtcNow)
            .WithMessage("Date of birth must be in the past");
        
        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password cannot be empty")
            .MinimumLength(8)
            .WithMessage("Password must be at least 8 characters long")
            .Matches(@"[A-Z]")
            .WithMessage("Password must contain at least one uppercase letter")
            .Matches(@"[a-z]")
            .WithMessage("Password must contain at least one lowercase letter")
            .Matches(@"\d")
            .WithMessage("Password must contain at least one digit")
            .Matches(@"[\W_]")
            .WithMessage("Password must contain at least one special character");
        
        RuleFor(x => x.RePassword)
            .Equal(x => x.Password)
            .WithMessage("Passwords do not match");
    }
}