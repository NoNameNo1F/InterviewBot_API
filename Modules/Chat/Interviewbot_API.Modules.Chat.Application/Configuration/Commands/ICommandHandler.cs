﻿using Interviewbot_API.Modules.Chat.Application.Contracts;
using MediatR;

namespace Interviewbot_API.Modules.Chat.Application.Configuration.Commands;

public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand>
    where TCommand : ICommand
{
    
}

public interface ICommandHandler<in TCommand, TResult> : IRequestHandler<TCommand, TResult>
    where TCommand : ICommand<TResult>
{
    
}