using System.Net;
using FluentAssertions;
using ProjectName.IntegrationTests.Fixtures;
using Xunit;

namespace ProjectName.IntegrationTests.Api;

[Trait("Story", "ACF-0001")]
public class HealthCheckTests : IClassFixture<WebApplicationFactoryFixture>
{
    private readonly HttpClient _client;

    public HealthCheckTests(WebApplicationFactoryFixture factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task HealthEndpointReturnsHealthy()
    {
        // Act
        var response = await _client.GetAsync("/health");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var content = await response.Content.ReadAsStringAsync();
        content.Should().Contain("Healthy");
    }

    [Fact]
    public async Task HealthReadyEndpointReturnsHealthy()
    {
        // Act
        var response = await _client.GetAsync("/health/ready");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task HealthLiveEndpointReturnsHealthy()
    {
        // Act
        var response = await _client.GetAsync("/health/live");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}
