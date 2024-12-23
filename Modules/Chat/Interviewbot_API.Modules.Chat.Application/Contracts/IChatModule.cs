namespace Interviewbot_API.Modules.Chat.Application.Contracts;

public interface IChatModule
{
    Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command);
    Task ExecuteCommandAsync(ICommand command);
    Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query);
}