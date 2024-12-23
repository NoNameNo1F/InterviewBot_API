using StackExchange.Redis;

namespace Interviewbot_API.Modules.Chat.Infrastructure.Caching;

public interface ICachingDatabase
{
    IDatabase Cache { get; }
}