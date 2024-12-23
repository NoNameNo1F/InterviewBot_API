using Autofac;
using Interviewbot_API.Modules.Chat.Application.Caching;
using Interviewbot_API.Modules.Chat.Infrastructure.Caching;

namespace Interviewbot_API.Modules.Chat.Infrastructure.Configuration.Caching;

internal class CachingModule : Module
{
    private readonly string _connectionString;

    public CachingModule(string connectionString)
    {
        _connectionString = connectionString;
    }

    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<CachingDatabase>()
            .As<ICachingDatabase>()
            .WithParameter("connectionString", _connectionString)
            .SingleInstance();

        builder.RegisterType<CachingService>()
            .As<ICachingService>()
            .InstancePerLifetimeScope();
    }
}