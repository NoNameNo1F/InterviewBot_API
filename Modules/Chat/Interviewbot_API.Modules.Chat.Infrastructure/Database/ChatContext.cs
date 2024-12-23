using Interviewbot_API.Modules.Chat.Domain.Entities;
using Interviewbot_API.Modules.Chat.Infrastructure.Domain.Entities;
using MongoDB.Driver;
using Thread = Interviewbot_API.Modules.Chat.Domain.Entities.Thread;

namespace Interviewbot_API.Modules.Chat.Infrastructure.Database;

public class ChatContext : IChatContext
{
    public IMongoDatabase Database { get; }

    public IMongoCollection<Message> MessageCollection;
    public IMongoCollection<Thread> ThreadCollection;

    
    public ChatContext(DatabaseConfiguration configuration)
    {
        var client = new MongoClient(configuration.ConnectionString);
        Database = client.GetDatabase(configuration.DatabaseName);

        ConfigureEntities();

        ThreadCollection = Database.GetCollection<Thread>(nameof(Thread), settings: new MongoCollectionSettings());
        MessageCollection = Database.GetCollection<Message>(nameof(Message));
    }

    private void ConfigureEntities()
    {
        MessageConfiguration.AddMapping();
        ThreadConfiguration.AddMapping();
    }
}