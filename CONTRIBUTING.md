# Contributing to AI Coding Factory

Thank you for your interest in contributing to AI Coding Factory! This document provides guidelines and instructions for contributing.

## Code of Conduct

- Be respectful and inclusive
- Provide constructive feedback
- Focus on what is best for the community
- Show empathy towards other contributors

## Getting Started

### Prerequisites

- **OpenCode** installed
- **.NET 8 SDK** installed
- **Python 3.8+** (for vLLM testing)
- **Node.js 18+** (for plugins)
- **Docker** (for containerization testing)
- **Git** for version control

### Development Setup

```bash
# Fork the repository
git clone https://github.com/mitkox/ai-coding-factory.git
# or
# git clone https://dev.azure.com/your-org/ai-coding-factory/_git/ai-coding-factory
cd ai-coding-factory

# Add upstream remote
git remote add upstream https://github.com/mitkox/ai-coding-factory.git
# or
# git remote add upstream https://dev.azure.com/your-org/ai-coding-factory/_git/ai-coding-factory

# Create a feature branch
git checkout -b feature/your-feature-name

# Run setup script
./scripts/setup.sh
```

## Contribution Areas

We welcome contributions in the following areas:

### 1. New Agents

Create new specialized agents for specific development tasks:

```bash
# Create agent file
touch .opencode/agent/your-agent.md

# Add to configuration in .opencode/opencode.json
```

**Agent Guidelines:**
- Clear description of purpose and when to use
- Appropriate temperature for the task
- Proper tool permissions configured
- Examples of workflows and outputs

### 2. New Skills

Create reusable skills for common .NET patterns:

```bash
# Create skill directory
mkdir .opencode/skill/your-skill

# Create SKILL.md
touch .opencode/skill/your-skill/SKILL.md
```

**Skill Guidelines:**
- Follow SKILL.md format (name, description, metadata)
- Provide clear instructions for what the skill does
- Include best practices and examples
- Make skills composable and reusable

### 3. New Plugins

Create plugins for external integrations:

```bash
# Create plugin file
touch .opencode/plugin/your-plugin.ts

# Add TypeScript dependencies
npm install @opencode-ai/plugin typescript
```

**Plugin Guidelines:**
- Follow plugin TypeScript API
- Use proper error handling
- Add logging where appropriate
- Test with various OpenCode events

### 4. Documentation

Improve documentation:

- Update README.md with new features
- Add examples to QUICKSTART.md
- Update architecture documentation
- Fix typos and improve clarity

### 5. Bug Fixes

Report and fix bugs:

1. Search existing issues first
2. Create a new issue with detailed description
3. Include steps to reproduce
4. Submit a pull request with fix

### 6. Test Coverage

Improve test coverage:

- Add unit tests for new features
- Add integration tests for API endpoints
- Ensure >80% code coverage
- Test edge cases and error conditions

## Development Workflow

### 1. Create Branch

```bash
git checkout -b feature/your-feature-name
# or
git checkout -b fix/your-bug-fix
```

### 2. Make Changes

- Follow existing code style
- Add comments for complex logic
- Update relevant documentation
- Add tests for new functionality

### 3. Test Changes

```bash
# Test agents
opencode

# Test skills
opencode

# Test plugins
opencode

# Run tests (if any)
dotnet test

# Format code
dotnet format
```

### 4. Commit Changes

```bash
git add .
git commit -m "ACF-123: feat: add your feature description"

# Use conventional commits:
# feat: new feature
# fix: bug fix
# docs: documentation changes
# style: formatting changes
# refactor: code refactoring
# test: adding or updating tests
# chore: build process or auxiliary tool changes
```

### 5. Push and Create Pull Request

```bash
git push origin feature/your-feature-name

# Open a pull request in GitHub or Azure Repos
# Fill out PR template
# Link related work items or issues
```

## Pull Request Guidelines

### PR Checklist

- [ ] Code follows project style guidelines
- [ ] Tests added/updated for new features
- [ ] Documentation updated
- [ ] Commit messages follow conventional commits
- [ ] Commit messages include story IDs (ACF-###)
- [ ] Traceability validation passes
- [ ] No merge conflicts
- [ ] All tests pass
- [ ] Code is properly formatted

### PR Template

```markdown
## Description
Brief description of changes

## Type of Change
- [ ] Bug fix (non-breaking change which fixes an issue)
- [ ] New feature (non-breaking change which adds functionality)
- [ ] Breaking change (fix or feature that would cause existing functionality to not work as expected)
- [ ] Documentation update

## Related Work Items / Issues
Azure Boards work item or GitHub issue: [ACF-###]

## Testing
How did you test this change?

## Checklist
- [ ] Code follows style guidelines
- [ ] Tests added/updated
- [ ] Documentation updated
- [ ] All tests pass
```

## Coding Standards

### .NET Guidelines

- Follow C# naming conventions (PascalCase for public members)
- Use async/await for I/O operations
- Implement proper exception handling
- Use dependency injection
- Add XML comments for public APIs
- Follow SOLID principles

### TypeScript/JavaScript Guidelines

- Use TypeScript for plugins
- Follow ESLint rules
- Use proper error handling
- Add JSDoc comments for functions
- Use async/await for async operations

### Markdown Guidelines

- Use proper markdown syntax
- Add code blocks with language tags
- Include examples and explanations
- Use consistent formatting
- Update table of contents if applicable

## Testing

### Unit Tests

- Use xUnit for .NET tests
- Use Moq for mocking
- Follow AAA pattern (Arrange, Act, Assert)
- Test edge cases and error conditions
- Aim for >80% code coverage

### Integration Tests

- Use TestContainers for database tests
- Test API endpoints end-to-end
- Test authentication and authorization
- Test with real database schema

### E2E Tests

- Test critical user flows
- Use Playwright or Selenium
- Test on multiple browsers if applicable
- Include accessibility tests

## Documentation

### Code Comments

- Add XML comments for public APIs
- Explain WHY, not WHAT
- Keep comments concise and accurate
- Update comments when code changes

### Documentation Files

- Update README.md for user-facing changes
- Update ARCHITECTURE.md for structural changes
- Update QUICKSTART.md for workflow changes
- Keep examples up-to-date

## Release Process

### Versioning

We follow Semantic Versioning (SemVer):

- MAJOR: Breaking changes
- MINOR: New features (non-breaking)
- PATCH: Bug fixes (non-breaking)

Example: 1.2.3
- 1 = Major version
- 2 = Minor version
- 3 = Patch version

### Release Checklist

- [ ] All tests pass
- [ ] Documentation updated
- [ ] CHANGELOG.md updated
- [ ] Version bumped
- [ ] Tagged with version number
- [ ] Release notes created

## Community

### Discussion

- Use GitHub Discussions or Azure DevOps project channels
- Ask questions
- Share ideas
- Help others

### Work Items

- Track bugs and features in GitHub Issues or Azure Boards
- Use story IDs (ACF-###) for traceability

## Getting Help

- Read [QUICKSTART.md](QUICKSTART.md) for getting started
- Read [ARCHITECTURE.md](ARCHITECTURE.md) for understanding the system
- Check GitHub Issues or Azure Boards for similar work items
- Ask in GitHub Discussions or Azure DevOps project channels

## Recognition

Contributors will be recognized in:
- CONTRIBUTORS.md file
- Release notes
- Project documentation

## License

By contributing, you agree that your contributions will be licensed under the MIT License.

---

Thank you for contributing to AI Coding Factory! 🚀
