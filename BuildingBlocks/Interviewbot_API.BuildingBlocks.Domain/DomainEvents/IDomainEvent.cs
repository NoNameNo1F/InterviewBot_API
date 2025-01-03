﻿using MediatR;

namespace Interviewbot_API.BuildingBlocks.Domain.DomainEvents;

public interface IDomainEvent : INotification
{
    Guid Id { get; }
    
    DateTime CreatedAt { get; }
}