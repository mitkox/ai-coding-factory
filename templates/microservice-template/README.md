# Microservice Template

A production-ready .NET 8 microservice template with Kubernetes deployment support.

## Structure

```
{ServiceName}/
├── src/
│   └── {ServiceName}.Api/
│       ├── Controllers/
│       ├── Services/
│       ├── Models/
│       ├── Program.cs
│       ├── appsettings.json
│       └── {ServiceName}.Api.csproj
├── tests/
│   └── {ServiceName}.UnitTests/
├── docker/
│   ├── Dockerfile
│   └── docker-compose.yml
├── k8s/
│   ├── deployment.yaml
│   ├── service.yaml
│   ├── configmap.yaml
│   ├── secret.yaml
│   ├── hpa.yaml
│   └── ingress.yaml
├── helm/
│   └── {servicename}/
│       ├── Chart.yaml
│       ├── values.yaml
│       └── templates/
├── azure-pipelines.yml
├── docs/
│   ├── architecture/
│   ├── modules/
│   ├── api/
│   └── operations/
└── README.md
```

## Quick Start

1. Copy this template to your projects directory
2. Replace `{ServiceName}` with your service name
3. Run `dotnet restore && dotnet build`
4. Deploy with `kubectl apply -f k8s/` or `helm install`

## Features

- Minimal API or Controllers (configurable)
- Health checks (liveness + readiness)
- OpenTelemetry integration
- Prometheus metrics
- Serilog structured logging
- Docker multi-stage build
- Kubernetes manifests
- Helm chart for templating
- Horizontal Pod Autoscaler
- Azure Pipelines CI file included
- GitHub Actions supported (add workflows if needed)

## Traceability

- Add a story ID (`ACF-###`) to tests using `Trait("Story", "ACF-###")` or a structured comment header.
- Ensure commit messages include the story ID.

## Kubernetes Deployment

```bash
# Apply manifests directly
kubectl apply -f k8s/

# Or use Helm
helm install my-service helm/servicename/
```

## Configuration

Environment variables are managed via ConfigMap and Secret:

| Variable | Description | Default |
|----------|-------------|---------|
| ASPNETCORE_ENVIRONMENT | Environment name | Production |
| ConnectionStrings__DefaultConnection | Database connection | - |
| Jwt__Secret | JWT signing key | - |

## Health Checks

| Endpoint | Purpose |
|----------|---------|
| `/health` | Overall health status |
| `/health/live` | Kubernetes liveness probe |
| `/health/ready` | Kubernetes readiness probe |

## Metrics

Prometheus metrics exposed at `/metrics`:
- `http_requests_total` - Request count
- `http_request_duration_seconds` - Request latency
- Custom business metrics

## License

MIT License - see LICENSE file for details.
