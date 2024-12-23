namespace Interviewbot_API.BuildingBlocks.Domain.DomainEvents;

public class DomainEventBase : IDomainEvent
{
    public Guid Id { get; }
    public DateTime CreatedAt { get; }

    public DomainEventBase(Guid id, DateTime createdAt)
    {
        Id = id;
        CreatedAt = createdAt;
    }
}