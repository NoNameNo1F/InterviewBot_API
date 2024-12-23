using Interviewbot_API.Modules.Auth.Application.Configuration.Commands;
using Interviewbot_API.Modules.Auth.Application.Cryptos;
using Interviewbot_API.Modules.Auth.Domain.Entities;
using Interviewbot_API.Modules.Auth.Domain.Repositories;
using Microsoft.Identity.Client;

namespace Interviewbot_API.Modules.Auth.Application.Commands.CreateUser;

public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly ICryptoService _cryptoService;

    public CreateUserCommandHandler(IUserRepository userRepository, ICryptoService cryptoService)
    {
        _userRepository = userRepository;
        _cryptoService = cryptoService;
    }

    public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        await _userRepository.CreateUserAsync(new User
        {
            Id = Guid.NewGuid(),
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            DoB = request.DoB,
            Password = _cryptoService.HashPasswordWithSha256(request.Password),
            PhoneNumber = "00000000000"
        });
    }
}