---
name: net-kubernetes
description: Generate Kubernetes manifests and Helm charts for .NET applications
license: MIT
compatibility: opencode
metadata:
  audience: .net-developers
  framework: kubernetes
  patterns: helm, kustomize
---

## What I Do

I help you deploy .NET applications to Kubernetes:
- Kubernetes deployment manifests
- Helm charts for templating
- ConfigMaps and Secrets management
- Service and Ingress configuration
- Horizontal Pod Autoscaler (HPA)
- Pod Disruption Budgets (PDB)
- Resource limits and requests
- Readiness and liveness probes

## When to Use Me

Use this skill when:
- Deploying .NET applications to Kubernetes
- Creating Helm charts for applications
- Configuring auto-scaling
- Setting up ingress and load balancing
- Managing configuration in Kubernetes

## Kubernetes Manifests

### Deployment
```yaml
apiVersion: apps/v1
kind: Deployment
metadata:
  name: {{ .Release.Name }}-api
  labels:
    app: {{ .Release.Name }}
    component: api
spec:
  replicas: {{ .Values.replicaCount }}
  selector:
    matchLabels:
      app: {{ .Release.Name }}
      component: api
  template:
    metadata:
      labels:
        app: {{ .Release.Name }}
        component: api
      annotations:
        prometheus.io/scrape: "true"
        prometheus.io/port: "80"
        prometheus.io/path: "/metrics"
    spec:
      serviceAccountName: {{ .Release.Name }}
      securityContext:
        runAsNonRoot: true
        runAsUser: 1000
        fsGroup: 2000
      containers:
        - name: api
          image: "{{ .Values.image.repository }}:{{ .Values.image.tag }}"
          imagePullPolicy: {{ .Values.image.pullPolicy }}
          ports:
            - name: http
              containerPort: 80
              protocol: TCP
          env:
            - name: ASPNETCORE_ENVIRONMENT
              value: "{{ .Values.environment }}"
            - name: ConnectionStrings__DefaultConnection
              valueFrom:
                secretKeyRef:
                  name: {{ .Release.Name }}-secrets
                  key: database-connection-string
          resources:
            limits:
              cpu: {{ .Values.resources.limits.cpu }}
              memory: {{ .Values.resources.limits.memory }}
            requests:
              cpu: {{ .Values.resources.requests.cpu }}
              memory: {{ .Values.resources.requests.memory }}
          livenessProbe:
            httpGet:
              path: /health/live
              port: http
            initialDelaySeconds: 10
            periodSeconds: 15
            timeoutSeconds: 5
            failureThreshold: 3
          readinessProbe:
            httpGet:
              path: /health/ready
              port: http
            initialDelaySeconds: 5
            periodSeconds: 10
            timeoutSeconds: 5
            failureThreshold: 3
          securityContext:
            allowPrivilegeEscalation: false
            readOnlyRootFilesystem: true
            capabilities:
              drop:
                - ALL
```

### Service
```yaml
apiVersion: v1
kind: Service
metadata:
  name: {{ .Release.Name }}-api
  labels:
    app: {{ .Release.Name }}
spec:
  type: ClusterIP
  ports:
    - port: 80
      targetPort: http
      protocol: TCP
      name: http
  selector:
    app: {{ .Release.Name }}
    component: api
```

### Ingress
```yaml
apiVersion: networking.k8s.io/v1
kind: Ingress
metadata:
  name: {{ .Release.Name }}-ingress
  annotations:
    kubernetes.io/ingress.class: nginx
    cert-manager.io/cluster-issuer: letsencrypt-prod
    nginx.ingress.kubernetes.io/ssl-redirect: "true"
spec:
  tls:
    - hosts:
        - {{ .Values.ingress.host }}
      secretName: {{ .Release.Name }}-tls
  rules:
    - host: {{ .Values.ingress.host }}
      http:
        paths:
          - path: /
            pathType: Prefix
            backend:
              service:
                name: {{ .Release.Name }}-api
                port:
                  number: 80
```

### Horizontal Pod Autoscaler
```yaml
apiVersion: autoscaling/v2
kind: HorizontalPodAutoscaler
metadata:
  name: {{ .Release.Name }}-api-hpa
spec:
  scaleTargetRef:
    apiVersion: apps/v1
    kind: Deployment
    name: {{ .Release.Name }}-api
  minReplicas: {{ .Values.autoscaling.minReplicas }}
  maxReplicas: {{ .Values.autoscaling.maxReplicas }}
  metrics:
    - type: Resource
      resource:
        name: cpu
        target:
          type: Utilization
          averageUtilization: {{ .Values.autoscaling.targetCPUUtilization }}
    - type: Resource
      resource:
        name: memory
        target:
          type: Utilization
          averageUtilization: {{ .Values.autoscaling.targetMemoryUtilization }}
```

### Pod Disruption Budget
```yaml
apiVersion: policy/v1
kind: PodDisruptionBudget
metadata:
  name: {{ .Release.Name }}-api-pdb
spec:
  minAvailable: 1
  selector:
    matchLabels:
      app: {{ .Release.Name }}
      component: api
```

### ConfigMap
```yaml
apiVersion: v1
kind: ConfigMap
metadata:
  name: {{ .Release.Name }}-config
data:
  appsettings.Kubernetes.json: |
    {
      "Logging": {
        "LogLevel": {
          "Default": "Information"
        }
      },
      "Cors": {
        "AllowedOrigins": ["{{ .Values.cors.allowedOrigins }}"]
      }
    }
```

### Secret
```yaml
apiVersion: v1
kind: Secret
metadata:
  name: {{ .Release.Name }}-secrets
type: Opaque
stringData:
  database-connection-string: "{{ .Values.database.connectionString }}"
  jwt-secret: "{{ .Values.jwt.secret }}"
```

## Helm Values

```yaml
# values.yaml
replicaCount: 2

image:
  repository: your-registry/your-app
  tag: latest
  pullPolicy: IfNotPresent

environment: Production

resources:
  limits:
    cpu: 500m
    memory: 512Mi
  requests:
    cpu: 100m
    memory: 256Mi

autoscaling:
  enabled: true
  minReplicas: 2
  maxReplicas: 10
  targetCPUUtilization: 70
  targetMemoryUtilization: 80

ingress:
  enabled: true
  host: api.example.com

database:
  connectionString: "Host=postgres;Database=app;Username=user;Password=pass"

jwt:
  secret: "your-jwt-secret"

cors:
  allowedOrigins: "https://example.com"
```

## Best Practices

1. **Resource Limits**: Always set CPU and memory limits
2. **Health Probes**: Configure liveness and readiness probes
3. **Security Context**: Run as non-root, drop capabilities
4. **Secrets Management**: Use external secrets operator or sealed secrets
5. **Pod Disruption Budget**: Ensure high availability during updates
6. **Horizontal Pod Autoscaler**: Scale based on CPU and memory
7. **Network Policies**: Restrict pod-to-pod communication

## Example Usage

```
Use net-kubernetes skill to:

1. Generate Kubernetes deployment manifests
2. Create Helm chart for the application
3. Configure auto-scaling with HPA
4. Set up ingress with TLS
5. Create ConfigMaps and Secrets
```

I will generate complete Kubernetes manifests following cloud-native best practices.
