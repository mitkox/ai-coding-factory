namespace ProjectName.Domain.Common;

/// <summary>
/// Base class for domain events.
/// Provides common properties for all domain events.
/// </summary>
public abstract class DomainEvent : IDomainEvent
{
    /// <summary>
    /// Gets the date and time when the event occurred.
    /// </summary>
    public DateTime OccurredOn { get; }

    /// <summary>
    /// Gets the unique identifier for this event instance.
    /// </summary>
    public Guid EventId { get; }

    /// <summary>
    /// Initializes a new instance of the DomainEvent class.
    /// </summary>
    protected DomainEvent()
    {
        EventId = Guid.NewGuid();
        OccurredOn = DateTime.UtcNow;
    }
}
