using Interviewbot_API.Modules.Auth.Application.Configuration.Commands;
using Interviewbot_API.Modules.Auth.Domain.Repositories;

namespace Interviewbot_API.Modules.Auth.Application.Commands;

public class ForgotPasswordCommandHandler : ICommandHandler<ForgotPasswordCommand>
{
    private readonly IAuthRepository _authRepository;
    private readonly IUserRepository _userRepository ;

    public ForgotPasswordCommandHandler(
        IAuthRepository authRepository,
        IUserRepository userRepository)
    {
        _authRepository = authRepository;
        _userRepository = userRepository;
    }

    public async Task Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByEmailAsync(request.Email);
        await _authRepository.GenerateOtpAsync(user, request.OtpType);
    }
}