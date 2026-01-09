using System.Text.RegularExpressions;
using ProjectName.Domain.Common;

namespace ProjectName.Domain.ValueObjects;

/// <summary>
/// Value object representing an email address.
/// </summary>
public sealed class Email : ValueObject
{
    private static readonly Regex EmailPattern = new(
        @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
        RegexOptions.Compiled | RegexOptions.IgnoreCase);

    /// <summary>
    /// Gets the email address value.
    /// </summary>
    public string Value { get; }

    private Email(string value)
    {
        Value = value;
    }

    /// <summary>
    /// Creates a new Email value object.
    /// </summary>
    /// <param name="email">The email address string.</param>
    /// <returns>A new Email value object.</returns>
    /// <exception cref="ArgumentException">Thrown when the email is invalid.</exception>
    public static Email Create(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email cannot be empty.", nameof(email));

        email = email.Trim().ToLowerInvariant();

        if (!EmailPattern.IsMatch(email))
            throw new ArgumentException("Email format is invalid.", nameof(email));

        if (email.Length > 255)
            throw new ArgumentException("Email cannot exceed 255 characters.", nameof(email));

        return new Email(email);
    }

    /// <summary>
    /// Tries to create an Email value object.
    /// </summary>
    /// <param name="email">The email address string.</param>
    /// <param name="result">The created Email if successful.</param>
    /// <returns>True if creation was successful, false otherwise.</returns>
    public static bool TryCreate(string email, out Email? result)
    {
        try
        {
            result = Create(email);
            return true;
        }
        catch
        {
            result = null;
            return false;
        }
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value;

    public static implicit operator string(Email email) => email.Value;
}
