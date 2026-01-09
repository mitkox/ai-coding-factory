using ProjectName.Domain.Common;

namespace ProjectName.Domain.ValueObjects;

/// <summary>
/// Value object representing a physical address.
/// </summary>
public sealed class Address : ValueObject
{
    /// <summary>
    /// Gets the street address line 1.
    /// </summary>
    public string Street1 { get; }

    /// <summary>
    /// Gets the street address line 2 (optional).
    /// </summary>
    public string? Street2 { get; }

    /// <summary>
    /// Gets the city.
    /// </summary>
    public string City { get; }

    /// <summary>
    /// Gets the state or province.
    /// </summary>
    public string State { get; }

    /// <summary>
    /// Gets the postal code.
    /// </summary>
    public string PostalCode { get; }

    /// <summary>
    /// Gets the country code (ISO 3166-1 alpha-2).
    /// </summary>
    public string Country { get; }

    private Address(
        string street1, 
        string? street2, 
        string city, 
        string state, 
        string postalCode, 
        string country)
    {
        Street1 = street1;
        Street2 = street2;
        City = city;
        State = state;
        PostalCode = postalCode;
        Country = country;
    }

    /// <summary>
    /// Creates a new Address value object.
    /// </summary>
    public static Address Create(
        string street1,
        string? street2,
        string city,
        string state,
        string postalCode,
        string country)
    {
        if (string.IsNullOrWhiteSpace(street1))
            throw new ArgumentException("Street address is required.", nameof(street1));

        if (string.IsNullOrWhiteSpace(city))
            throw new ArgumentException("City is required.", nameof(city));

        if (string.IsNullOrWhiteSpace(state))
            throw new ArgumentException("State is required.", nameof(state));

        if (string.IsNullOrWhiteSpace(postalCode))
            throw new ArgumentException("Postal code is required.", nameof(postalCode));

        if (string.IsNullOrWhiteSpace(country))
            throw new ArgumentException("Country is required.", nameof(country));

        country = country.ToUpperInvariant().Trim();
        if (country.Length != 2)
            throw new ArgumentException("Country must be a 2-letter ISO 3166-1 alpha-2 code.", nameof(country));

        return new Address(
            street1.Trim(),
            string.IsNullOrWhiteSpace(street2) ? null : street2.Trim(),
            city.Trim(),
            state.Trim(),
            postalCode.Trim(),
            country);
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Street1;
        yield return Street2;
        yield return City;
        yield return State;
        yield return PostalCode;
        yield return Country;
    }

    /// <summary>
    /// Returns the address as a single-line string.
    /// </summary>
    public string ToSingleLine()
    {
        var parts = new List<string> { Street1 };
        
        if (!string.IsNullOrWhiteSpace(Street2))
            parts.Add(Street2);
        
        parts.Add(City);
        parts.Add(State);
        parts.Add(PostalCode);
        parts.Add(Country);

        return string.Join(", ", parts);
    }

    /// <summary>
    /// Returns the address as a multi-line string.
    /// </summary>
    public string ToMultiLine()
    {
        var lines = new List<string> { Street1 };
        
        if (!string.IsNullOrWhiteSpace(Street2))
            lines.Add(Street2);
        
        lines.Add($"{City}, {State} {PostalCode}");
        lines.Add(Country);

        return string.Join(Environment.NewLine, lines);
    }

    public override string ToString() => ToSingleLine();
}
