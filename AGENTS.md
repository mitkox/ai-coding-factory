# AGENTS.md

This file provides guidance to Coding Agents when working with code in this repository.

## Repository Overview

AI Coding Factory is a comprehensive system that automates the enterprise .NET application development lifecycle using specialized OpenCode agents. It implements a multi-agent orchestration model where each agent handles specific development stages (Ideation → Prototype → PoC → Pilot → Product).

## Architecture

This is an **OpenCode-based multi-agent system**, not a traditional code repository. The core architecture consists of:

- **5 Specialized Agents** (`.opencode/agent/`) - Stage-specific AI assistants for development lifecycle
- **11+ Reusable Skills** (`.opencode/skill/`) - Composable workflows for common .NET patterns
- **3 Custom Plugins** (`.opencode/plugin/`) - TypeScript-based integrations (SonarQube, OWASP, CI/CD)
- **Agent Templates** (`.opencode/templates/`) - Agile/Scrum artifacts and role playbooks
- **Project Templates** (`templates/`) - Clean Architecture and microservice boilerplates

### Multi-Agent Development Flow

```
Ideation → Prototype → PoC → Pilot → Product
(reqs)     (MVP)       (secure) (tests) (monitor)
```

Each agent has specific responsibilities, temperature settings (0.1-0.7), and tool permissions configured in `.opencode/opencode.json`.

### Agent Configuration System

Agents are configured with:
- **Mode**: primary (user-facing) or subagent (helper)
- **Model**: Local inference model (GLM-4.7 via vLLM/LM Studio)
- **Temperature**: Creativity level (ideation=0.7, production agents=0.1-0.2)
- **Tools**: Permissions for write, edit, bash operations
- **Skills**: Access to net-* skills for .NET patterns

### Skill System

Skills are markdown files (SKILL.md) with frontmatter metadata. They provide reusable workflows:
- `net-web-api` - ASP.NET Core scaffolding
- `net-domain-model` - DDD patterns
- `net-repository-pattern` - Data access
- `net-jwt-auth` - Authentication
- `net-testing` - Test framework setup
- `net-docker` - Containerization
- `net-github-actions` - CI/CD pipelines
- `net-agile` - Enterprise agile practices
- `net-scrum` - Scrum ceremonies and artifacts
- `net-observability`, `net-kubernetes`, `net-cqrs` - Advanced patterns

Skills are auto-discovered and loaded by agents on-demand.

## Common Commands

### Development Workflow
```bash
# Initial setup (only run once)
./scripts/setup.sh

# Validate project structure
./scripts/validate-project.sh

# Create new project from template
cd projects
mkdir <project-name>
cd <project-name>
opencode
/agent ideation
```

### .NET Development (within generated projects)
```bash
# Restore dependencies
dotnet restore

# Build solution
dotnet build

# Run tests
dotnet test

# Run specific test project
dotnet test tests/<ProjectName>.UnitTests

# Run API project
cd src/<ProjectName>.Api
dotnet run

# Create migration (EF Core)
cd src/<ProjectName>.Infrastructure
dotnet ef migrations add <MigrationName> --startup-project ../ProjectName.Api

# Update database
dotnet ef database update --startup-project ../ProjectName.Api
```

### Docker Operations
```bash
# Build and run with Docker Compose
docker-compose up --build

# Run in detached mode
docker-compose up -d

# Stop containers
docker-compose down

# View logs
docker-compose logs -f api
```

### Agent Commands (within OpenCode)
```bash
# Switch agents
/agent ideation    # Requirements and architecture
/agent prototype   # Rapid MVP development
/agent poc         # Production considerations
/agent pilot       # Production readiness
/agent product     # Maintenance and scaling

# Invoke subagents
@net-security-auditor   # Security vulnerability scan
@net-code-reviewer      # Code quality review
@net-test-generator     # Generate test cases
```

## Key Architecture Patterns

### Clean Architecture Layers
Generated .NET projects follow strict dependency rules:

1. **Domain Layer** (no dependencies)
   - Entities: Business objects with identity
   - Value Objects: Immutable objects compared by value
   - Aggregates: Consistency boundaries with aggregate roots
   - Domain Events: Capture domain changes
   - Repository Interfaces: Data access contracts

2. **Application Layer** (depends on Domain)
   - CQRS: Commands and Queries via MediatR
   - DTOs: API data transfer objects
   - Validators: FluentValidation for input validation
   - Behaviours: Cross-cutting concerns (logging, validation, transactions)

3. **Infrastructure Layer** (depends on Domain + Application)
   - Repository Pattern: IRepository<T> implementations
   - Unit of Work: Transaction management across repositories
   - DbContext: Entity Framework Core configuration
   - External Services: Third-party integrations

4. **API Layer** (depends on Application + Infrastructure)
   - Controllers: RESTful endpoints
   - Middleware: Exception handling, correlation IDs
   - Filters: Authentication, validation
   - Extensions: Dependency injection setup

**Critical**: Infrastructure and API depend on abstractions in Domain/Application. Domain has zero external dependencies.

### Agent-Skill Interaction Pattern

When an agent needs to implement a pattern:
1. Agent identifies required skill (e.g., "net-jwt-auth")
2. OpenCode loads skill's SKILL.md instructions
3. Agent executes skill workflow (scaffolding, code generation)
4. Agent validates against Definition of Done (DoD)
5. Output artifacts are created in target project

### Local Inference Architecture

```
OpenCode Agent → OpenAI-compatible API → vLLM/LM Studio → Local Model (GLM-4.7)
```

Configuration in `.opencode/opencode.json`:
- Provider type: "openai-compatible"
- Base URL: http://localhost:8000/v1 (configurable)
- Timeout: 120 seconds for complex generations
- Privacy: All code stays local, never sent to cloud

## Project Structure Conventions

### Repository Root
```
.opencode/           # OpenCode configuration (agents, skills, plugins)
templates/           # Project boilerplates (Clean Architecture, microservices)
projects/            # Generated projects (gitignored, user workspace)
scripts/             # Automation (setup.sh, validate-project.sh)
docs/                # Architecture documentation (ARCHITECTURE.md, AGILE-METHODOLOGY.md)
```

### Generated .NET Projects
```
src/
├── ProjectName.Api/          # ASP.NET Core API layer
├── ProjectName.Application/  # Business logic and CQRS
├── ProjectName.Domain/       # Core domain models (no dependencies)
└── ProjectName.Infrastructure/ # Data access and external services

tests/
├── ProjectName.UnitTests/       # Business logic tests (>80% coverage)
├── ProjectName.IntegrationTests/ # API endpoint tests
└── ProjectName.ArchitectureTests/ # Dependency rule validation

docker/
├── Dockerfile
└── docker-compose.yml
```

### Plugin TypeScript Structure
Plugins (`.opencode/plugin/*.ts`) follow OpenCode plugin API:
- Export `onToolExecute`, `onFileEdit`, `onAgentSwitch` hooks
- Return `{ allow: boolean, message?: string }` for event handling
- Example: SonarQube integration runs quality checks post-build

## Testing Requirements

### Test Pyramid Strategy
- **Unit Tests**: >80% coverage target for business logic (Domain/Application layers)
- **Integration Tests**: All critical API endpoints with real database (TestContainers)
- **Architecture Tests**: Validate Clean Architecture dependency rules (NetArchTest)

### Test Organization
```csharp
// Unit test naming convention
public class CalculatorTests
{
    [Fact]
    public void Add_TwoPositiveNumbers_ReturnsSum()
    {
        // Arrange
        var calculator = new Calculator();

        // Act
        var result = calculator.Add(5, 3);

        // Assert
        result.Should().Be(8);
    }
}
```

### Test Frameworks
- **xUnit**: Test runner and assertions
- **Moq**: Mocking framework for dependencies
- **FluentAssertions**: Readable assertion syntax
- **TestContainers**: Real database for integration tests
- **Coverlet**: Code coverage reporting

## Agile/Scrum Integration

### User Story Format (INVEST-compliant)
```markdown
## US-123 - User Login

As a registered user,
I want to log in with email and password,
So that I can access my personalized dashboard.

**Acceptance Criteria**:
- Given valid credentials, when user submits login, then redirect to dashboard
- Given invalid credentials, when user submits login, then show error message
- Given locked account, when user submits login, then show account locked message

**Definition of Done**:
- [ ] Unit tests with >80% coverage
- [ ] Integration tests for API endpoints
- [ ] Security review (no SQL injection, password hashing)
- [ ] Code review completed
- [ ] Documentation updated

**Story Points**: 5
```

### Agile Artifacts
Templates in `.opencode/templates/agile/`:
- `user-story-template.md` - INVEST-compliant story format
- `definition-of-done.md` - Quality checklist (testing, security, docs)
- `definition-of-ready.md` - Story readiness criteria
- `sprint-planning-template.md` - Capacity planning and commitment
- `sprint-retrospective-template.md` - Continuous improvement
- `daily-standup-template.md` - Progress tracking

### Agent-Scrum Workflow
1. **Ideation Agent**: Creates user stories with acceptance criteria using `net-agile` skill
2. **Prototype/PoC/Pilot Agents**: Validate against Definition of Ready before starting
3. **All Agents**: Check Definition of Done before marking work complete
4. **Product Agent**: Tracks velocity, cycle time, conducts retrospectives

## Security and Code Quality

### Security Rules (.opencode/opencode.json)
- **Always validate input**: Use FluentValidation for API inputs
- **Parameterized queries**: EF Core only, no raw SQL strings
- **JWT authentication**: Use `net-jwt-auth` skill for proper implementation
- **No secrets in code**: Use IConfiguration and environment variables
- **HTTPS only**: Enforce HTTPS redirect in production

### .NET Best Practices
- **Async/await**: Use for all I/O operations (database, HTTP, file)
- **ILogger**: Structured logging via dependency injection (no Console.WriteLine)
- **Dependency Injection**: Constructor injection only, avoid service locator pattern
- **Naming**: PascalCase for public members, camelCase for private/local
- **XML comments**: Required for all public APIs
- **IDisposable**: Properly implement for unmanaged resources
- **string interpolation**: Use `$"{var}"` over concatenation

### Permission System
Configured in `.opencode/opencode.json`:
```json
"permission": {
  "bash": {
    "git *": "allow",      // Git operations auto-approved
    "dotnet *": "allow",   // .NET CLI auto-approved
    "docker *": "ask",     // Docker requires confirmation
    "*": "deny"            // Deny all other commands
  },
  "edit": "ask",           // File edits require confirmation
  "write": "ask"           // New files require confirmation
}
```

## MCP (Model Context Protocol) Integration

Optional integrations configured in `.opencode/opencode.json`:
- **Azure DevOps**: Boards, Repos, Pipelines (`mcp.azure-devops`)
- **GitHub**: Issues, Projects, PRs, Actions (`mcp.github`)
- **SonarQube**: Code quality gates (`mcp.sonarqube`)

Enable by setting `"enabled": true` and configuring OAuth/tokens.

## CI/CD Pipeline (Azure Pipelines or GitHub Actions)

Generated projects include an `azure-pipelines.yml` file. GitHub Actions is supported via `.github/workflows/quality-gates.yml`:
1. **Build**: Compile and test on every push
2. **Test**: Full test suite with coverage reporting
3. **Deploy**: Extend with deployment stages as needed

### Quality Gates
- Build must succeed
- All tests must pass
- Code coverage >80%
- No critical security vulnerabilities (OWASP)
- SonarQube quality gate (B rating minimum)

## Working with This Repository

Primary open-source repository: https://github.com/mitkox/ai-coding-factory

### When Adding New Agents
1. Create `.opencode/agent/<agent-name>.md` with frontmatter (name, description, mode)
2. Add agent configuration to `.opencode/opencode.json` agent section
3. Define temperature (0.1-1.0), tools permissions, model
4. Document agent's role in ARCHITECTURE.md

### When Adding New Skills
1. Create `.opencode/skill/<skill-name>/SKILL.md`
2. Add frontmatter: name, version, description, dependencies
3. Include usage examples and output artifacts
4. Update README.md skills table

### When Modifying Templates
- Clean Architecture template: `templates/clean-architecture-solution/`
- Microservice template: `templates/microservice-template/`
- Test changes by generating new project and running `dotnet build`

### Configuration Files
- `.opencode/opencode.json`: Agent definitions, permissions, MCP integrations
- `.opencode/prompts/common-instructions.txt`: Shared agent guidelines
- Directory.Build.props: Shared .NET project properties
- .editorconfig: Code style rules

## Troubleshooting

### OpenCode Issues
```bash
# Verify configuration syntax
cat .opencode/opencode.json | python3 -m json.tool

# Check agent files exist
ls -la .opencode/agent/

# Validate skills
./scripts/validate-project.sh
```

### Local Inference Not Responding
```bash
# Test vLLM connection
curl http://localhost:8000/v1/models

# Restart vLLM
pkill -f vllm
vllm serve GLM-4.7 --dtype auto --api-key token-abc123
```

### Generated Project Build Failures
```bash
# Clean and restore
dotnet clean
dotnet restore
dotnet build

# Check .NET SDK version (requires .NET 8)
dotnet --version
```

## Important Notes

- **Not a Traditional Codebase**: This is an orchestration system, not application code. The "product" is the agent configurations and templates.
- **Projects Directory**: User-generated projects are in `projects/` (gitignored). Do not confuse with templates.
- **Local-First**: All AI inference happens locally via vLLM/LM Studio. No code is sent to external APIs.
- **Agile-Driven**: All agents integrate with Scrum practices. User stories follow INVEST, work follows DoD/DoR.
- **Clean Architecture Enforced**: Generated projects strictly follow dependency rules. Domain has no external dependencies.
- **Enterprise Focus**: Security, testing (>80% coverage), and maintainability are non-negotiable standards.
