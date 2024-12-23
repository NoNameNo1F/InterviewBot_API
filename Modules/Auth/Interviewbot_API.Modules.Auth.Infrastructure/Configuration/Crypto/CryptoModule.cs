using Autofac;
using Interviewbot_API.Modules.Auth.Application.Cryptos;

namespace Interviewbot_API.Modules.Auth.Infrastructure.Configuration.Crypto;

public class CryptoModule : Module
{
    private readonly CryptosConfiguration _configuration;

    public CryptoModule(CryptosConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<CryptoService>()
            .As<ICryptoService>()
            .WithParameter("configuration", _configuration)
            .InstancePerLifetimeScope();
    }
}