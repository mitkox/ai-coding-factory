# Deployment and Operations

Related Stories: [Story ID]

## Container Build

```bash
docker build -t {servicename}.api -f docker/Dockerfile .
```

## Kubernetes Deploy

```bash
kubectl apply -f k8s/
```

