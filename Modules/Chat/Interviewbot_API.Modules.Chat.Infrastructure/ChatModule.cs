﻿using Autofac;
using Interviewbot_API.Modules.Chat.Application.Contracts;
using Interviewbot_API.Modules.Chat.Infrastructure.Configuration;
using Interviewbot_API.Modules.Chat.Infrastructure.Configuration.Processing;
using MediatR;

namespace Interviewbot_API.Modules.Chat.Infrastructure;

public class ChatModule : IChatModule
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