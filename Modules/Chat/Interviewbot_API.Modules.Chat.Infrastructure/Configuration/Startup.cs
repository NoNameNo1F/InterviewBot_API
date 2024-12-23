using Autofac;
using Interviewbot_API.Modules.Chat.Infrastructure.Configuration.Caching;
using Interviewbot_API.Modules.Chat.Infrastructure.Configuration.DataAccess;
using Interviewbot_API.Modules.Chat.Infrastructure.Configuration.Logging;
using Interviewbot_API.Modules.Chat.Infrastructure.Configuration.Mediator;
using Interviewbot_API.Modules.Chat.Infrastructure.Configuration.Processing;
using Interviewbot_API.Modules.Chat.Infrastructure.Database;
using Serilog;

namespace Interviewbot_API.Modules.Chat.Infrastructure.Configuration;

public class Startup
{
    private static IContainer _container;

    public static void Initialize(
        DatabaseConfiguration configuration,
        string cacheConnectionString,
        ILogger logger)
    {
        var moduleLogger = logger.ForContext("Module", "Chat");
        ConfigureCompositionRoot(
            configuration,
            cacheConnectionString,
            moduleLogger
        );
    }

    private static void ConfigureCompositionRoot(
        DatabaseConfiguration configuration,
        string cacheConnectionString,
        ILogger logger)
    {
        var containerBuilder = new ContainerBuilder();

        var loggerFactory = new Serilog.Extensions.Logging.SerilogLoggerFactory(logger);

        containerBuilder.RegisterModule(new LoggingModule(logger));
        containerBuilder.RegisterModule(new DataAccessModule(configuration, loggerFactory));
        containerBuilder.RegisterModule(new ProcessingModule());
        containerBuilder.RegisterModule(new MediatorModule());
        containerBuilder.RegisterModule(new CachingModule(cacheConnectionString));

        _container = containerBuilder.Build();
        CompositionRoot.SetContainer(_container);
    }
}