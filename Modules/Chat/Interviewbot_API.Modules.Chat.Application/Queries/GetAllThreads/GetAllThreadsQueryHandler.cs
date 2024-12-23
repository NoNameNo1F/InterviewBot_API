using Interviewbot_API.Modules.Chat.Application.Caching;
using Interviewbot_API.Modules.Chat.Application.Configuration.Queries;
using Interviewbot_API.Modules.Chat.Application.Constraints.Constants;
using Interviewbot_API.Modules.Chat.Application.Constraints.Enums;
using Interviewbot_API.Modules.Chat.Application.Contracts;
using Interviewbot_API.Modules.Chat.Domain.Repositories;
using Interviewbot_API.Modules.Chat.Domain.Entities;
using Thread = Interviewbot_API.Modules.Chat.Domain.Entities.Thread;

namespace Interviewbot_API.Modules.Chat.Application.Queries.GetAllThreads;

public class GetAllThreadsQueryHandler: IQueryHandler<GetAllThreadsQuery, List<Thread>>
{
    private readonly IThreadRepository _threadRepository;
    private readonly ICachingService _cachingService;

    public GetAllThreadsQueryHandler(IThreadRepository threadRepository,
        ICachingService cachingService)
    {
        _threadRepository = threadRepository;
        _cachingService = cachingService;
    }

    public async Task<List<Thread>> Handle(GetAllThreadsQuery request, CancellationToken cancellationToken)
    {
        var cachedThreads = await _cachingService.GetData<List<Thread>>(CacheKey.ChatThreads(request.UserId.ToString()));
        if (cachedThreads != null && cachedThreads.Count() > 0)
        {
            return cachedThreads;
        }

        var threads = await _threadRepository.GetAllThreadsByUserIdAsync(request.UserId);
        var expiryTime = DateTimeOffset.Now.AddHours((int)CacheExpiryTime.OneDay);

        await _cachingService.SetData<List<Thread>>(CacheKey.ChatThreads(request.UserId.ToString()), threads, expiryTime);
        return threads;
    }
}