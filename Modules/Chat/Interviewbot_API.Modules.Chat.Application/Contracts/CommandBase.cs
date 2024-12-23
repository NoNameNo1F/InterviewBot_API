namespace Interviewbot_API.Modules.Chat.Application.Contracts;

public abstract class CommandBase : ICommand 
{
}

public abstract class CommandBase<TResult> : ICommand<TResult>
{
}