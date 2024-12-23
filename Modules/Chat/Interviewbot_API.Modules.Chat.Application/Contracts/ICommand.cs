using MediatR;

namespace Interviewbot_API.Modules.Chat.Application.Contracts;


public interface ICommand<out TResult> : IRequest<TResult>
{
}
public interface ICommand : IRequest
{
}