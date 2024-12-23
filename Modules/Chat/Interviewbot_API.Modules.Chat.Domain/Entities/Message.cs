using Interviewbot_API.BuildingBlocks.Domain.Entities;

namespace Interviewbot_API.Modules.Chat.Domain.Entities;

public class Message : Entity
{
    public Guid Id { get; set; }
    public Guid ThreadId { get; set; }
    public string Role { get; set; }
    public string Content { get; set; }
    public string Type { get; set; }
    public DateTime CreatedAt { get; set; }
}