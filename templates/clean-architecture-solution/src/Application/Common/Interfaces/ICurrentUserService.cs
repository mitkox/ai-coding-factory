namespace ProjectName.Application.Common.Interfaces;

/// <summary>
/// Interface for accessing the current user's information.
/// </summary>
public interface ICurrentUserService
{
    /// <summary>
    /// Gets the current user's identifier.
    /// </summary>
    string? UserId { get; }

    /// <summary>
    /// Gets the current user's email.
    /// </summary>
    string? Email { get; }

    /// <summary>
    /// Gets whether the current user is authenticated.
    /// </summary>
    bool IsAuthenticated { get; }

    /// <summary>
    /// Gets the current user's roles.
    /// </summary>
    IEnumerable<string> Roles { get; }

    /// <summary>
    /// Checks if the current user is in the specified role.
    /// </summary>
    /// <param name="role">The role to check.</param>
    /// <returns>True if in role, false otherwise.</returns>
    bool IsInRole(string role);
}
