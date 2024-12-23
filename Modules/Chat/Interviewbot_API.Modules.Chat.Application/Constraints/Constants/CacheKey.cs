namespace Interviewbot_API.Modules.Chat.Application.Constraints.Constants;

public class CacheKey
{
    public static string ChatThreads(string userId) => $"chat:{userId}:threads";
    
    public static string LatestMessages(Guid userId, string threadId) => $"chat:{userId}:{threadId}:messages:latest";
}