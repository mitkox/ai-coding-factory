# Traceability Model

## Why Traceability Exists

Traceability ensures every delivered change can be audited from story to test to commit to release. This reduces risk, enables compliance, and makes releases explainable for enterprise governance.

## Traceability Chain

**Story -> Test -> Commit -> Release**

### 1) Story Identity
- Format: `ACF-###`
- Story IDs must be unique and stable
- Story IDs live in story definition files (`artifacts/stories`)
- Story IDs are included in Azure Boards or GitHub work item titles

### 2) Story -> Test
- Every story must reference at least one automated test
- Acceptable test references:
  - Test name contains `ACF-###`
  - xUnit Trait: `[Trait("Story", "ACF-###")]`
  - Structured comment header: `// Traceability: Story=ACF-###`

### 3) Story -> Commit
- Every commit message must include at least one story ID
- Format: `ACF-123: short description`
- Squash merges must preserve story IDs

### 4) Story -> Release
- Release notes generated from commit messages
- Release notes include:
  - Delivered story IDs
  - Tests linked to each story
  - Coverage summary and known risks
  - Azure DevOps or GitHub release pipeline run reference (when available)

## Automation

**Scripts**:
- `scripts/traceability/traceability.py validate`
- `scripts/traceability/traceability.py report`
- `scripts/traceability/traceability.py release-notes`

**Artifacts**:
- Traceability report: `artifacts/traceability/traceability-report.md`
- Release notes: `artifacts/traceability/release-notes.md`

## How AI Agents Enforce Traceability

- Product Owner agent assigns story IDs
- Scrum Master agent blocks stories without DoR compliance
- Developer agents add story IDs to commits and tests
- QA agent verifies test linkage and coverage
- DevOps agent ensures release notes and reports are generated

## Manual Overrides (Waivers)

Only allowed for emergency fixes:
- Must include reason, impact, approver, and expiration
- Stored in `artifacts/traceability/waivers`
- Waivers are reviewed in the next retrospective

## Example Report

See `artifacts/traceability/example-report.md`.
