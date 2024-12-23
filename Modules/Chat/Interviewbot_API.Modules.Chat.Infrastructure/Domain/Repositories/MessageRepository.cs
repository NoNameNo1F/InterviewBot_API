using Interviewbot_API.Modules.Chat.Domain.Entities;
using Interviewbot_API.Modules.Chat.Domain.Repositories;
using Interviewbot_API.Modules.Chat.Infrastructure.Database;
using MongoDB.Driver;

namespace Interviewbot_API.Modules.Chat.Infrastructure.Domain.Repositories;

internal class MessageRepository : IMessageRepository
{
    private readonly ChatContext _chatContext;

    public MessageRepository(ChatContext chatContext)
    {
        _chatContext = chatContext;
    }
    
    public async Task<List<Message>> GetAllMessagesByThreadIdAsync(Guid threadId)
    {
        return await _chatContext
            .MessageCollection
            .Find(filter: m => m.ThreadId.ToString() == threadId.ToString())
            .ToListAsync();
    }
    

    public async Task<Message> GetMessageByIdAsync(Guid messageId)
    {
        return await _chatContext
            .MessageCollection
            .Find(filter: m => m.Id.ToString() == messageId.ToString())
            .SingleOrDefaultAsync();
    }

    public async Task<bool> CreateMessageAsync(Message message)
    {
        await _chatContext
            .MessageCollection.
            InsertOneAsync(message);
        return true;
    }

    public async Task<bool> UpdateMessageAsync(Message message)
    {
        await _chatContext
            .MessageCollection
            .ReplaceOneAsync(
                filter: m => m.Id.ToString() == message.Id.ToString(),
                replacement: message
            );
        return true;
    }

    public async Task<bool> DeleteMessageAsync(Message message)
    {
        await _chatContext
            .MessageCollection
            .DeleteOneAsync(
                filter: m => m.Id.ToString() == message.Id.ToString());
        return true;
    }
}