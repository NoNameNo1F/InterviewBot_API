using MongoDB.Bson.Serialization;
using Thread = Interviewbot_API.Modules.Chat.Domain.Entities.Thread;

namespace Interviewbot_API.Modules.Chat.Infrastructure.Domain.Entities;

public class ThreadConfiguration
{
    public static void AddMapping()
    {
        if (!BsonClassMap.IsClassMapRegistered(typeof(Thread)))
        {
            BsonClassMap.RegisterClassMap<Thread>(classMap =>
            {
                classMap.SetIgnoreExtraElements(true);

                classMap.MapField(ap => ap.Id);
                classMap.MapField(ap => ap.Name);
                classMap.MapField(ap => ap.LastUpdate);
                classMap.MapField(ap => ap.UserId);
            });
        }
    }
}