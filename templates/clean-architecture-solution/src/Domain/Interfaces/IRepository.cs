namespace ProjectName.Domain.Interfaces;

/// <summary>
/// Generic repository interface for aggregate roots.
/// Repositories are for aggregate roots only - not for entities.
/// </summary>
/// <typeparam name="T">The aggregate root type.</typeparam>
public interface IRepository<T> where T : Common.AggregateRoot
{
    /// <summary>
    /// Gets an aggregate by its identifier.
    /// </summary>
    /// <param name="id">The aggregate identifier.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The aggregate if found, null otherwise.</returns>
    Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets all aggregates.
    /// Use with caution - consider pagination for large datasets.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>All aggregates.</returns>
    Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Adds a new aggregate to the repository.
    /// </summary>
    /// <param name="entity">The aggregate to add.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The added aggregate.</returns>
    Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing aggregate in the repository.
    /// </summary>
    /// <param name="entity">The aggregate to update.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    Task UpdateAsync(T entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes an aggregate from the repository.
    /// </summary>
    /// <param name="entity">The aggregate to delete.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    Task DeleteAsync(T entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Checks if an aggregate with the specified identifier exists.
    /// </summary>
    /// <param name="id">The aggregate identifier.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>True if exists, false otherwise.</returns>
    Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default);
}
