using Interviewbot_API.Modules.Auth.Application.Contracts;
using MediatR;

namespace Interviewbot_API.Modules.Auth.Application.Configuration.Queries;

public interface IQueryHandler<in TQuery, TResult> : IRequestHandler<TQuery, TResult>
    where TQuery : IQuery<TResult>
{
}