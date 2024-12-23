using MediatR;

namespace Interviewbot_API.Modules.Auth.Application.Contracts;

public interface IQuery<out TResult> : IRequest<TResult>
{
}