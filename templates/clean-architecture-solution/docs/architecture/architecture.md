# Architecture Overview

Related Stories: [Story ID]

## Context

This solution follows Clean Architecture with optional DDD/CQRS patterns. The goal is separation of concerns, testability, and clear boundaries.

## Layers

- Presentation: API endpoints, request/response models
- Application: use cases, orchestration, validation
- Domain: entities, value objects, domain events
- Infrastructure: persistence, external integrations

## Key Decisions

- Clean Architecture boundaries are enforced by tests
- Dependency inversion is used to keep the domain pure

