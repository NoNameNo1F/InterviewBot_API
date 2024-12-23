using Interviewbot_API.Modules.Chat.Application.Contracts;
using MediatR;

namespace Interviewbot_API.Modules.Chat.Application.Configuration.Queries;

public interface IQueryHandler<in TQuery, TResult> : IRequestHandler<TQuery, TResult>
    where TQuery : IQuery<TResult>
{
}