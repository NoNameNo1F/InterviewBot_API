using FluentValidation;
using Interviewbot_API.Modules.Auth.Application.Cryptos;
using Interviewbot_API.Modules.Auth.Domain.Repositories;

namespace Interviewbot_API.Modules.Auth.Application.Commands;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator(
        IUserRepository userRepository,
        ICryptoService cryptoService)
    {
        RuleFor(x => x.Password)
            .NotEmpty()
            .MustAsync(async (request, password, cancellationToken) =>
            {
                var user = await userRepository.GetUserByEmailAsync(request.Email);

                if (user is null)
                {
                    return false;
                }

                return user.Password == cryptoService.HashPasswordWithSha256(password);
            })
            .WithMessage("Account does not exist or Password is not true");
    }
}