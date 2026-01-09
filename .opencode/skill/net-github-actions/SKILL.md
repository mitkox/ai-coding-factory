---
name: net-github-actions
description: Create GitHub Actions CI/CD pipelines for .NET applications
license: MIT
compatibility: opencode
metadata:
  audience: .net-developers
  cicd: github-actions
  framework: dotnet
---

## What I Do

I create complete CI/CD pipelines:
- Build and test workflows
- Docker image building
- Security scanning
- Code quality checks
- Automated deployments
- Multi-environment support

## When to Use Me

Use this skill when:
- Setting up CI/CD pipeline
- Automating build and test
- Implementing deployment workflows
- Adding quality gates

## CI/CD Workflows

### Build and Test Workflow
```yaml
name: Build and Test

on:
  push:
    branches: [ main, develop ]
  pull_request:
    branches: [ main ]

jobs:
  build:
    runs-on: ubuntu-latest

    steps:
    - name: Checkout code
      uses: actions/checkout@v4

    - name: Setup .NET
      uses: actions/setup-dotnet@v4
      with:
        dotnet-version: '8.0.x'

    - name: Restore dependencies
      run: dotnet restore

    - name: Build
      run: dotnet build --configuration Release --no-restore

    - name: Run unit tests
      run: dotnet test ./tests/ProjectName.UnitTests --configuration Release --no-build --verbosity normal --collect:"XPlat Code Coverage"

    - name: Run integration tests
      run: dotnet test ./tests/ProjectName.IntegrationTests --configuration Release --no-build --verbosity normal

    - name: Generate coverage report
      uses: danielpalme/ReportGenerator-GitHub-Action@v6
      with:
        reports: '**/coverage.cobertura.xml'
        targetdir: coveragereport

    - name: Upload coverage reports
      uses: actions/upload-artifact@v4
      with:
        name: coverage-report
        path: coveragereport/

    - name: Check coverage threshold
      run: |
        coverage=$(grep '<LineCoverage>' coveragereport/CoverageReport.xml | sed -E 's/<[^>]*>//g' | cut -d. -f1)
        if [ $coverage -lt 80 ]; then
          echo "Coverage below 80%: $coverage%"
          exit 1
        fi
```

### Security Scan Workflow
```yaml
name: Security Scan

on:
  push:
    branches: [ main ]
  schedule:
    - cron: '0 0 * * 0'  # Weekly

jobs:
  security:
    runs-on: ubuntu-latest

    steps:
    - name: Checkout code
      uses: actions/checkout@v4

    - name: Run NuGet vulnerability scan
      run: dotnet list package --vulnerable

    - name: Run OWASP Dependency Check
      uses: dependency-check/Dependency-Check_Action@main
      with:
        project: '.'
        path: '.'
        format: 'HTML'

    - name: Upload security report
      uses: actions/upload-artifact@v4
      with:
        name: security-report
        path: reports/
```

### Build and Push Docker Image
```yaml
name: Build and Push Docker Image

on:
  push:
    branches: [ main ]
    tags:
      - 'v*'

jobs:
  build-and-push:
    runs-on: ubuntu-latest

    steps:
    - name: Checkout code
      uses: actions/checkout@v4

    - name: Set up Docker Buildx
      uses: docker/setup-buildx-action@v3

    - name: Log in to Container Registry
      uses: docker/login-action@v3
      with:
        registry: ghcr.io
        username: ${{ github.actor }}
        password: ${{ secrets.GITHUB_TOKEN }}

    - name: Extract metadata
      id: meta
      uses: docker/metadata-action@v5
      with:
        images: ghcr.io/${{ github.repository }}
        tags: |
          type=ref,event=branch
          type=semver,pattern={{version}}
          type=semver,pattern={{major}}.{{minor}}

    - name: Build and push
      uses: docker/build-push-action@v5
      with:
        context: .
        push: true
        tags: ${{ steps.meta.outputs.tags }}
        labels: ${{ steps.meta.outputs.labels }}
        cache-from: type=registry,ref=ghcr.io/${{ github.repository }}:buildcache
        cache-to: type=registry,ref=ghcr.io/${{ github.repository }}:buildcache,mode=max
```

### Deploy to Staging
```yaml
name: Deploy to Staging

on:
  push:
    branches: [ main ]

jobs:
  deploy:
    runs-on: ubuntu-latest
    environment:
      name: staging
      url: https://staging.example.com

    steps:
    - name: Checkout code
      uses: actions/checkout@v4

    - name: Deploy to staging
      uses: azure/webapps-deploy@v3
      with:
        app-name: 'your-app-name-staging'
        publish-profile: ${{ secrets.AZURE_WEBAPP_PUBLISH_PROFILE_STAGING }}
        images: 'ghcr.io/${{ github.repository }}:latest'

    - name: Health check
      run: |
        for i in {1..10}; do
          if curl -f https://staging.example.com/health; then
            echo "Health check passed"
            exit 0
          fi
          echo "Retry $i/10"
          sleep 10
        done
        echo "Health check failed"
        exit 1
```

### Deploy to Production
```yaml
name: Deploy to Production

on:
  push:
    tags:
      - 'v*'

jobs:
  deploy:
    runs-on: ubuntu-latest
    environment:
      name: production
      url: https://example.com

    steps:
    - name: Checkout code
      uses: actions/checkout@v4

    - name: Create release
      uses: actions/create-release@v1
      env:
        GITHUB_TOKEN: ${{ secrets.GITHUB_TOKEN }}
      with:
        tag_name: ${{ github.ref }}
        release_name: Release ${{ github.ref }}

    - name: Deploy to production
      uses: azure/webapps-deploy@v3
      with:
        app-name: 'your-app-name-prod'
        publish-profile: ${{ secrets.AZURE_WEBAPP_PUBLISH_PROFILE_PROD }}
        images: 'ghcr.io/${{ github.repository }}:${{ github.ref_name }}'

    - name: Run E2E tests
      run: |
        dotnet test ./tests/ProjectName.E2ETests --configuration Release

    - name: Notify team
      uses: 8398a7/action-slack@v3
      with:
        status: ${{ job.status }}
        webhook_url: ${{ secrets.SLACK_WEBHOOK }}
```

## Best Practices

1. Use matrix strategy for multiple configurations
2. Cache dependencies for faster builds
3. Use secrets for sensitive data
4. Deploy to staging before production
5. Require approval for production deployment
6. Run security scans on every build
7. Use semantic versioning for releases
8. Rollback on failed deployment

## Required Secrets

```bash
# GitHub Secrets
GITHUB_TOKEN
AZURE_WEBAPP_PUBLISH_PROFILE_STAGING
AZURE_WEBAPP_PUBLISH_PROFILE_PROD
SLACK_WEBHOOK
SONARQUBE_TOKEN
```

## Example Usage

```
Create GitHub Actions workflows for:
- Build and test (unit + integration)
- Security scanning (NuGet, OWASP)
- Docker image build and push
- Deploy to staging
- Deploy to production (with approval)
```

I will generate complete CI/CD pipelines.