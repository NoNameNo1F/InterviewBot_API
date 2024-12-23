using MediatR;

namespace Interviewbot_API.Modules.Auth.Application.Contracts;


public interface ICommand<out TResult> : IRequest<TResult>
{
}
public interface ICommand : IRequest
{
}