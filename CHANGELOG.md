# Changelog

All notable changes to AI Coding Factory will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

---

## [1.0.2] - 2026-01-10

### Added
- Corporate R&D Development Policy with enforceable governance controls
- Policy artifact validation script (`scripts/validate-rnd-policy.sh`)
- Agent guardrails to enforce the Corporate R&D Policy across all roles

### Changed
- Documentation validation now includes the Corporate R&D Policy
- Azure Pipelines and GitHub Actions run the policy validation step

### Fixed
- GitHub Actions workflow indentation and execution order
- Documentation validation paths aligned to repo root

## [1.0.1] - 2026-01-09

### Added
- Enterprise governance, traceability model, and Scrum Team as Code documentation
- Traceability automation scripts and coverage enforcement checks
- Azure Pipelines and GitHub Actions CI entry points (platform-level)
- Template documentation skeletons for architecture, modules, API, and operations

### Changed
- Documentation updated to support GitHub or Azure DevOps workflows
- Security policy updated for GitHub Security Advisory reporting
- CONTRIBUTING updated for open-source GitHub workflows with Azure DevOps optional
- Architecture and README updated for OSS readiness

### Fixed
- CI validation now accepts either Azure Pipelines or GitHub Actions

## [1.0.0] - 2026-01-09

### Added

#### New Skills (4 skills)
- **net-cqrs** - CQRS pattern with MediatR, commands, queries, pipeline behaviors
- **net-kubernetes** - Kubernetes manifests, Helm charts, HPA, Pod Disruption Budgets
- **net-observability** - OpenTelemetry, Serilog, Prometheus metrics, health checks
- **net-scrum** - Scrum team structures, roles, ceremonies, scaling frameworks

#### Clean Architecture Solution Template
- Complete 4-layer .NET 8 solution template
- **Domain Layer**: Entity, AggregateRoot, ValueObject, DomainEvent base classes
- **Domain Layer**: Repository and UnitOfWork interfaces
- **Domain Layer**: Example value objects (Email, Money, Address)
- **Domain Layer**: Domain exceptions hierarchy
- **Application Layer**: MediatR pipeline behaviors (Validation, Logging, Performance)
- **Application Layer**: FluentValidation integration
- **Application Layer**: Service interfaces (ICurrentUserService, IDateTimeService)
- **Application Layer**: Application exceptions
- **Infrastructure Layer**: ApplicationDbContext with Unit of Work
- **Infrastructure Layer**: Generic repository implementation
- **Infrastructure Layer**: Service implementations
- **API Layer**: Program.cs with Serilog, Swagger, health checks
- **API Layer**: Global exception handling middleware (RFC 7807)
- **API Layer**: Security headers middleware
- **API Layer**: CORS and rate limiting configuration
- **Docker**: Multi-stage Dockerfile with security best practices
- **Docker**: docker-compose.yml with PostgreSQL, Redis, pgAdmin

#### Microservice Template
- Kubernetes-ready microservice template
- Deployment, Service, HPA manifests
- README with structure documentation

#### Agile Templates (5 new templates)
- Sprint retrospective template (Start/Stop/Continue format)
- Daily standup template with blocker tracking
- Sprint review template with demo agenda
- Burndown chart template with velocity tracking
- Epic breakdown template with story mapping

#### Role Playbooks (3 playbooks)
- **Product Owner Playbook** - Responsibilities, INVEST, MoSCoW, WSJF prioritization
- **Scrum Master Playbook** - Facilitation, coaching, retrospective formats
- **Developer Playbook** - Coding standards, testing practices, Git workflow

#### Documentation & Quality
- ADR (Architecture Decision Records) template
- Project validation script (`scripts/validate-project.sh`)

### Changed
- Updated all 5 agents to use GLM-4.7 model
- Removed Ollama references (using vLLM/LM Studio only)
- Fixed malformed `opencode.json` (removed duplicate sections, fixed JSON syntax)
- Updated README.md with professional formatting and badges
- Updated ARCHITECTURE.md with comprehensive system documentation
- Improved ASCII diagrams for consistency

### Fixed
- Critical JSON syntax error in `opencode.json` (duplicate configuration blocks)
- Empty microservice-template directory now has content
- Added `.gitkeep` to projects directory

---

## [0.0.1] - 2025-12-20

### Added
- Complete AI Coding Factory implementation
- 5 primary agents (Ideation, Prototype, PoC, Pilot, Product)
- 3 subagents (Security Auditor, Code Reviewer, Test Generator)
- 8 reusable skills for .NET patterns:
  - net-web-api
  - net-domain-model
  - net-repository-pattern
  - net-jwt-auth
  - net-testing
  - net-docker
  - net-github-actions
  - net-agile
- 3 custom plugins for enterprise integrations
- MCP server support (Azure DevOps, GitHub, SonarQube)
- Local AI inference support (vLLM, LM Studio)
- Comprehensive documentation (README, QUICKSTART, ARCHITECTURE, CONTRIBUTING)
- Automated setup script
- .gitignore for .NET and OpenCode
- MIT License

---

## Summary

### Current Version: 1.0.2

| Category | Count |
|----------|-------|
| Primary Agents | 5 |
| Subagents | 3 |
| Skills | 12 |
| Project Templates | 2 |
| Agile Templates | 10+ |
| Role Playbooks | 3 |

### Skills Available

| Skill | Version | Description |
|-------|---------|-------------|
| net-web-api | 1.0 | ASP.NET Core Web API scaffolding |
| net-domain-model | 1.0 | DDD entities, value objects, aggregates |
| net-repository-pattern | 1.0 | Repository with Unit of Work |
| net-jwt-auth | 1.0 | JWT authentication |
| net-testing | 1.0 | xUnit, Moq, FluentAssertions |
| net-docker | 1.0 | Multi-stage Dockerfile |
| net-github-actions | 1.0 | CI/CD pipelines |
| net-agile | 1.0 | Agile practices, templates |
| net-scrum | 1.1 | Scrum ceremonies, scaling |
| net-cqrs | 1.1 | CQRS with MediatR |
| net-kubernetes | 1.1 | K8s manifests, Helm |
| net-observability | 1.1 | Logging, tracing, metrics |

---

## Versioning Guidelines

### Major Version (X.0.0)
- Breaking changes to agent interfaces
- Major architectural changes
- Removal of deprecated skills or plugins
- New primary agent types

### Minor Version (x.Y.0)
- New skills or plugins added
- New agile templates
- Enhancements to existing agents
- Documentation improvements

### Patch Version (x.x.Y)
- Bug fixes
- Small improvements to existing features
- Documentation corrections
- Template updates

---

## Upgrade Guide

### From 1.0.0 to 1.1.0

1. **Update opencode.json** - If you have a customized config, ensure you're using the new model names (GLM-4.7)
2. **Review new skills** - Consider using net-cqrs, net-kubernetes, net-observability
3. **Use Clean Architecture template** - Copy from `templates/clean-architecture-solution/`
4. **Run validation** - Execute `./scripts/validate-project.sh` to verify setup
