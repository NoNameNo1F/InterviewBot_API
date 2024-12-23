using System.Linq.Expressions;
using Thread = Interviewbot_API.Modules.Chat.Domain.Entities.Thread;

namespace Interviewbot_API.Modules.Chat.Domain.Repositories;

public interface IThreadRepository
{
    Task<List<Thread>> GetAllThreadsByUserIdAsync(Guid userId);
    Task<(List<Thread>, int)> GetPagingThreadsByUserIdAsync(int pageNumber, int pageSize, Expression<Func<Thread, bool>>? filter);
    Task<Thread> GetThreadByIdAsync(Guid threadId);
    Task<bool> CreateThreadAsync(Thread thread);
    Task<bool> UpdateThreadAsync(Thread thread);
    Task<bool> DeleteThreadAsync(Thread thread);
    
}