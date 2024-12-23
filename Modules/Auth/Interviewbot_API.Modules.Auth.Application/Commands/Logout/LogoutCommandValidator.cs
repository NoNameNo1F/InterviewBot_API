using AdsManagement.Modules.Auth.Domain.Repositories;
using FluentValidation;
using Interviewbot_API.Modules.Auth.Application.Tokens;
using Interviewbot_API.Modules.Auth.Domain.Repositories;

namespace Interviewbot_API.Modules.Auth.Application.Commands.Logout;

public class LogoutCommandValidator : AbstractValidator<LogoutCommand>
{
    public LogoutCommandValidator(
        ITokenRepository tokenRepository,
        IUserRepository userRepository,
        ITokenService tokenService)
    {
        RuleFor(x => x.UserId)
            .NotNull()
            .WithMessage("Missing UserId")
            .MustAsync(async (userId, token) =>
            {
                var user = userRepository.GetUserByIdAsync(userId);

                return (user is null);
            })
            .WithMessage("User is not exists");

        RuleFor(x => x.Token)
            .NotNull()
            .WithMessage("Token cannot be empty")
            .MustAsync(async (request, token, cancellationToken) =>
            {
                if (!tokenService.DecodableToken(token))
                {
                    return false;
                }

                return !tokenService.DecodableToken(token) || tokenService.DecodeToken(token) != request.UserId;
            })
            .WithMessage("Token is not valid or UserId is not exists");
    }
}