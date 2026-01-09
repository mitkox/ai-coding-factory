# Enterprise Governance

## Purpose

This document defines the governance baseline for AI Coding Factory projects. It is designed to enforce quality, security, traceability, and auditability while keeping delivery fast and private.

## Scope

Applies to:
- This repository (platform governance)
- Generated projects from templates
- All AI and human contributions

## Versioning and Branching

**Versioning**:
- Semantic Versioning (SemVer): MAJOR.MINOR.PATCH
- Pre-release tags for RCs (e.g., 1.4.0-rc.1)

**Branching**:
- `main` is always releasable
- Short-lived feature branches named `feature/ACF-123-short-title`
- Release branches named `release/1.4` (optional, for staged releases)
- Hotfix branches named `hotfix/ACF-456-short-title`

**Merge Strategy**:
- Squash merge preferred
- Squash commit message must include story ID(s)

## Pull Request Requirements

**Required before merge**:
- At least 2 approvals (1 domain owner + 1 platform/quality owner)
- All CI checks green (build, tests, coverage, traceability, documentation)
- No critical or high security findings
- ADR updated if architectural impact exists
- Story ID(s) present in PR title and commit messages

**Required review focus**:
- Security impacts (auth, data access, secrets)
- Traceability coverage (story to tests to commits)
- Documentation updates

**DevOps Platform**:
- PRs are created in Azure Repos or GitHub
- Work items are linked to PRs (Azure Boards or GitHub Issues/Projects)
- Azure Pipelines or GitHub Actions runs quality gates

**Open Source Default**:
- GitHub is the default platform for public contributions
- Azure DevOps remains supported for enterprise installations

## Code Ownership

**Rule**:
- All directories have explicit owners in `CODEOWNERS`
- Owners approve changes to owned areas

**Location**: `.github/CODEOWNERS`

**Ownership updates**:
- When new folders are created, ownership must be added before merge

## Dependency and Vulnerability Management

**Dependency rules**:
- Only approved package sources
- Dependencies must be pinned and recorded
- Minimal dependencies; prefer platform-approved libraries

**Vulnerability management**:
- `dotnet list package --vulnerable` must pass
- Critical/high vulnerabilities block release
- Exceptions require a documented waiver with expiration

## Documentation Ownership and Update Rules

**Required documents**:
- Architecture overview
- Module/dependency overview
- API documentation (OpenAPI)
- Deployment/operations documentation

**Ownership**:
- Each document has a named owner (role or individual)
- Docs are updated within the same story that changed behavior

## Traceability Policy

**Mandatory**:
- Story IDs use format `ACF-###`
- Story IDs appear in:
  - Story definition files
  - Commit messages
  - Test metadata
  - Release notes

**Azure Boards alignment**:
- Each story maps to an Azure Boards work item
- The work item title includes the story ID

**Rules**:
- A story is not Done unless it has automated test coverage
- CI fails if any story lacks tests
- Release notes are generated from merged commit story IDs

**Waivers**:
- Only allowed for emergency fixes
- Must include reason, impact, and expiration

## Governance Artifacts

- Definition of Done: `.opencode/templates/agile/definition-of-done.md`
- Definition of Ready: `.opencode/templates/agile/definition-of-ready.md`
- ADR Template: `.opencode/templates/artifacts/ADR-template.md`
- Threat Model Checklist: `.opencode/templates/artifacts/threat-model-checklist.md`
- Security Review Checklist: `.opencode/templates/artifacts/security-review-checklist.md`
- Release Readiness Checklist: `.opencode/templates/artifacts/release-readiness-checklist.md`

## Compliance and Audit

- Traceability reports stored in `artifacts/traceability`
- Release notes stored with each release tag
- Audit trail is preserved via git history and generated reports
