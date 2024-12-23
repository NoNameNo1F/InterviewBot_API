using Autofac;
using Interviewbot_API.Modules.Auth.Application.Contracts;
using Interviewbot_API.Modules.Auth.Infrastructure.Configuration.Processing;
using MediatR;

namespace Interviewbot_API.Modules.Auth.Infrastructure.Configuration;

public class AuthModule : IAuthModule
{
    public async Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command)
    {
        return await CommandsExecutor.Execute(command);
    }

    public async Task ExecuteCommandAsync(ICommand command)
    {
        await CommandsExecutor.Execute(command);
    }

    public async Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query)
    {
        using (var scope = CompositionRoot.BeginLifetimeScope())
        {
            var mediator = scope.Resolve<IMediator>();

            return await mediator.Send(query);
        }
    }
}