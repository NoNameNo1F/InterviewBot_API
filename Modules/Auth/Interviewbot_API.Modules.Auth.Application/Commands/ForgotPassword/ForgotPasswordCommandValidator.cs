using FluentValidation;
using Interviewbot_API.Modules.Auth.Domain.Repositories;

namespace Interviewbot_API.Modules.Auth.Application.Commands;

public class ForgotPasswordCommandValidator : AbstractValidator<ForgotPasswordCommand>
{
    public ForgotPasswordCommandValidator(
        IUserRepository userRepository)
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .MustAsync(async (email, cancellationToken) =>
            {
                return !await userRepository.IsUserExistsByEmailAsync(email);
            })
            .WithMessage("Email is not valid or Email is not exists");
    }
}