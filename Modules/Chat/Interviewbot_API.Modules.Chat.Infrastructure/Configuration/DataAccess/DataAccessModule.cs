using System.Reflection;
using Autofac;
using Interviewbot_API.Modules.Chat.Infrastructure.Database;
using Microsoft.Extensions.Logging;
using Module = Autofac.Module;

namespace Interviewbot_API.Modules.Chat.Infrastructure.Configuration.DataAccess;

internal class DataAccessModule : Module
{
    private readonly DatabaseConfiguration _configuration;
    private readonly ILoggerFactory _loggerFactory;

    internal DataAccessModule(DatabaseConfiguration configuration, ILoggerFactory loggerFactory)
    {
        _configuration = configuration;
        _loggerFactory = loggerFactory;
    }

    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<ChatModule>()
            .WithParameter("configuration", _configuration)
            .AsSelf()
            .InstancePerLifetimeScope();

        var infrastructureAssembly = typeof(ChatContext).Assembly;
        
        builder.RegisterAssemblyTypes(infrastructureAssembly)
            .Where(type => type.Name.EndsWith("Repository"))
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope()
            .FindConstructorsWith(new AllConstructorFinder());
    }
}