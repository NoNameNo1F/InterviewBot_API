using Interviewbot_API.Modules.Auth.Application.Tokens;


using Autofac;
using Microsoft.Extensions.Configuration;

namespace Interviewbot_API.Modules.Auth.Infrastructure.Configuration.Token;

public class TokenModule : Module
{
    private readonly TokensConfiguration _configuration;
    
    public TokenModule(TokensConfiguration configuration)
    {
        this._configuration = configuration;
    }
    
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<TokenService>()
            .As<ITokenService>()
            .WithParameter("configuration", _configuration)
            .InstancePerLifetimeScope();
    }
}