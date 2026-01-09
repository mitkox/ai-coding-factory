---
name: net-web-api
description: Scaffold and configure ASP.NET Core Web API with best practices
license: MIT
compatibility: opencode
metadata:
  audience: .net-developers
  framework: aspnetcore
  version: "8.0"
---

## What I Do

I help you create production-ready ASP.NET Core Web API projects with:
- Clean architecture structure
- Proper dependency injection
- Swagger/OpenAPI documentation
- Global exception handling
- Request/response logging
- API versioning
- Health checks
- CORS configuration

## When to Use Me

Use this skill when:
- Creating a new Web API project
- Setting up API infrastructure
- Adding middleware and filters
- Configuring API best practices

## What I Create

**Project Structure:**
```
src/{ProjectName}.Api/
├── Controllers/
├── Filters/
│   ├── GlobalExceptionFilter.cs
│   ├── ValidationFilter.cs
│   └── ApiKeyFilter.cs
├── Middleware/
│   ├── RequestLoggingMiddleware.cs
│   └── ErrorHandlingMiddleware.cs
├── Extensions/
│   ├── ServiceCollectionExtensions.cs
│   └── ApplicationBuilderExtensions.cs
├── Models/
│   └── ErrorResponse.cs
├── Program.cs
└── appsettings.json
```

**Key Features:**
- `Program.cs` configured with:
  - Controllers and minimal APIs
  - Swagger/OpenAPI
  - Health checks
  - CORS
  - Global exception handling
  - Request validation
  - API versioning

- `GlobalExceptionFilter.cs` handles exceptions
- `ValidationFilter.cs` validates requests
- `RequestLoggingMiddleware.cs` logs requests/responses

## Best Practices I Follow

1. Use minimal APIs for simple endpoints
2. Implement proper HTTP status codes
3. Validate all inputs
4. Use DTOs for API models
5. Implement proper error responses
6. Add XML comments for Swagger
7. Configure health checks
8. Use API versioning from start

## Example Usage

```
Create a new ASP.NET Core Web API project with:
- Swagger/OpenAPI documentation
- Health checks endpoint
- Global exception handling
- Request validation
- API versioning
- CORS configuration
```

I will generate all necessary files following .NET 8 best practices.