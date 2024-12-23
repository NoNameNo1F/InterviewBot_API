using Interviewbot_API.BuildingBlocks.Domain.Entities;

namespace Interviewbot_API.Modules.Chat.Domain.Entities;

public class Thread : Entity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid UserId { get; set; }
    public DateOnly LastUpdate { get; set; }
}