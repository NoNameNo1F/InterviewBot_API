using Interviewbot_API.Modules.Chat.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.Bson.Serialization;

namespace Interviewbot_API.Modules.Chat.Infrastructure.Domain.Entities;

public class MessageConfiguration
{
    public static void AddMapping()
    {
        if (!BsonClassMap.IsClassMapRegistered(typeof(Message)))
        {
            BsonClassMap.RegisterClassMap<Message>(classMap =>
            {
                classMap.SetIgnoreExtraElements(true);

                classMap.MapField(ap => ap.Id);
                classMap.MapField(ap => ap.ThreadId);
                classMap.MapField(ap => ap.Content);
                classMap.MapField(ap => ap.Role);
                classMap.MapField(ap => ap.Type);
                classMap.MapField(ap => ap.CreatedAt);
            });
        }
    }
}