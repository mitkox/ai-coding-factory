namespace ProjectName.Domain.Common;

/// <summary>
/// Base class for aggregate roots in the domain.
/// Aggregate roots are the only entities that can be directly retrieved from repositories.
/// They define consistency boundaries and are responsible for maintaining invariants.
/// </summary>
public abstract class AggregateRoot : Entity
{
    /// <summary>
    /// Gets the version of the aggregate for optimistic concurrency.
    /// </summary>
    public int Version { get; protected set; }

    /// <summary>
    /// Initializes a new instance of the AggregateRoot class.
    /// </summary>
    protected AggregateRoot() : base()
    {
        Version = 0;
    }

    /// <summary>
    /// Initializes a new instance of the AggregateRoot class with a specific ID.
    /// </summary>
    /// <param name="id">The aggregate identifier.</param>
    protected AggregateRoot(Guid id) : base(id)
    {
        Version = 0;
    }

    /// <summary>
    /// Increments the version number. Called after each state change.
    /// </summary>
    protected void IncrementVersion()
    {
        Version++;
    }
}
