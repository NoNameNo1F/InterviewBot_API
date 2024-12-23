using Autofac;
using Interviewbot_API.Modules.Auth.Infrastructure.Configuration.Crypto;
using Interviewbot_API.Modules.Auth.Infrastructure.Configuration.DataAccess;
using Interviewbot_API.Modules.Auth.Infrastructure.Configuration.Logging;
using Interviewbot_API.Modules.Auth.Infrastructure.Configuration.Mediator;
using Interviewbot_API.Modules.Auth.Infrastructure.Configuration.Processing;
using Interviewbot_API.Modules.Auth.Infrastructure.Configuration.Token;

using Serilog;

namespace Interviewbot_API.Modules.Auth.Infrastructure.Configuration;

public class Startup
{
    private static IContainer _container;

    public static void Initialize(
        string connectionString,
        TokensConfiguration tokensConfiguration,
        CryptosConfiguration cryptosConfiguration,
        // EmailsConfiguration emailsConfiguration,
        ILogger logger
    )
    {
        var moduleLogger = logger.ForContext("Module", "Auth");
        ConfigureCompositionRoot(
            connectionString,
            tokensConfiguration,
            cryptosConfiguration,
            moduleLogger
        );
    }

    private static void ConfigureCompositionRoot(
        string connectionString,
        TokensConfiguration tokensConfiguration,
        CryptosConfiguration cryptosConfiguration,
        // EmailsConfiguration emailsConfiguration,
        ILogger logger)
    {
        var containerBuilder = new ContainerBuilder();

        var loggerFactory = new Serilog.Extensions.Logging.SerilogLoggerFactory(logger);

        containerBuilder.RegisterModule(new LoggingModule(logger));
        containerBuilder.RegisterModule(new DataAccessModule(connectionString, loggerFactory));
        containerBuilder.RegisterModule(new ProcessingModule());
        containerBuilder.RegisterModule(new MediatorModule());
        containerBuilder.RegisterModule(new TokenModule(tokensConfiguration));
        containerBuilder.RegisterModule(new CryptoModule(cryptosConfiguration));
        // containerBuilder.RegisterModule(new EmailModule(emailsConfiguration));
        
        _container = containerBuilder.Build();
        
        CompositionRoot.SetContainer(_container);
    }
}