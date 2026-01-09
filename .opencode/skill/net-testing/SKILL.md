---
name: net-testing
description: Set up comprehensive testing framework with xUnit, Moq, and TestContainers
license: MIT
compatibility: opencode
metadata:
  audience: .net-developers
  framework: xunit
  tools: moq, testcontainers, coverlet
---

## What I Do

I set up complete testing framework:
- xUnit test projects
- Moq for mocking
- TestContainers for integration tests
- Coverlet for code coverage
- FluentAssertions for readable asserts
- AutoFixture for test data

## When to Use Me

Use this skill when:
- Setting up test infrastructure
- Creating test projects
- Adding test utilities
- Configuring code coverage

## Test Project Structure

```
tests/
├── {ProjectName}.UnitTests/
│   ├── Domain/
│   │   ├── ProductTests.cs
│   │   └── ValueObjectTests.cs
│   ├── Application/
│   │   ├── ServiceTests.cs
│   │   └── HandlerTests.cs
│   └── Infrastructure/
│       └── RepositoryTests.cs
├── {ProjectName}.IntegrationTests/
│   ├── Api/
│   │   └── ProductControllerTests.cs
│   └── Database/
│       └── DatabaseTests.cs
└── {ProjectName}.E2ETests/
    └── UserFlowTests.cs

Common/
├── TestDataBuilders/
├── Fakes/
└── TestHelpers.cs
```

## Test Setup

### Packages to Install
```xml
<PackageReference Include="xunit" Version="2.6.0" />
<PackageReference Include="xunit.runner.visualstudio" Version="2.5.0">
  <PrivateAssets>all</PrivateAssets>
  <IncludeAssets>runtime; build; native; contentfiles; analyzers</IncludeAssets>
</PackageReference>
<PackageReference Include="Moq" Version="4.20.0" />
<PackageReference Include="FluentAssertions" Version="6.12.0" />
<PackageReference Include="AutoFixture" Version="4.18.0" />
<PackageReference Include="Testcontainers" Version="3.5.0" />
<PackageReference Include="Microsoft.EntityFrameworkCore.InMemory" Version="8.0.0" />
<PackageReference Include="coverlet.collector" Version="6.0.0">
  <PrivateAssets>all</PrivateAssets>
  <IncludeAssets>runtime; build; native; contentfiles; analyzers</IncludeAssets>
</PackageReference>
```

### Unit Test Template
```csharp
public class ProductServiceTests
{
    private readonly Mock<IProductRepository> _mockRepo;
    private readonly ProductService _service;

    public ProductServiceTests()
    {
        _mockRepo = new Mock<IProductRepository>();
        _service = new ProductService(_mockRepo.Object);
    }

    [Fact]
    public async Task GetProductById_WhenProductExists_ReturnsProduct()
    {
        // Arrange
        var productId = Guid.NewGuid();
        var expectedProduct = new Product { Id = productId, Name = "Test" };
        _mockRepo.Setup(r => r.GetByIdAsync(productId))
               .ReturnsAsync(expectedProduct);

        // Act
        var result = await _service.GetProductByIdAsync(productId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(expectedProduct);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public async Task CreateProduct_WhenNameInvalid_ThrowsException(string name)
    {
        // Arrange
        var request = new CreateProductRequest { Name = name, Price = 10 };

        // Act
        Func<Task> act = () => _service.CreateProductAsync(request);

        // Assert
        await act.Should().ThrowAsync<ValidationException>();
    }
}
```

### Integration Test with TestContainers
```csharp
public class ProductControllerTests : IClassFixture<ApiTestFixture>
{
    private readonly HttpClient _client;

    public ProductControllerTests(ApiTestFixture fixture)
    {
        _client = fixture.Client;
    }

    [Fact]
    [Trait("Category", "Integration")]
    public async Task GetProducts_ReturnsOk()
    {
        // Act
        var response = await _client.GetAsync("/api/products");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}

public class ApiTestFixture : IAsyncLifetime
{
    public HttpClient Client { get; private set; }
    private readonly TestcontainersContainer _container;

    public ApiTestFixture()
    {
        _container = new TestcontainersBuilder<PostgreSqlTestcontainer>()
            .WithDatabase("testdb")
            .WithUsername("test")
            .WithPassword("test")
            .Build();
    }

    public async Task InitializeAsync()
    {
        await _container.StartAsync();
        var webHost = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    // Replace DB connection
                });
            });
        Client = webHost.CreateClient();
    }

    public async Task DisposeAsync()
    {
        await _container.StopAsync();
    }
}
```

### Code Coverage Configuration
```xml
<CollectCoverage>true</CollectCoverage>
<CoverletOutputFormat>opencover</CoverletOutputFormat>
<CoverageThreshold>80</CoverageThreshold>
```

## Best Practices

1. Test behavior, not implementation
2. Use descriptive test names
3. Follow AAA pattern
4. Test edge cases
5. Use FluentAssertions for readability
6. Use AutoFixture for test data
7. Use TestContainers for integration tests
8. Aim for >80% code coverage

## Example Usage

```
Set up test framework for:
- Unit tests with xUnit and Moq
- Integration tests with TestContainers
- Code coverage with Coverlet
- Test data builders
- Test helpers and utilities
```

I will generate complete test infrastructure.