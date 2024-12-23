namespace Interviewbot_API.Modules.Auth.Application.Cryptos;

public interface ICryptoService
{
    string HashPasswordWithSha256(string password);
}