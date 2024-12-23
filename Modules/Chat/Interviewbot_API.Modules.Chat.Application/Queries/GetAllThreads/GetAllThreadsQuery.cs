using Interviewbot_API.Modules.Chat.Application.Contracts;
using Thread = Interviewbot_API.Modules.Chat.Domain.Entities.Thread;

namespace Interviewbot_API.Modules.Chat.Application.Queries.GetAllThreads;

public class GetAllThreadsQuery : QueryBase<List<Thread>>
{
    public Guid UserId { get; }

    public GetAllThreadsQuery(Guid userId)
    {
        UserId = userId;
    }
}