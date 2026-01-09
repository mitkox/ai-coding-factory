# Deployment and Operations

Related Stories: [Story ID]

## Local Run

```bash
dotnet run --project src/{ProjectName}.Api
```

## Container Build

```bash
docker build -t {projectname}.api -f docker/Dockerfile .
```

## Health Checks

- `/health`
- `/health/ready`
- `/health/live`

