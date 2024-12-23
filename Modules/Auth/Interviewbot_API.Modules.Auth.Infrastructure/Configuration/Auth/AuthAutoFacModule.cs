using Autofac;
using Interviewbot_API.Modules.Auth.Application.Contracts;

namespace Interviewbot_API.Modules.Auth.Infrastructure.Configuration.Configuration.Auth;

public class AuthAutoFacModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<AuthModule>()
            .As<IAuthModule>()
            .InstancePerLifetimeScope();
    }
}