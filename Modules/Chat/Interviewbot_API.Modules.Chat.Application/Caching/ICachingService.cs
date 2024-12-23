namespace Interviewbot_API.Modules.Chat.Application.Caching;

public interface ICachingService
{
    Task<T?> GetData<T>(string key);
    Task<bool> SetData<T>(string key, T value, DateTimeOffset expirationTime);
}