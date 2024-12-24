using FluentValidation;
using Interviewbot_API.Modules.Auth.Domain.Repositories;

namespace Interviewbot_API.Modules.Auth.Application.Commands;

public class ResetPasswordCommandValidator : AbstractValidator<ResetPasswordCommand>
{
    public ResetPasswordCommandValidator(IUserRepository userRepository)
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .MustAsync(async (email, cancellationToken) =>
            {
                return !await userRepository.IsUserExistsByEmailAsync(email);
            })
            .WithMessage("Email is empty or Account is not exists");
        
        RuleFor(x => x.NewPassword)
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
        
        RuleFor(x => x.ReNewPassword)
            .Equal(x => x.NewPassword)
            .WithMessage("Passwords do not match");
    }
}