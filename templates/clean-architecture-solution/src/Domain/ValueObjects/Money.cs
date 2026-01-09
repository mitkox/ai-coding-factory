using ProjectName.Domain.Common;

namespace ProjectName.Domain.ValueObjects;

/// <summary>
/// Value object representing a monetary amount with currency.
/// </summary>
public sealed class Money : ValueObject
{
    /// <summary>
    /// Gets the amount.
    /// </summary>
    public decimal Amount { get; }

    /// <summary>
    /// Gets the currency code (ISO 4217).
    /// </summary>
    public string Currency { get; }

    private Money(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    /// <summary>
    /// Creates a new Money value object.
    /// </summary>
    /// <param name="amount">The monetary amount.</param>
    /// <param name="currency">The currency code (ISO 4217, e.g., USD, EUR, GBP).</param>
    /// <returns>A new Money value object.</returns>
    /// <exception cref="ArgumentException">Thrown when parameters are invalid.</exception>
    public static Money Create(decimal amount, string currency)
    {
        if (string.IsNullOrWhiteSpace(currency))
            throw new ArgumentException("Currency cannot be empty.", nameof(currency));

        currency = currency.ToUpperInvariant().Trim();

        if (currency.Length != 3)
            throw new ArgumentException("Currency must be a 3-letter ISO 4217 code.", nameof(currency));

        if (amount < 0)
            throw new ArgumentException("Amount cannot be negative.", nameof(amount));

        // Round to 2 decimal places for most currencies
        amount = Math.Round(amount, 2, MidpointRounding.AwayFromZero);

        return new Money(amount, currency);
    }

    /// <summary>
    /// Creates Money in USD.
    /// </summary>
    public static Money USD(decimal amount) => Create(amount, "USD");

    /// <summary>
    /// Creates Money in EUR.
    /// </summary>
    public static Money EUR(decimal amount) => Create(amount, "EUR");

    /// <summary>
    /// Creates Money in GBP.
    /// </summary>
    public static Money GBP(decimal amount) => Create(amount, "GBP");

    /// <summary>
    /// Creates zero Money in the specified currency.
    /// </summary>
    public static Money Zero(string currency) => Create(0, currency);

    /// <summary>
    /// Adds two Money values. They must have the same currency.
    /// </summary>
    public Money Add(Money other)
    {
        if (Currency != other.Currency)
            throw new InvalidOperationException($"Cannot add money with different currencies: {Currency} and {other.Currency}");

        return Create(Amount + other.Amount, Currency);
    }

    /// <summary>
    /// Subtracts two Money values. They must have the same currency.
    /// </summary>
    public Money Subtract(Money other)
    {
        if (Currency != other.Currency)
            throw new InvalidOperationException($"Cannot subtract money with different currencies: {Currency} and {other.Currency}");

        return Create(Amount - other.Amount, Currency);
    }

    /// <summary>
    /// Multiplies Money by a factor.
    /// </summary>
    public Money Multiply(decimal factor)
    {
        return Create(Amount * factor, Currency);
    }

    public static Money operator +(Money left, Money right) => left.Add(right);
    public static Money operator -(Money left, Money right) => left.Subtract(right);
    public static Money operator *(Money left, decimal right) => left.Multiply(right);
    public static bool operator >(Money left, Money right) => left.CompareTo(right) > 0;
    public static bool operator <(Money left, Money right) => left.CompareTo(right) < 0;
    public static bool operator >=(Money left, Money right) => left.CompareTo(right) >= 0;
    public static bool operator <=(Money left, Money right) => left.CompareTo(right) <= 0;

    private int CompareTo(Money other)
    {
        if (Currency != other.Currency)
            throw new InvalidOperationException($"Cannot compare money with different currencies: {Currency} and {other.Currency}");

        return Amount.CompareTo(other.Amount);
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Amount;
        yield return Currency;
    }

    public override string ToString() => $"{Amount:N2} {Currency}";
}
