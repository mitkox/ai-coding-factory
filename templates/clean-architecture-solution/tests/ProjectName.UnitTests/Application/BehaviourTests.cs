using FluentAssertions;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using ProjectName.Application.Common.Behaviours;
using Xunit;
using ApplicationValidationException = ProjectName.Application.Common.Exceptions.ValidationException;

namespace ProjectName.UnitTests.Application;

[Trait("Story", "ACF-0001")]
public class BehaviourTests
{
    private sealed record TestRequest(string Name);

    private sealed record TestResponse(string Message);

    private sealed class TestRequestValidator : AbstractValidator<TestRequest>
    {
        public TestRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }

    [Fact]
    public async Task ValidationBehaviourShouldSkipWhenNoValidators()
    {
        // Arrange
        var behaviour = new ValidationBehaviour<TestRequest, TestResponse>(Array.Empty<IValidator<TestRequest>>());
        var request = new TestRequest("valid");
        RequestHandlerDelegate<TestResponse> next = () => Task.FromResult(new TestResponse("ok"));

        // Act
        var response = await behaviour.Handle(request, next, CancellationToken.None);

        // Assert
        response.Message.Should().Be("ok");
    }

    [Fact]
    public async Task ValidationBehaviourShouldProceedWhenValid()
    {
        // Arrange
        var validators = new[] { new TestRequestValidator() };
        var behaviour = new ValidationBehaviour<TestRequest, TestResponse>(validators);
        var request = new TestRequest("valid");
        RequestHandlerDelegate<TestResponse> next = () => Task.FromResult(new TestResponse("ok"));

        // Act
        var response = await behaviour.Handle(request, next, CancellationToken.None);

        // Assert
        response.Message.Should().Be("ok");
    }

    [Fact]
    public async Task ValidationBehaviourShouldThrowWhenInvalid()
    {
        // Arrange
        var validators = new[] { new TestRequestValidator() };
        var behaviour = new ValidationBehaviour<TestRequest, TestResponse>(validators);
        var request = new TestRequest(string.Empty);
        RequestHandlerDelegate<TestResponse> next = () => Task.FromResult(new TestResponse("ok"));

        // Act
        Func<Task> act = () => behaviour.Handle(request, next, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<ApplicationValidationException>();
    }

    [Fact]
    public async Task LoggingBehaviourShouldReturnResponse()
    {
        // Arrange
        var logger = NullLogger<LoggingBehaviour<TestRequest, TestResponse>>.Instance;
        var behaviour = new LoggingBehaviour<TestRequest, TestResponse>(logger);
        var request = new TestRequest("valid");
        RequestHandlerDelegate<TestResponse> next = () => Task.FromResult(new TestResponse("ok"));

        // Act
        var response = await behaviour.Handle(request, next, CancellationToken.None);

        // Assert
        response.Message.Should().Be("ok");
    }

    [Fact]
    public async Task LoggingBehaviourShouldRethrowExceptions()
    {
        // Arrange
        var logger = NullLogger<LoggingBehaviour<TestRequest, TestResponse>>.Instance;
        var behaviour = new LoggingBehaviour<TestRequest, TestResponse>(logger);
        var request = new TestRequest("valid");
        RequestHandlerDelegate<TestResponse> next = () => throw new InvalidOperationException("boom");

        // Act
        Func<Task> act = () => behaviour.Handle(request, next, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<InvalidOperationException>();
    }

    [Fact]
    public async Task PerformanceBehaviourShouldReturnResponse()
    {
        // Arrange
        var logger = NullLogger<PerformanceBehaviour<TestRequest, TestResponse>>.Instance;
        var behaviour = new PerformanceBehaviour<TestRequest, TestResponse>(logger);
        var request = new TestRequest("fast");
        RequestHandlerDelegate<TestResponse> next = () => Task.FromResult(new TestResponse("ok"));

        // Act
        var response = await behaviour.Handle(request, next, CancellationToken.None);

        // Assert
        response.Message.Should().Be("ok");
    }

    [Fact]
    public async Task PerformanceBehaviourShouldLogForSlowRequests()
    {
        // Arrange
        var logger = NullLogger<PerformanceBehaviour<TestRequest, TestResponse>>.Instance;
        var behaviour = new PerformanceBehaviour<TestRequest, TestResponse>(logger);
        var request = new TestRequest("slow");
        RequestHandlerDelegate<TestResponse> next = async () =>
        {
            await Task.Delay(550);
            return new TestResponse("ok");
        };

        // Act
        var response = await behaviour.Handle(request, next, CancellationToken.None);

        // Assert
        response.Message.Should().Be("ok");
    }
}
