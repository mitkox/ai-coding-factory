# Testing Strategy

## Goals

- Protect critical business logic
- Enforce coverage thresholds for domain and application layers
- Validate infrastructure and deployment readiness
- Make tests traceable to stories

## Test Pyramid

1. **Unit Tests** (Domain + Application)
2. **Integration Tests** (API, database, external services)
3. **Smoke Tests** (containers, Kubernetes)

## Coverage Requirements

- Domain and Application layers:
  - Line coverage >= 80%
  - Branch coverage >= 80%

Coverage is enforced by `scripts/coverage/check-coverage.py`.

## Test Requirements

- Every story has at least one automated test
- Tests must include story ID metadata (see traceability model)
- Integration tests required for API endpoints and infrastructure changes
- Smoke tests required for container and Kubernetes output

## Tooling

- xUnit + FluentAssertions for tests
- Coverlet (collector) for coverage data
- Traceability validation scripts in `scripts/traceability`
- Azure Pipelines or GitHub Actions runs quality gates by default

## Templates

- xUnit traceability template: `.opencode/templates/testing/xunit-story-test-template.cs`
- User story template: `.opencode/templates/agile/user-story-template.md`
