using Autofac;
using FluentValidation;
using Interviewbot_API.BuildingBlocks.Domain.UnitOfWork;
using Interviewbot_API.BuildingBlocks.Infrastructure.Repositories;
using Interviewbot_API.Modules.Auth.Application.Configuration.Commands;

namespace Interviewbot_API.Modules.Auth.Infrastructure.Configuration.Processing;

internal class ProcessingModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();

            // builder.RegisterGenericDecorator(
            //     typeof(UnitOfWorkCommandHandlerDecorator<>),
            //     typeof(ICommandHandler<>));
            //
            // builder.RegisterGenericDecorator(
            //     typeof(UnitOfWorkCommandHandlerWithResultDecorator<,>),
            //     typeof(ICommandHandler<,>));
            //
            // builder.RegisterGenericDecorator(
            //     typeof(ValidationCommandHandlerDecorator<>),
            //     typeof(ICommandHandler<>));
            //
            // builder.RegisterGenericDecorator(
            //     typeof(ValidationCommandHandlerWithResultDecorator<,>),
            //     typeof(ICommandHandler<,>));
        }
    }