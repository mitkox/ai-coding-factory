namespace ProjectName.Domain.Common;

/// <summary>
/// Marker interface for domain events.
/// Domain events capture something that happened in the domain that domain experts care about.
/// </summary>
public interface IDomainEvent
{
    /// <summary>
    /// Gets the date and time when the event occurred.
    /// </summary>
    DateTime OccurredOn { get; }

    /// <summary>
    /// Gets the unique identifier for this event instance.
    /// </summary>
    Guid EventId { get; }
}
