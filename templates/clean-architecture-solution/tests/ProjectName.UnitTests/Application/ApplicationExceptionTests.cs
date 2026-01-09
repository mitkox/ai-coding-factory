using FluentAssertions;
using FluentValidation.Results;
using Xunit;
using ApplicationUnauthorizedAccessException = ProjectName.Application.Common.Exceptions.UnauthorizedAccessException;
using ValidationException = ProjectName.Application.Common.Exceptions.ValidationException;
using ForbiddenAccessException = ProjectName.Application.Common.Exceptions.ForbiddenAccessException;
using NotFoundException = ProjectName.Application.Common.Exceptions.NotFoundException;

namespace ProjectName.UnitTests.Application;

[Trait("Story", "ACF-0001")]
public class ApplicationExceptionTests
{
    private static readonly ValidationFailure[] SampleFailures =
    {
        new("Name", "Name is required"),
        new("Name", "Name must be longer")
    };
    private static readonly string[] SampleFailureMessages =
    {
        "Name is required",
        "Name must be longer"
    };

    [Fact]
    public void ValidationExceptionShouldContainFailures()
    {
        // Arrange
        var exception = new ValidationException(SampleFailures);

        // Assert
        exception.Errors.Should().ContainKey("Name");
        exception.Errors["Name"].Should().Contain(SampleFailureMessages);
    }

    [Fact]
    public void ValidationExceptionDefaultConstructorShouldSetMessage()
    {
        // Act
        var exception = new ValidationException();

        // Assert
        exception.Message.Should().Contain("validation failures");
        exception.Errors.Should().BeEmpty();
    }

    [Fact]
    public void NotFoundExceptionShouldIncludeEntityNameAndKey()
    {
        // Act
        var exception = new NotFoundException("Order", 7);

        // Assert
        exception.Message.Should().Contain("Order");
        exception.Message.Should().Contain("7");
    }

    [Fact]
    public void ForbiddenAccessExceptionShouldIncludeDefaultMessage()
    {
        // Act
        var exception = new ForbiddenAccessException();

        // Assert
        exception.Message.Should().Contain("permission");
    }

    [Fact]
    public void UnauthorizedAccessExceptionShouldIncludeDefaultMessage()
    {
        // Act
        var exception = new ApplicationUnauthorizedAccessException();

        // Assert
        exception.Message.Should().Contain("Authentication");
    }
}
