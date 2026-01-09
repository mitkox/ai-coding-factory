using FluentAssertions;
using ProjectName.Domain.Exceptions;
using Xunit;

namespace ProjectName.UnitTests.Domain;

[Trait("Story", "ACF-0001")]
public class DomainExceptionTests
{
    private sealed class TestDomainException : DomainException
    {
        public TestDomainException(string errorCode, string message) : base(errorCode, message)
        {
        }

        public TestDomainException(string errorCode, string message, Exception innerException)
            : base(errorCode, message, innerException)
        {
        }
    }

    [Fact]
    public void EntityNotFoundExceptionShouldExposeDetails()
    {
        // Act
        var exception = new EntityNotFoundException("Order", 123);

        // Assert
        exception.ErrorCode.Should().Be("ENTITY_NOT_FOUND");
        exception.EntityType.Should().Be("Order");
        exception.EntityId.Should().Be(123);
        exception.Message.Should().Contain("Order");
    }

    [Fact]
    public void BusinessRuleExceptionShouldExposeDetails()
    {
        // Act
        var exception = new BusinessRuleException("Rule1", "Rule violated");

        // Assert
        exception.ErrorCode.Should().Be("BUSINESS_RULE_VIOLATION");
        exception.RuleName.Should().Be("Rule1");
        exception.Message.Should().Be("Rule violated");
    }

    [Fact]
    public void ConcurrencyExceptionShouldExposeDetails()
    {
        // Act
        var exception = new ConcurrencyException("Order", 42);

        // Assert
        exception.ErrorCode.Should().Be("CONCURRENCY_CONFLICT");
        exception.EntityType.Should().Be("Order");
        exception.EntityId.Should().Be(42);
        exception.Message.Should().Contain("Order");
    }

    [Fact]
    public void DomainExceptionShouldSupportInnerException()
    {
        // Arrange
        var inner = new InvalidOperationException("inner");

        // Act
        var exception = new TestDomainException("TEST", "message", inner);

        // Assert
        exception.ErrorCode.Should().Be("TEST");
        exception.Message.Should().Be("message");
        exception.InnerException.Should().Be(inner);
    }
}
