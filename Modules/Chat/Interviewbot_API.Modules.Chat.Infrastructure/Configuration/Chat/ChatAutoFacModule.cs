using Autofac;
using Interviewbot_API.Modules.Chat.Application.Contracts;

namespace Interviewbot_API.Modules.Chat.Infrastructure.Configuration.Chat;

public class ChatAutoFacModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<ChatModule>()
            .As<IChatModule>()
            .InstancePerLifetimeScope();
    }
}