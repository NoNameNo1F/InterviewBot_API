using StackExchange.Redis;

namespace Interviewbot_API.Modules.Chat.Infrastructure.Caching;

public class CachingDatabase : ICachingDatabase
{
    public IDatabase Cache { get; }

    public CachingDatabase(string connectinoString)
    {
        var redis = ConnectionMultiplexer.Connect(connectinoString);
        Cache = redis.GetDatabase();
    }
}