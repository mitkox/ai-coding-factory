---
name: net-docker
description: Create Docker configuration for ASP.NET Core applications
license: MIT
compatibility: opencode
metadata:
  audience: .net-developers
  containers: docker
  orchestration: docker-compose
---

## What I Do

I create Docker configuration for .NET apps:
- Multi-stage Dockerfile
- docker-compose for local development
- Production-ready configuration
- Health checks
- Volume mounts
- Environment variables

## When to Use Me

Use this skill when:
- Containerizing .NET application
- Setting up local development environment
- Preparing for deployment
- Creating container orchestration

## Docker Files

### Multi-stage Dockerfile
```dockerfile
# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/ProjectName.Api/ProjectName.Api.csproj", "ProjectName.Api/"]
COPY ["src/ProjectName.Application/ProjectName.Application.csproj", "ProjectName.Application/"]
COPY ["src/ProjectName.Domain/ProjectName.Domain.csproj", "ProjectName.Domain/"]
COPY ["src/ProjectName.Infrastructure/ProjectName.Infrastructure.csproj", "ProjectName.Infrastructure/"]
RUN dotnet restore "ProjectName.Api/ProjectName.Api.csproj"
COPY . .
WORKDIR "/src/ProjectName.Api"
RUN dotnet build "ProjectName.Api.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "ProjectName.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 80
EXPOSE 443
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProjectName.Api.dll"]
HEALTHCHECK --interval=30s --timeout=3s \
  CMD curl -f http://localhost/health || exit 1
```

### Docker Compose
```yaml
version: '3.8'

services:
  api:
    build:
      context: .
      dockerfile: Dockerfile
    ports:
      - "5000:80"
      - "5001:443"
    environment:
      - ASPNETCORE_ENVIRONMENT=Development
      - ConnectionStrings__DefaultConnection=Host=db;Database=appdb;Username=app;Password=app
      - JwtSettings__Secret=your-secret-key
    depends_on:
      db:
        condition: service_healthy
    volumes:
      - ./src/ProjectName.Api/appsettings.Development.json:/app/appsettings.Development.json
    networks:
      - app-network

  db:
    image: postgres:15-alpine
    environment:
      - POSTGRES_DB=appdb
      - POSTGRES_USER=app
      - POSTGRES_PASSWORD=app
    ports:
      - "5432:5432"
    volumes:
      - postgres-data:/var/lib/postgresql/data
    healthcheck:
      test: ["CMD-SHELL", "pg_isready -U app"]
      interval: 10s
      timeout: 5s
      retries: 5
    networks:
      - app-network

  redis:
    image: redis:7-alpine
    ports:
      - "6379:6379"
    volumes:
      - redis-data:/data
    networks:
      - app-network

volumes:
  postgres-data:
  redis-data:

networks:
  app-network:
    driver: bridge
```

### Dockerignore
```
**/bin/
**/obj/
**/out/
**/.vs/
**/TestResults/
**/*.user
**/*.suo
**/*.cache
**/*.log
**/.vscode/
**/*.md
.git/
.gitignore
docker-compose*.yml
Dockerfile*
```

## Best Practices

1. Use multi-stage builds for smaller images
2. Use specific version tags (not `latest`)
3. Don't run as root (create non-root user)
4. Implement health checks
5. Use environment variables for configuration
6. Use volumes for persistence
7. Use networks for service communication
8. Optimize layer caching

## Production Considerations

1. Use Alpine images for smaller size
2. Scan images for vulnerabilities
3. Sign images for security
4. Use secrets management (not env vars in prod)
5. Implement resource limits
6. Use orchestration (Kubernetes)
7. Configure logging driver
8. Set up monitoring

## Example Usage

```
Create Docker configuration with:
- Multi-stage Dockerfile
- docker-compose for local dev
- PostgreSQL database
- Redis cache
- Health checks
- Volume mounts
```

I will generate complete Docker configuration.