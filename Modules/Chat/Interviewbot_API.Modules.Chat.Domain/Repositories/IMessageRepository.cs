using Interviewbot_API.Modules.Chat.Domain.Entities;

namespace Interviewbot_API.Modules.Chat.Domain.Repositories;

public interface IMessageRepository
{
    Task<List<Message>> GetAllMessagesByThreadIdAsync(Guid threadId);
    Task<Message> GetMessageByIdAsync(Guid messageId);
    Task<bool> CreateMessageAsync(Message message);
    Task<bool> UpdateMessageAsync(Message message);
    Task<bool> DeleteMessageAsync(Message message);
}