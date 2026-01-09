namespace ProjectName.Domain.Exceptions;

/// <summary>
/// Base exception for domain-level errors.
/// </summary>
public abstract class DomainException : Exception
{
    /// <summary>
    /// Gets the error code for this exception.
    /// </summary>
    public string ErrorCode { get; }

    /// <summary>
    /// Initializes a new instance of the DomainException class.
    /// </summary>
    /// <param name="errorCode">The error code.</param>
    /// <param name="message">The error message.</param>
    protected DomainException(string errorCode, string message) 
        : base(message)
    {
        ErrorCode = errorCode;
    }

    /// <summary>
    /// Initializes a new instance of the DomainException class with an inner exception.
    /// </summary>
    /// <param name="errorCode">The error code.</param>
    /// <param name="message">The error message.</param>
    /// <param name="innerException">The inner exception.</param>
    protected DomainException(string errorCode, string message, Exception innerException) 
        : base(message, innerException)
    {
        ErrorCode = errorCode;
    }
}

/// <summary>
/// Exception thrown when an entity is not found.
/// </summary>
public class EntityNotFoundException : DomainException
{
    /// <summary>
    /// Gets the entity type that was not found.
    /// </summary>
    public string EntityType { get; }

    /// <summary>
    /// Gets the entity identifier that was not found.
    /// </summary>
    public object EntityId { get; }

    /// <summary>
    /// Initializes a new instance of the EntityNotFoundException class.
    /// </summary>
    /// <param name="entityType">The entity type.</param>
    /// <param name="entityId">The entity identifier.</param>
    public EntityNotFoundException(string entityType, object entityId)
        : base("ENTITY_NOT_FOUND", $"{entityType} with id '{entityId}' was not found.")
    {
        EntityType = entityType;
        EntityId = entityId;
    }
}

/// <summary>
/// Exception thrown when a business rule is violated.
/// </summary>
public class BusinessRuleException : DomainException
{
    /// <summary>
    /// Gets the name of the violated rule.
    /// </summary>
    public string RuleName { get; }

    /// <summary>
    /// Initializes a new instance of the BusinessRuleException class.
    /// </summary>
    /// <param name="ruleName">The name of the violated rule.</param>
    /// <param name="message">The error message.</param>
    public BusinessRuleException(string ruleName, string message)
        : base("BUSINESS_RULE_VIOLATION", message)
    {
        RuleName = ruleName;
    }
}

/// <summary>
/// Exception thrown when there's a concurrency conflict.
/// </summary>
public class ConcurrencyException : DomainException
{
    /// <summary>
    /// Gets the entity type that had the concurrency conflict.
    /// </summary>
    public string EntityType { get; }

    /// <summary>
    /// Gets the entity identifier that had the concurrency conflict.
    /// </summary>
    public object EntityId { get; }

    /// <summary>
    /// Initializes a new instance of the ConcurrencyException class.
    /// </summary>
    /// <param name="entityType">The entity type.</param>
    /// <param name="entityId">The entity identifier.</param>
    public ConcurrencyException(string entityType, object entityId)
        : base("CONCURRENCY_CONFLICT", 
            $"The {entityType} with id '{entityId}' was modified by another process. Please refresh and try again.")
    {
        EntityType = entityType;
        EntityId = entityId;
    }
}
