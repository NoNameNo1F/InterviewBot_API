using MediatR;

namespace Interviewbot_API.Modules.Chat.Application.Contracts;

public interface IQuery<out TResult> : IRequest<TResult>
{
}