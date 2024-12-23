using Autofac;
using Interviewbot_API.BuildingBlocks.Domain.UnitOfWork;
using Interviewbot_API.BuildingBlocks.Infrastructure.Repositories;

namespace Interviewbot_API.Modules.Chat.Infrastructure.Configuration.Processing;

internal class ProcessingModule : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<UnitOfWork>()
            .As<IUnitOfWork>()
            .InstancePerLifetimeScope();
    }
}