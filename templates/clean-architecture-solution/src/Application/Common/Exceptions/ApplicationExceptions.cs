using FluentValidation.Results;

namespace ProjectName.Application.Common.Exceptions;

/// <summary>
/// Exception thrown when validation fails.
/// </summary>
public class ValidationException : Exception
{
    /// <summary>
    /// Gets the validation errors grouped by property name.
    /// </summary>
    public IDictionary<string, string[]> Errors { get; }

    /// <summary>
    /// Initializes a new instance of the ValidationException class.
    /// </summary>
    public ValidationException()
        : base("One or more validation failures have occurred.")
    {
        Errors = new Dictionary<string, string[]>();
    }

    /// <summary>
    /// Initializes a new instance of the ValidationException class with validation failures.
    /// </summary>
    /// <param name="failures">The validation failures.</param>
    public ValidationException(IEnumerable<ValidationFailure> failures)
        : this()
    {
        Errors = failures
            .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
            .ToDictionary(
                failureGroup => failureGroup.Key, 
                failureGroup => failureGroup.ToArray());
    }
}

/// <summary>
/// Exception thrown when an entity is not found.
/// </summary>
public class NotFoundException : Exception
{
    /// <summary>
    /// Initializes a new instance of the NotFoundException class.
    /// </summary>
    /// <param name="name">The entity name.</param>
    /// <param name="key">The entity key.</param>
    public NotFoundException(string name, object key)
        : base($"Entity \"{name}\" ({key}) was not found.")
    {
    }
}

/// <summary>
/// Exception thrown when the user is forbidden from performing an action.
/// </summary>
public class ForbiddenAccessException : Exception
{
    /// <summary>
    /// Initializes a new instance of the ForbiddenAccessException class.
    /// </summary>
    public ForbiddenAccessException() 
        : base("You do not have permission to perform this action.")
    {
    }
}

/// <summary>
/// Exception thrown when an unauthorized access attempt is made.
/// </summary>
public class UnauthorizedAccessException : Exception
{
    /// <summary>
    /// Initializes a new instance of the UnauthorizedAccessException class.
    /// </summary>
    public UnauthorizedAccessException() 
        : base("Authentication is required to access this resource.")
    {
    }
}
