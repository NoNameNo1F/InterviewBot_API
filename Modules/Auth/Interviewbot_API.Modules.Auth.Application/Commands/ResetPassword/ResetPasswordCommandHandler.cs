using Interviewbot_API.Modules.Auth.Application.Configuration.Commands;
using Interviewbot_API.Modules.Auth.Application.Cryptos;
using Interviewbot_API.Modules.Auth.Domain.Repositories;

namespace Interviewbot_API.Modules.Auth.Application.Commands;

public class ResetPasswordCommandHandler : ICommandHandler<ResetPasswordCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly ICryptoService _cryptoService;

    public ResetPasswordCommandHandler(IUserRepository userRepository, ICryptoService cryptoService)
    {
        _userRepository = userRepository;
        _cryptoService = cryptoService;
    }

    public async Task Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByEmailAsync(request.Email);
        user.Password = _cryptoService.HashPasswordWithSha256(request.NewPassword);

        await _userRepository.UpdateUserAsync(user);
    }
}
