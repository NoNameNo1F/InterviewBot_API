using Interviewbot_API.BuildingBlocks.Domain.DomainEvents;

namespace Interviewbot_API.BuildingBlocks.Application.Events;

public class DomainNotificationBase<T> : IDomainEventNotification<T>
    where T : IDomainEvent
{
    public Guid Id { get; }
    public T DomainEvent { get; }

    public DomainNotificationBase(T domainEvent, Guid id)
    {
        Id = id;
        DomainEvent = domainEvent;
    }
}