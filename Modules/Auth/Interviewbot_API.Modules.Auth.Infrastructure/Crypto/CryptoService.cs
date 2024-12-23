using System.Security.Cryptography;
using System.Text;
using Interviewbot_API.Modules.Auth.Application.Cryptos;

namespace Interviewbot_API.Modules.Auth.Infrastructure.Configuration.Crypto;

public class CryptoService : ICryptoService
{
    private readonly CryptosConfiguration _configuration;
    
    public CryptoService(CryptosConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public string HashPasswordWithSha256(string password)
    {
        string saltedPassword = password + _configuration.Salt;
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));
            
            StringBuilder hash = new StringBuilder();
            foreach (byte b in bytes)
            {
                hash.Append(b.ToString("x2"));
            }

            return hash.ToString();
        }
    }
}