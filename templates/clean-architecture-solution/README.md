# Clean Architecture Solution Template

A production-ready .NET 8 Clean Architecture solution template for enterprise applications.

## Architecture Overview

```
┌─────────────────────────────────────────────────────────────────────────────┐
│                              Presentation Layer                              │
│                           {ProjectName}.Api                                  │
│                    (Controllers, Middleware, Filters)                        │
└─────────────────────────────────────────────────────────────────────────────┘
                                    │
                                    ▼
┌─────────────────────────────────────────────────────────────────────────────┐
│                              Application Layer                               │
│                        {ProjectName}.Application                             │
│               (Commands, Queries, DTOs, Validators, Services)                │
└─────────────────────────────────────────────────────────────────────────────┘
                                    │
                                    ▼
┌─────────────────────────────────────────────────────────────────────────────┐
│                               Domain Layer                                   │
│                          {ProjectName}.Domain                                │
│              (Entities, Value Objects, Aggregates, Domain Events)            │
└─────────────────────────────────────────────────────────────────────────────┘
                                    ▲
                                    │
┌─────────────────────────────────────────────────────────────────────────────┐
│                            Infrastructure Layer                              │
│                       {ProjectName}.Infrastructure                           │
│           (DbContext, Repositories, External Services, Caching)              │
└─────────────────────────────────────────────────────────────────────────────┘
```

## Project Structure

```
{ProjectName}/
├── src/
│   ├── {ProjectName}.Api/
│   │   ├── Controllers/
│   │   ├── Filters/
│   │   ├── Middleware/
│   │   ├── Extensions/
│   │   ├── Models/
│   │   ├── Properties/
│   │   ├── Program.cs
│   │   ├── appsettings.json
│   │   ├── appsettings.Development.json
│   │   └── {ProjectName}.Api.csproj
│   ├── {ProjectName}.Application/
│   │   ├── Common/
│   │   │   ├── Behaviours/
│   │   │   ├── Exceptions/
│   │   │   ├── Interfaces/
│   │   │   └── Mappings/
│   │   ├── Commands/
│   │   ├── Queries/
│   │   ├── DTOs/
│   │   ├── Services/
│   │   ├── Validators/
│   │   ├── DependencyInjection.cs
│   │   └── {ProjectName}.Application.csproj
│   ├── {ProjectName}.Domain/
│   │   ├── Common/
│   │   ├── Entities/
│   │   ├── ValueObjects/
│   │   ├── Aggregates/
│   │   ├── Events/
│   │   ├── Interfaces/
│   │   ├── Exceptions/
│   │   └── {ProjectName}.Domain.csproj
│   └── {ProjectName}.Infrastructure/
│       ├── Data/
│       │   ├── DbContext/
│       │   ├── Configurations/
│       │   ├── Repositories/
│       │   ├── Migrations/
│       │   └── Seeding/
│       ├── Security/
│       ├── Services/
│       ├── Caching/
│       ├── DependencyInjection.cs
│       └── {ProjectName}.Infrastructure.csproj
├── tests/
│   ├── {ProjectName}.UnitTests/
│   │   ├── Domain/
│   │   ├── Application/
│   │   └── {ProjectName}.UnitTests.csproj
│   ├── {ProjectName}.IntegrationTests/
│   │   ├── Api/
│   │   ├── Fixtures/
│   │   └── {ProjectName}.IntegrationTests.csproj
│   └── {ProjectName}.ArchitectureTests/
│       └── {ProjectName}.ArchitectureTests.csproj
├── docker/
│   ├── Dockerfile
│   └── docker-compose.yml
├── docs/
│   ├── architecture/
│   ├── modules/
│   ├── api/
│   └── operations/
├── azure-pipelines.yml
├── {ProjectName}.sln
├── Directory.Build.props
├── Directory.Packages.props
├── .editorconfig
├── .env.example
├── .gitignore
└── README.md
```

## Quick Start

### Creating a New Project

1. **Copy this template** to your projects directory:
   ```bash
   cp -r templates/clean-architecture-solution projects/{your-project-name}
   cd projects/{your-project-name}
   ```

2. **Rename placeholders**:
   ```bash
   # Replace {ProjectName} with your actual project name
   find . -type f -name "*.cs" -exec sed -i '' 's/{ProjectName}/YourProject/g' {} +
   find . -type f -name "*.csproj" -exec sed -i '' 's/{ProjectName}/YourProject/g' {} +
   find . -type f -name "*.sln" -exec sed -i '' 's/{ProjectName}/YourProject/g' {} +
   ```

3. **Restore and build**:
   ```bash
   dotnet restore
   dotnet build
   ```

4. **Run tests**:
   ```bash
   dotnet test
   ```

5. **Run the application**:
   ```bash
   cd src/{ProjectName}.Api
   dotnet run
   ```

## Traceability

- Add a story ID (`ACF-###`) to tests using `Trait("Story", "ACF-###")`.
- Ensure commit messages include the story ID.

## Documentation

- Update `docs/architecture/architecture.md` when architecture changes
- Update `docs/modules/modules.md` when dependencies change
- Update `docs/api/openapi.md` for API changes
- Update `docs/operations/deployment.md` for deployment changes

## Layer Dependencies

- **Domain**: No dependencies (core business logic)
- **Application**: Depends on Domain
- **Infrastructure**: Depends on Domain and Application
- **Api**: Depends on Application and Infrastructure

## Key Patterns Used

### Domain Layer
- **Entity**: Objects with identity and lifecycle
- **Value Objects**: Immutable objects compared by value
- **Aggregates**: Consistency boundaries with aggregate roots
- **Domain Events**: Capture and communicate domain changes
- **Repository Interfaces**: Data access abstractions

### Application Layer
- **CQRS**: Commands and Queries with MediatR
- **DTOs**: Data transfer objects for API communication
- **Validators**: FluentValidation for input validation
- **Behaviours**: Cross-cutting concerns (logging, validation, transactions)

### Infrastructure Layer
- **Repository Pattern**: Data access implementation
- **Unit of Work**: Transaction management
- **External Services**: Third-party integrations
- **Caching**: Distributed caching with Redis

### API Layer
- **Controllers**: RESTful API endpoints
- **Filters**: Exception handling, validation, authentication
- **Middleware**: Logging, correlation IDs, error handling

## Technology Stack

| Component | Technology |
|-----------|------------|
| Framework | .NET 8 |
| API | ASP.NET Core Minimal/Controllers |
| ORM | Entity Framework Core 8 |
| Database | PostgreSQL / SQL Server |
| Validation | FluentValidation |
| Mapping | AutoMapper |
| CQRS | MediatR |
| Logging | Serilog |
| Testing | xUnit, Moq, FluentAssertions |
| Containers | Docker |
| CI/CD | Azure Pipelines (included), GitHub Actions (optional) |

## Configuration

### appsettings.json
Secrets must be supplied via environment variables or user secrets. The default file ships without passwords.
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database={ProjectName};Username=postgres;Password="
  },
  "Jwt": {
    "Secret": "",
    "Issuer": "ProjectName",
    "Audience": "ProjectName",
    "ExpiryMinutes": 60
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }
}
```

Recommended environment overrides:
- `ConnectionStrings__DefaultConnection`
- `Jwt__Secret`

## Docker Support

### Build and run with Docker:
```bash
cp .env.example .env
# set POSTGRES_PASSWORD (and optional PGADMIN_DEFAULT_PASSWORD, JWT__Secret)
docker-compose up --build
```

### Services:
- **api**: ASP.NET Core application (port 5000)
- **db**: PostgreSQL database (port 5432)
- **redis**: Redis cache (port 6379)

## Testing Strategy

| Test Type | Coverage Target | Location |
|-----------|----------------|----------|
| Unit Tests | >80% | `tests/{ProjectName}.UnitTests` |
| Integration Tests | Critical paths | `tests/{ProjectName}.IntegrationTests` |
| Architecture Tests | Dependencies | `tests/{ProjectName}.ArchitectureTests` |

## CI/CD Pipeline

The solution includes `azure-pipelines.yml` by default. If you prefer GitHub Actions, add workflows under `.github/workflows/` using the same steps:

1. **Build**: Restore and build on every push
2. **Test**: Run tests with coverage collection
3. **Publish**: Extend with deployment stages as needed

## Enterprise Features

- [x] Clean Architecture structure
- [x] CQRS with MediatR
- [x] Domain-Driven Design patterns
- [x] Repository pattern
- [x] Unit of Work
- [x] JWT Authentication
- [x] Role-based Authorization
- [x] FluentValidation
- [x] AutoMapper
- [x] Serilog logging
- [x] Health checks
- [x] Swagger/OpenAPI
- [x] Docker support
- [x] Azure Pipelines CI/CD
- [x] Unit testing
- [x] Integration testing
- [x] Architecture tests

## License

MIT License - see LICENSE file for details.
