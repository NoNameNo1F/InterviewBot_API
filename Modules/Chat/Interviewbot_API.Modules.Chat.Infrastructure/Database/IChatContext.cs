using MongoDB.Driver;

namespace Interviewbot_API.Modules.Chat.Infrastructure.Database;

public interface IChatContext
{
    IMongoDatabase Database { get; }
}