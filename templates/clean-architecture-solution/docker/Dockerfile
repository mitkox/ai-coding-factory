# Build artifacts
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj files and restore
COPY ["src/Api/ProjectName.Api.csproj", "src/Api/"]
COPY ["src/Application/ProjectName.Application.csproj", "src/Application/"]
COPY ["src/Domain/ProjectName.Domain.csproj", "src/Domain/"]
COPY ["src/Infrastructure/ProjectName.Infrastructure.csproj", "src/Infrastructure/"]
COPY ["Directory.Build.props", "."]

RUN dotnet restore "src/Api/ProjectName.Api.csproj"

# Copy everything else and build
COPY . .
WORKDIR "/src/src/Api"
RUN dotnet build "ProjectName.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProjectName.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Create non-root user
RUN adduser --disabled-password --gecos '' appuser && chown -R appuser /app
USER appuser

# Health check
HEALTHCHECK --interval=30s --timeout=3s --start-period=5s --retries=3 \
  CMD curl --fail http://localhost:80/health || exit 1

ENTRYPOINT ["dotnet", "ProjectName.Api.dll"]
