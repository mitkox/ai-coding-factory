using FluentAssertions;
using ProjectName.Domain.ValueObjects;
using Xunit;

namespace ProjectName.UnitTests.Domain;

[Trait("Story", "ACF-0001")]
public class ValueObjectTests
{
    [Fact]
    public void EmailValidEmailShouldCreate()
    {
        // Arrange
        var emailString = "test@example.com";

        // Act
        var email = Email.Create(emailString);

        // Assert
        email.Should().NotBeNull();
        email.Value.Should().Be(emailString);
    }

    [Theory]
    [InlineData("")]
    [InlineData("invalid-email")]
    [InlineData("@example.com")]
    [InlineData("test@")]
    public void EmailInvalidEmailShouldThrowException(string invalidEmail)
    {
        // Act
        var act = () => Email.Create(invalidEmail);

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void EmailShouldNormalizeAndSupportImplicitConversion()
    {
        // Act
        var email = Email.Create(" Test@Example.com ");
        string value = email;

        // Assert
        email.Value.Should().Be("test@example.com");
        email.ToString().Should().Be("test@example.com");
        value.Should().Be("test@example.com");
    }

    [Fact]
    public void EmailTryCreateShouldReturnTrueForValidEmail()
    {
        // Act
        var result = Email.TryCreate("valid@example.com", out var email);

        // Assert
        result.Should().BeTrue();
        email.Should().NotBeNull();
        email!.Value.Should().Be("valid@example.com");
    }

    [Fact]
    public void EmailTryCreateShouldReturnFalseForInvalidEmail()
    {
        // Act
        var result = Email.TryCreate("invalid", out var email);

        // Assert
        result.Should().BeFalse();
        email.Should().BeNull();
    }

    [Fact]
    public void EmailTooLongShouldThrowException()
    {
        // Arrange
        var localPart = new string('a', 250);
        var email = $"{localPart}@ex.com";

        // Act
        var act = () => Email.Create(email);

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void MoneyValidAmountShouldCreate()
    {
        // Arrange
        var amount = 100.50m;
        var currency = "USD";

        // Act
        var money = Money.Create(amount, currency);

        // Assert
        money.Should().NotBeNull();
        money.Amount.Should().Be(amount);
        money.Currency.Should().Be(currency);
    }

    [Fact]
    public void MoneyNegativeAmountShouldThrowException()
    {
        // Act
        var act = () => Money.Create(-10, "USD");

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void MoneyShouldRoundAndNormalizeCurrency()
    {
        // Act
        var money = Money.Create(10.235m, "usd");

        // Assert
        money.Amount.Should().Be(10.24m);
        money.Currency.Should().Be("USD");
    }

    [Fact]
    public void MoneyFactoryMethodsShouldCreateExpectedValues()
    {
        // Act
        var usd = Money.USD(12.5m);
        var eur = Money.EUR(20m);
        var gbp = Money.GBP(7m);
        var zero = Money.Zero("usd");

        // Assert
        usd.Currency.Should().Be("USD");
        eur.Currency.Should().Be("EUR");
        gbp.Currency.Should().Be("GBP");
        zero.Amount.Should().Be(0m);
        zero.Currency.Should().Be("USD");
    }

    [Fact]
    public void MoneyOperationsShouldHandleSameCurrency()
    {
        // Arrange
        var left = Money.USD(10m);
        var right = Money.USD(5m);

        // Act
        var sum = left + right;
        var diff = left - right;
        var product = left * 2m;

        // Assert
        sum.Amount.Should().Be(15m);
        diff.Amount.Should().Be(5m);
        product.Amount.Should().Be(20m);
    }

    [Fact]
    public void MoneyOperationsShouldRejectDifferentCurrencies()
    {
        // Arrange
        var usd = Money.USD(10m);
        var eur = Money.EUR(5m);

        // Act
        Action add = () => usd.Add(eur);
        Action subtract = () => usd.Subtract(eur);
        Action compare = () => { _ = usd > eur; };

        // Assert
        add.Should().Throw<InvalidOperationException>();
        subtract.Should().Throw<InvalidOperationException>();
        compare.Should().Throw<InvalidOperationException>();
    }

    [Theory]
    [InlineData("")]
    [InlineData("US")]
    [InlineData("USDD")]
    public void MoneyInvalidCurrencyShouldThrowException(string currency)
    {
        // Act
        Action act = () => Money.Create(10m, currency);

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void MoneyComparisonOperatorsShouldWork()
    {
        // Arrange
        var small = Money.USD(1m);
        var large = Money.USD(2m);

        // Assert
        (large > small).Should().BeTrue();
        (small < large).Should().BeTrue();
        (large >= small).Should().BeTrue();
        (small <= large).Should().BeTrue();
    }

    [Fact]
    public void AddressValidAddressShouldCreate()
    {
        // Arrange
        var street1 = "123 Main St";
        var street2 = "Suite 100";
        var city = "Springfield";
        var state = "IL";
        var postalCode = "62701";
        var country = "US";

        // Act
        var address = Address.Create(street1, street2, city, state, postalCode, country);

        // Assert
        address.Should().NotBeNull();
        address.Street1.Should().Be(street1);
        address.Street2.Should().Be(street2);
        address.City.Should().Be(city);
        address.State.Should().Be(state);
        address.PostalCode.Should().Be(postalCode);
        address.Country.Should().Be(country);
    }

    [Fact]
    public void AddressShouldFormatSingleLineAndMultiLine()
    {
        // Arrange
        var addressWithStreet2 = Address.Create(
            "123 Main St",
            "Suite 100",
            "Springfield",
            "IL",
            "62701",
            "us");

        var addressWithoutStreet2 = Address.Create(
            "456 Oak St",
            null,
            "Springfield",
            "IL",
            "62701",
            "us");

        // Act
        var singleLine = addressWithStreet2.ToSingleLine();
        var multiLine = addressWithStreet2.ToMultiLine();
        var singleLineNoStreet2 = addressWithoutStreet2.ToSingleLine();

        // Assert
        singleLine.Should().Contain("Suite 100");
        multiLine.Should().Contain("Suite 100");
        singleLineNoStreet2.Should().NotContain("Suite 100");
        addressWithStreet2.ToString().Should().Be(singleLine);
    }

    [Fact]
    public void AddressShouldNormalizeEmptyStreet2()
    {
        // Act
        var address = Address.Create("123 Main St", "   ", "City", "State", "12345", "US");

        // Assert
        address.Street2.Should().BeNull();
    }

    [Fact]
    public void AddressInvalidCountryShouldThrowException()
    {
        // Act
        var act = () => Address.Create("123 Main St", null, "City", "State", "12345", "USA");

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void ValueObjectEqualityShouldCompareByValues()
    {
        // Arrange
        var email1 = Email.Create("test@example.com");
        var email2 = Email.Create("test@example.com");
        var email3 = Email.Create("other@example.com");

        // Assert
        email1.Equals(email1).Should().BeTrue();
        (email1 == email2).Should().BeTrue();
        (email1 != email2).Should().BeFalse();
        (email1 == email3).Should().BeFalse();
        email1.Equals(Money.USD(1m)).Should().BeFalse();
        email1.Equals("not-a-value-object").Should().BeFalse();
        email1.Equals(null).Should().BeFalse();
        email1!.GetHashCode().Should().Be(email2!.GetHashCode());
    }

    [Fact]
    public void ValueObjectEqualityShouldHandleNullOperands()
    {
        // Arrange
        Email? left = null;
        Email? right = null;
        var email = Email.Create("test@example.com");

        // Assert
        (left == right).Should().BeTrue();
        (left == email).Should().BeFalse();
        (email == right).Should().BeFalse();
    }

    [Fact]
    public void ValueObjectGetCopyShouldReturnNewInstance()
    {
        // Arrange
        var money = Money.USD(5m);

        // Act
        var copy = money.GetCopy();

        // Assert
        copy.Should().NotBeSameAs(money);
        copy.Should().Be(money);
    }
}
