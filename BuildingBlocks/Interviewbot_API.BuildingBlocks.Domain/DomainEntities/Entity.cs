using Interviewbot_API.BuildingBlocks.Domain.DomainEvents;

namespace Interviewbot_API.BuildingBlocks.Domain.Entities;

public class Entity
{
    private List<IDomainEvent> _domainEvents;
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents?.AsReadOnly();

    public void ClearDomainEvents()
    {
        _domainEvents?.Clear();
    }

    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}