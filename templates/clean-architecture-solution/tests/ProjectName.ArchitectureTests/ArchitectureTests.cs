using FluentAssertions;
using NetArchTest.Rules;
using Xunit;

namespace ProjectName.ArchitectureTests;

public class ArchitectureTests
{
    private const string DomainNamespace = "ProjectName.Domain";
    private const string ApplicationNamespace = "ProjectName.Application";
    private const string InfrastructureNamespace = "ProjectName.Infrastructure";
    private const string ApiNamespace = "ProjectName.Api";

    [Fact]
    public void DomainShouldNotHaveDependencyOnOtherProjects()
    {
        // Arrange
        var assembly = typeof(Domain.AssemblyReference).Assembly;

        // Act
        var result = Types.InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAll(ApplicationNamespace, InfrastructureNamespace, ApiNamespace)
            .GetResult();

        // Assert
        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void ApplicationShouldNotHaveDependencyOnInfrastructureOrApi()
    {
        // Arrange
        var assembly = typeof(Application.AssemblyReference).Assembly;

        // Act
        var result = Types.InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAll(InfrastructureNamespace, ApiNamespace)
            .GetResult();

        // Assert
        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void HandlersShouldHaveDependencyOnDomain()
    {
        // Arrange
        var assembly = typeof(Application.AssemblyReference).Assembly;

        // Act
        var result = Types.InAssembly(assembly)
            .That()
            .HaveNameEndingWith("Handler")
            .Should()
            .HaveDependencyOn(DomainNamespace)
            .GetResult();

        // Assert
        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void ControllersShouldHaveDependencyOnMediatR()
    {
        // Arrange
        var assembly = typeof(Api.AssemblyReference).Assembly;

        // Act
        var result = Types.InAssembly(assembly)
            .That()
            .HaveNameEndingWith("Controller")
            .Should()
            .HaveDependencyOn("MediatR")
            .GetResult();

        // Assert
        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void DomainEntitiesShouldBeSealed()
    {
        // Arrange
        var assembly = typeof(Domain.AssemblyReference).Assembly;

        // Act
        var result = Types.InAssembly(assembly)
            .That()
            .ResideInNamespace("ProjectName.Domain.Entities")
            .Should()
            .BeSealed()
            .GetResult();

        // Assert
        result.IsSuccessful.Should().BeTrue();
    }
}
