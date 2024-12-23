using System.Linq.Expressions;
using Interviewbot_API.Modules.Chat.Domain.Repositories;
using Interviewbot_API.Modules.Chat.Infrastructure.Database;
using MongoDB.Driver;
using Thread = Interviewbot_API.Modules.Chat.Domain.Entities.Thread;

namespace Interviewbot_API.Modules.Chat.Infrastructure.Domain.Repositories;

internal class ThreadRepository : IThreadRepository
{
    private readonly ChatContext _chatContext;

    public ThreadRepository(ChatContext chatContext)
    {
        _chatContext = chatContext;
    }

    public async Task<List<Thread>> GetAllThreadsByUserIdAsync(Guid userId)
    {
        return await _chatContext
            .ThreadCollection
            .Find(filter: m => m.Id.ToString() == userId.ToString())
            .ToListAsync();
    }

    public async Task<(List<Thread>, int)> GetPagingThreadsByUserIdAsync(int pageNumber, int pageSize, Expression<Func<Thread, bool>>? filter)
    {
        var count = await _chatContext
            .ThreadCollection
            .CountDocumentsAsync(filter);

        var threads = await _chatContext
            .ThreadCollection
            .Find(filter)
            .Skip((pageNumber - 1) * pageSize)
            .Limit(pageSize)
            .ToListAsync();

        return (threads, (int)count);
    }

    public async Task<Thread> GetThreadByIdAsync(Guid threadId)
    {
        return await _chatContext
            .ThreadCollection
            .Find(filter: t => t.Id.ToString() == threadId.ToString())
            .SingleOrDefaultAsync();
    }

    public async Task<bool> CreateThreadAsync(Thread thread)
    {
        await _chatContext
            .ThreadCollection.
            InsertOneAsync(thread);
        return true;
    }

    public async Task<bool> UpdateThreadAsync(Thread thread)
    {
        await _chatContext
            .ThreadCollection
            .ReplaceOneAsync(
                filter: m => m.Id.ToString() == thread.Id.ToString(),
                replacement: thread
            );
        return true;
    }

    public async Task<bool> DeleteThreadAsync(Thread thread)
    {
        await _chatContext
            .ThreadCollection
            .DeleteOneAsync(
                filter: m => m.Id.ToString() == thread.Id.ToString());
        return true;
    }
}