namespace Interviewbot_API.Modules.Auth.Infrastructure.Configuration.Crypto;

public class CryptosConfiguration
{
    public string Salt { get; }

    public CryptosConfiguration(string salt)
    {
        Salt = salt;
    }
}