namespace ProjectName.Domain.Common;

/// <summary>
/// Base class for value objects in the domain.
/// Value objects are immutable and compared by their property values, not identity.
/// </summary>
public abstract class ValueObject : IEquatable<ValueObject>
{
    /// <summary>
    /// Gets the components used for equality comparison.
    /// Override this in derived classes to specify which properties define equality.
    /// </summary>
    /// <returns>An enumerable of equality components.</returns>
    protected abstract IEnumerable<object?> GetEqualityComponents();

    public bool Equals(ValueObject? other)
    {
        if (other is null)
            return false;

        if (ReferenceEquals(this, other))
            return true;

        if (GetType() != other.GetType())
            return false;

        return GetEqualityComponents()
            .SequenceEqual(other.GetEqualityComponents());
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
            return false;

        if (ReferenceEquals(this, obj))
            return true;

        if (obj is not ValueObject other)
            return false;

        return Equals(other);
    }

    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Where(x => x is not null)
            .Aggregate(17, (current, obj) => current * 31 + obj!.GetHashCode());
    }

    public static bool operator ==(ValueObject? left, ValueObject? right)
    {
        if (left is null && right is null)
            return true;

        if (left is null || right is null)
            return false;

        return left.Equals(right);
    }

    public static bool operator !=(ValueObject? left, ValueObject? right)
    {
        return !(left == right);
    }

    /// <summary>
    /// Creates a copy of this value object.
    /// Override in derived classes to implement proper copying.
    /// </summary>
    /// <returns>A copy of this value object.</returns>
    public virtual ValueObject GetCopy()
    {
        return (ValueObject)MemberwiseClone();
    }
}
