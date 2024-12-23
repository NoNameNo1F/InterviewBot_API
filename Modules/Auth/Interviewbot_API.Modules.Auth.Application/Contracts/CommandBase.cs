namespace Interviewbot_API.Modules.Auth.Application.Contracts;

public abstract class CommandBase : ICommand 
{
}

public abstract class CommandBase<TResult> : ICommand<TResult>
{
}