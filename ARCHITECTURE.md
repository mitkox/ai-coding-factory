# AI Coding Factory - Architecture & Design

## Overview

AI Coding Factory is built on a **multi-agent orchestration model** where specialized OpenCode agents handle different stages of the software development lifecycle. This document describes the system architecture, design decisions, and integration patterns.

---

## System Architecture

```
┌──────────────────────────────────────────────────────────────────────────────────────────┐
│                                   OpenCode Platform                                      │
│                              (Agent Orchestration Layer)                                 │
└──────────────────────────────────────────────────────────────────────────────────────────┘
                                           │
            ┌──────────────────────────────┼──────────────────────────────┐
            │                              │                              │
            ▼                              ▼                              ▼
    ┌───────────────┐            ┌─────────────────┐            ┌─────────────────┐
    │    Local      │            │     Skills      │            │    Plugins      │
    │  Inference    │            │    Library      │            │     (MCP)       │
    │    Server     │            │   (12 Skills)   │            │                 │
    ├───────────────┤            ├─────────────────┤            ├─────────────────┤
    │ • vLLM        │            │ • net-web-api   │            │ • Azure DevOps  │
    │ • LM Studio   │            │ • net-cqrs      │            │ • GitHub        │
    │ • GLM-4.7     │            │ • net-k8s       │            │ • SonarQube     │
    └───────────────┘            └─────────────────┘            └─────────────────┘
```

### Component Summary

| Component | Purpose | Count |
|-----------|---------|-------|
| **Agents** | Stage-specific + Scrum team automation | 5 stage + 6 team + 3 subagents |
| **Skills** | Reusable .NET patterns and templates | 12 skills |
| **Plugins** | External tool integrations | 3 MCP servers |
| **Templates** | Ready-to-use project structures | 2 templates |

---

## Agent Architecture

### Agent Hierarchy

```
┌─────────────────────────────────────────────────────────────────────┐
│                        PRIMARY AGENTS                               │
├─────────────┬─────────────┬─────────────┬─────────────┬─────────────┤
│  Ideation   │  Prototype  │     PoC     │    Pilot    │   Product   │
│   Agent     │    Agent    │    Agent    │    Agent    │    Agent    │
│             │             │             │             │             │
│ temp: 0.7   │ temp: 0.3   │ temp: 0.2   │ temp: 0.1   │ temp: 0.1   │
└──────┬──────┴──────┬──────┴──────┬──────┴──────┬──────┴──────┬──────┘
       │             │             │             │             │
       └─────────────┴──────┬──────┴─────────────┴─────────────┘
                            │
                            ▼
              ┌─────────────────────────────────┐
              │          SUBAGENTS              │
              ├───────────┬───────────┬─────────┤
              │ Security  │   Code    │  Test   │
              │ Auditor   │ Reviewer  │Generator│
              └───────────┴───────────┴─────────┘
```

### Agent Specifications

| Agent | Temperature | Bash Access | Primary Skills | Output Artifacts |
|-------|-------------|-------------|----------------|------------------|
| **Ideation** | 0.7 | No | net-agile, net-scrum | Requirements, user stories, architecture |
| **Prototype** | 0.3 | Yes | net-web-api | MVP code, basic structure |
| **PoC** | 0.2 | Yes | net-jwt-auth, net-repository | Secure code, tests |
| **Pilot** | 0.1 | Yes | net-testing, net-docker, net-github-actions | Production code, CI/CD |
| **Product** | 0.1 | Yes | net-observability, net-kubernetes | Monitoring, scaling |

### Scrum Team Agents

| Agent | Responsibilities |
|-------|------------------|
| **product-owner** | Story IDs, acceptance criteria, backlog priorities |
| **scrum-master** | DoR/DoD enforcement, traceability compliance |
| **developer** | Implementation, tests, documentation |
| **qa** | Test linkage, coverage enforcement |
| **security** | Threat modeling, security reviews |
| **devops** | CI/CD, release readiness, deployment validation |

### Agent Lifecycle Flow

```
┌─────────────┐
│   Request   │
│  Received   │
└──────┬──────┘
       │
       ▼
┌──────────────────┐     ┌──────────────────┐
│  Agent Selection │────▶│   Skill Loading  │
│  (by /agent cmd) │     │  (on-demand)     │
└──────────────────┘     └────────┬─────────┘
                                  │
       ┌──────────────────────────┘
       │
       ▼
┌──────────────────┐     ┌──────────────────┐
│  Tool Execution  │────▶│ Artifact Output  │
│  (write, bash)   │     │ (code, docs)     │
└──────────────────┘     └──────────────────┘
```

---

## Skills Architecture

### Skill Categories

| Category | Skills | Purpose |
|----------|--------|---------|
| **API Development** | net-web-api | ASP.NET Core scaffolding |
| **Domain Modeling** | net-domain-model, net-cqrs | DDD patterns, CQRS |
| **Data Access** | net-repository-pattern | Repository, Unit of Work |
| **Security** | net-jwt-auth | JWT authentication |
| **Testing** | net-testing | xUnit, integration tests |
| **DevOps** | net-docker, net-github-actions, net-kubernetes | Containers, CI/CD, K8s |
| **Observability** | net-observability | Logging, tracing, metrics |
| **Agile** | net-agile, net-scrum | Ceremonies, artifacts |

### Skill Structure

```
.opencode/skill/{skill-name}/
└── SKILL.md          # Frontmatter + instructions
    ├── name          # Skill identifier
    ├── description   # What the skill does
    ├── license       # MIT
    ├── compatibility # opencode
    └── metadata      # audience, framework, patterns
```

### Skill Loading Flow

```
Discovery ──▶ Parsing ──▶ Validation ──▶ Injection ──▶ Execution
    │            │            │             │             │
    ▼            ▼            ▼             ▼             ▼
  Scan       Parse        Validate      Inject to     Agent
  dirs      SKILL.md     frontmatter    context      uses it
```

---

## Template Architecture

### Clean Architecture Solution

```
templates/clean-architecture-solution/
├── src/
│   ├── Api/                    # Presentation Layer
│   │   ├── Controllers/
│   │   ├── Middleware/
│   │   ├── Extensions/
│   │   └── Program.cs
│   ├── Application/            # Application Layer
│   │   ├── Commands/
│   │   ├── Queries/
│   │   ├── Behaviours/
│   │   └── DTOs/
│   ├── Domain/                 # Domain Layer
│   │   ├── Entities/
│   │   ├── ValueObjects/
│   │   ├── Events/
│   │   └── Interfaces/
│   └── Infrastructure/         # Infrastructure Layer
│       ├── Data/
│       ├── Repositories/
│       └── Services/
├── tests/
│   ├── UnitTests/
│   └── IntegrationTests/
└── docker/
    ├── Dockerfile
    └── docker-compose.yml
```

### Layer Dependencies

```
┌────────────────────────────────────────────────────┐
│                   Presentation                     │
│              (ASP.NET Core API)                    │
└─────────────────────┬──────────────────────────────┘
                      │ depends on
┌─────────────────────▼──────────────────────────────┐
│                  Application                       │
│         (Services, DTOs, Validators)               │
└─────────────────────┬──────────────────────────────┘
                      │ depends on
┌─────────────────────▼──────────────────────────────┐
│                    Domain                          │
│        (Entities, Value Objects, Events)           │
└─────────────────────▲──────────────────────────────┘
                      │ implements
┌─────────────────────┼──────────────────────────────┐
│               Infrastructure                       │
│   (EF Core, Repositories, External Services)       │
└────────────────────────────────────────────────────┘
```

---

## Local Inference Architecture

### Supported Providers

| Provider | Type | Recommended For |
|----------|------|-----------------|
| **vLLM** | High-performance server | Production, CI/CD |
| **LM Studio** | Desktop application | Development, prototyping |

### Inference Flow

```
┌──────────────────┐
│   OpenCode       │
│   Agent          │
└────────┬─────────┘
         │
         │ HTTP/REST
         ▼
┌──────────────────┐
│  OpenAI-         │
│  Compatible API  │
└────────┬─────────┘
         │
         ▼
┌──────────────────┐
│  vLLM /          │
│  LM Studio       │
└────────┬─────────┘
         │
         ▼
┌──────────────────┐
│   Local Model    │
│   (GLM-4.7,      │
│   MiniMax, etc.) │
└──────────────────┘
```

### Configuration

```json
{
  "provider": {
    "local-inference": {
      "type": "openai-compatible",
      "baseUrl": "http://localhost:8000/v1",
      "apiKey": "your-api-key",
      "timeout": 120000
    }
  }
}
```

---

## MCP Integration Architecture

### Supported MCP Servers

| Server | Purpose | Features |
|--------|---------|----------|
| **Azure DevOps** | DevOps + tracking | Boards, Repos, Pipelines (via MCP endpoint) |
| **GitHub** | DevOps + tracking | Issues, Projects, PRs, Actions |
| **SonarQube** | Code quality | Analysis, quality gates, metrics |

### MCP Flow

```
┌──────────────────┐
│   OpenCode       │
│   Agent          │
└────────┬─────────┘
         │
         │ JSON-RPC
         ▼
┌──────────────────┐
│  MCP Client      │
│  (OpenCode)      │
└────────┬─────────┘
         │
         ▼
┌──────────────────┐
│  MCP Server      │
│  (External)      │
└────────┬─────────┘
         │
         ▼
┌──────────────────┐
│  External        │
│  Services        │
│  (Azure DevOps / │
│   GitHub)        │
└──────────────────┘
```

---

## Security Architecture

### Permission Model

```
┌──────────────────┐
│   OpenCode       │
│   Agent          │
└────────┬─────────┘
         │
         ▼
┌──────────────────┐
│  Permission      │  ← Bash, Write, Edit
│  Gate            │
└────────┬─────────┘
         │
         ▼
┌──────────────────┐
│  Execution       │  ← Allow, Ask, Deny
│  Layer           │
└──────────────────┘
```

### Permission Levels

| Operation | Level | Description |
|-----------|-------|-------------|
| `git *` | Allow | Version control operations |
| `dotnet *` | Allow | .NET CLI commands |
| `docker *` | Ask | Container operations (user approval) |
| `*` | Deny | All other commands blocked |
| `edit` | Ask | File modifications require approval |
| `write` | Ask | New file creation requires approval |

### Security Best Practices Enforced

1. **No hardcoded secrets** - Secrets via environment variables
2. **Parameterized queries** - SQL injection prevention
3. **Input validation** - All user inputs validated
4. **JWT authentication** - Stateless, secure tokens
5. **HTTPS enforcement** - Secure transport
6. **Security headers** - XSS, CSRF, clickjacking protection

---

## CI/CD Architecture

### Pipeline Flow

```
┌──────────┐    ┌──────────┐    ┌──────────┐    ┌──────────┐    ┌──────────┐
│  Build   │───▶│   Test   │───▶│   Scan   │───▶│  Deploy  │───▶│  Verify  │
└──────────┘    └──────────┘    └──────────┘    └──────────┘    └──────────┘
                                      │
                                      ▼
                               ┌──────────────┐
                               │   Quality    │
                               │    Gate      │
                               └──────────────┘
```

### Quality Gates

| Check | Threshold | Tool |
|-------|-----------|------|
| Unit Test Coverage | ≥80% | Coverlet |
| Code Duplication | ≤3% | SonarQube |
| Security Vulnerabilities | 0 Critical | OWASP, CodeQL |
| Build Warnings | 0 | .NET Compiler |

---

## Traceability Architecture

### Traceability Flow

```
Story (ACF-###)
   │
   ├── Story file (artifacts/stories)
   ├── Tests (Trait/comment/naming)
   ├── Commit messages (git history)
   └── Release notes (generated)
```

### Automation

- `scripts/traceability/traceability.py validate`
- `scripts/traceability/traceability.py report`
- `scripts/traceability/traceability.py release-notes`

Artifacts are stored in `artifacts/traceability`.

---

## Generated Application Architecture

### Clean Architecture Pattern

Applications generated by AI Coding Factory follow Clean Architecture:

| Layer | Responsibility | Dependencies |
|-------|----------------|--------------|
| **Domain** | Business logic, entities, value objects | None |
| **Application** | Use cases, DTOs, interfaces | Domain |
| **Infrastructure** | Data access, external services | Domain, Application |
| **Presentation** | API, controllers, middleware | Application, Infrastructure |

### Key Patterns Used

| Pattern | Implementation | Purpose |
|---------|----------------|---------|
| **Repository** | Generic + specific repositories | Data access abstraction |
| **Unit of Work** | DbContext with transactions | Atomic operations |
| **CQRS** | MediatR commands/queries | Read/write separation |
| **Domain Events** | IDomainEvent with handlers | Loose coupling |
| **Value Objects** | Immutable with equality | Type safety |

---

## Observability Architecture

### Telemetry Stack

```
┌─────────────────────────────────────────────────────────────────────┐
│                        Application                                   │
├─────────────────┬─────────────────┬─────────────────────────────────┤
│    Logging      │    Tracing      │         Metrics                 │
│   (Serilog)     │ (OpenTelemetry) │      (Prometheus)               │
└────────┬────────┴────────┬────────┴────────────┬────────────────────┘
         │                 │                      │
         ▼                 ▼                      ▼
┌─────────────────┐ ┌─────────────┐ ┌─────────────────────────────────┐
│   Seq / ELK     │ │   Jaeger    │ │        Prometheus / Grafana     │
└─────────────────┘ └─────────────┘ └─────────────────────────────────┘
```

### Health Checks

| Endpoint | Purpose | K8s Probe |
|----------|---------|-----------|
| `/health` | Overall status | - |
| `/health/live` | Application alive | Liveness |
| `/health/ready` | Ready for traffic | Readiness |

---

## Kubernetes Deployment Architecture

### Deployment Structure

```yaml
Namespace: your-app
├── Deployment (replicas: 2-10)
│   └── Pod
│       └── Container: api
├── Service (ClusterIP)
├── Ingress (with TLS)
├── ConfigMap (app settings)
├── Secret (credentials)
├── HPA (autoscaling)
└── PDB (disruption budget)
```

### Resource Recommendations

| Resource | Request | Limit |
|----------|---------|-------|
| CPU | 100m | 500m |
| Memory | 256Mi | 512Mi |

---

## File Organization

```
ai-coding-factory/
├── .opencode/
│   ├── opencode.json           # Main configuration
│   ├── agent/                  # 5 stage + 6 team + 3 subagent definitions
│   ├── skill/                  # 12 reusable skills
│   │   ├── net-web-api/
│   │   ├── net-cqrs/
│   │   ├── net-kubernetes/
│   │   └── ...
│   ├── plugin/                 # MCP plugins
│   ├── templates/              # Agile templates
│   │   ├── agile/              # Ceremonies, DoD, DoR
│   │   ├── roles/              # PO, SM, Developer playbooks
│   │   └── artifacts/          # ADR template
│   └── prompts/                # Common agent instructions
├── templates/                  # Project templates
│   ├── clean-architecture-solution/
│   └── microservice-template/
├── projects/                   # Generated projects
├── scripts/                    # Automation
└── docs/                       # Documentation
```

---

## Extension Points

### Adding New Agents

1. Create `.opencode/agent/{agent-name}.md`
2. Add agent config to `.opencode/opencode.json`
3. Define skills, permissions, and temperature

### Adding New Skills

1. Create `.opencode/skill/{skill-name}/SKILL.md`
2. Add frontmatter with metadata
3. Document usage and examples

### Adding New Templates

1. Create `templates/{template-name}/`
2. Add README.md with instructions
3. Include placeholder tokens for customization

---

## References

- [OpenCode Documentation](https://opencode.ai/docs)
- [Clean Architecture by Robert C. Martin](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)
- [Domain-Driven Design by Eric Evans](https://www.domainlanguage.com/ddd/)
- [Scrum Guide](https://scrumguides.org/)
