# Corporate R&D Development Policy

## Status, Scope, and Authority

- **Status**: Mandatory and enforceable.
- **Scope**: Applies to this platform repository, all OpenCode agents, and all generated projects.
- **Authority**: This document is the authoritative governance policy for engineering, delivery, and maintenance.
- **Compliance**: Non-compliance blocks delivery unless a documented, time-bound exception is approved.

## Enforcement Model

This policy is enforceable through the following controls:

- **Agent instructions**: All agents must follow and refuse policy violations.
- **Templates and checklists**: ADRs, security reviews, and release readiness checklists are mandatory.
- **Validation scripts**: `scripts/validate-project.sh`, `scripts/validate-documentation.sh`, `scripts/validate-rnd-policy.sh`.
- **CI checks**: Build, test, coverage, traceability, documentation, and security gates.
- **Escalation path**: Exceptions are documented, approved, and time-bound.

## 1) Engineering Principles (Mandatory Controls)

1. **Quality over speed**
   - Trade-offs are only allowed if recorded in an ADR with risk and mitigation.
   - **Enforced by**: ADR template and review gates.
2. **Test-first / test-always**
   - Every behavior change requires tests and traceability.
   - **Enforced by**: traceability scripts, coverage checks, CI.
3. **Maintainability and long-term ownership**
   - Designs must support 10-30 year lifecycle; avoid vendor lock-in without ADR.
   - **Enforced by**: architecture review and ADRs.
4. **Explicit technical debt handling**
   - All debt must be captured as a story with owner, impact, and target release.
   - **Enforced by**: backlog grooming and traceability.
5. **Security and privacy by default**
   - Secure-by-default configurations are mandatory.
   - **Enforced by**: security checklist, CI gates, and agent guardrails.

## 2) Development Lifecycle Policy

All work must progress through the following stages. Skipping stages requires a documented exception.

| Stage | Required Artifacts | Allowed Actions | Forbidden Actions | Exit Criteria |
| --- | --- | --- | --- | --- |
| Ideation | `requirements.md`, `epics.md`, `user-stories.md`, `architecture.md`, `risk-log.md` | Define scope and constraints | Code changes | PO + Scrum Master approval |
| Development | Stories, ADRs (when required), implementation, tests, docs | Implement approved stories | Unreviewed dependencies, untracked changes | Tests + docs updated |
| Validation | Test reports, coverage report, traceability report | Run validation scripts/CI | Disabling tests, lowering coverage | All quality gates green |
| Release | Release notes, security review checklist, release readiness checklist | Package and release | Releasing with known policy violations | Signed readiness checklist |
| Maintenance | Incident reports, hotfix stories, updated docs | Operate and fix issues | Silent hotfixes, untracked changes | Post-incident review |

### Corporate Definition of Done (DoD)

A story is Done only when all of the following are true:

- Story acceptance criteria are met and linked to `ACF-###`.
- Tests exist for new/changed behavior and pass in CI.
- Coverage thresholds are met for Domain/Application layers.
- Traceability report includes the story and tests.
- Documentation and ADRs updated where applicable.
- Security and privacy checks completed.
- No open high/critical vulnerabilities or known policy violations.

## 3) AI Agent Behavior Rules (Mandatory)

### Autonomy vs Approval

- **Agents may do autonomously**:
  - Implement within an approved story scope.
  - Update tests and documentation required by the story.
  - Generate traceability artifacts.
- **Human approval required**:
  - New dependencies or external integrations.
  - Architectural changes and ADR creation.
  - Breaking API changes or schema changes.
  - Security posture changes or threat model updates.
- **Explicitly forbidden**:
  - Bypassing validation, tests, or traceability.
  - Shipping code without story IDs.
  - Introducing secrets or external data exfiltration paths.

### Code and Change Rules

- **Create code** only within story scope and Clean Architecture boundaries.
- **Modify code** only with updated tests and documentation.
- **Introduce dependencies** only after approval and ADR update.
- **Refactor** only when behavior is preserved and tests prove it.
- **Breaking changes** require a deprecation plan and versioning update.

### Required Agent Self-Checks (Before Claiming Completion)

- Run `scripts/validate-project.sh` and `scripts/validate-documentation.sh`.
- Run `scripts/validate-rnd-policy.sh`.
- Run traceability validation: `python3 scripts/traceability/traceability.py validate`.
- Verify coverage thresholds with `scripts/coverage/check-coverage.py`.
- Confirm ADRs, release readiness, and security checklists are updated if required.
- If any check fails, stop and remediate or request an exception.

Agents **must refuse** to proceed if a request violates this policy and must route to the exception process.

## 4) Architecture and Design Governance

- **ADRs are mandatory** when:
  - Introducing new services, databases, or external dependencies.
  - Modifying Clean Architecture boundaries or core domain models.
  - Changing security model, authentication, or authorization.
  - Creating breaking changes or incompatible schema migrations.
- **Decision workflow**:
  - Propose via ADR template.
  - Review by Product Owner + Security + Architecture owner.
  - Acceptance recorded in ADR; link to story IDs.
- **Clean Architecture rules**:
  - Domain has no external dependencies.
  - Application depends only on Domain.
  - Infrastructure depends on Domain/Application only.
  - API depends on Application/Infrastructure.
- **DDD/CQRS usage**:
  - Use when complexity justifies; document rationale in ADR.
  - Do not add CQRS for CRUD-only systems without justification.
- **Backward compatibility**:
  - Non-breaking changes are default.
  - Breaking changes require deprecation plan and versioning update.

## 5) Testing and Quality Policy

- **Coverage**: >=80% line and branch for Domain/Application layers.
- **Mandatory test types**:
  - Unit tests for domain and application logic.
  - Integration tests for API and infrastructure paths.
  - Architecture tests to validate layering rules.
- **Prohibited shortcuts**:
  - Disabling tests or lowering coverage thresholds without a documented exception.
  - Skipping integration tests for critical endpoints.
- **Mutation/negative testing**:
  - Expected for high-risk modules; if skipped, document in release readiness.

## 6) Documentation Policy

### Required Documents (Per Project)

- Architecture overview
- Module/dependency overview
- API/OpenAPI documentation
- Deployment/operations runbook
- Testing strategy
- Documentation requirements
- Governance and traceability docs

### Required Documents (Per Release)

- Release notes
- Traceability report
- Security review checklist
- Release readiness checklist

### Ownership and Sync Rules

- Each document must have an owner role (PO, Dev, QA, Security, DevOps).
- Documentation updates are required in the same story that changes behavior.
- Docs must reference related story IDs and ADRs.

## 7) Traceability and Auditability

- **Story -> Test -> Commit -> Release** is mandatory.
- Story IDs must appear in stories, tests, commits, and release notes.
- Traceability reports are generated and stored in `artifacts/traceability/`.
- Evidence retention: ADRs, checklists, test reports, coverage, and release notes are retained for the product lifetime.
- AI-generated artifacts must include authorship in change notes or release notes and be reviewed by a human owner.

## 8) Security and Compliance Posture

- **Secure-by-default**: HTTPS, least privilege, input validation, no secrets in code.
- **Dependency policy**: Approved sources only, pinned versions, vulnerability checks before release.
- **Secret handling**: Environment variables or secure secret stores only.
- **Local inference trust boundary**: No external data egress; MCP integrations disabled unless approved.
- **IP and data residency**: All code and data remain local; IP belongs to the organization.

## 9) Escalation and Exception Handling

- **Request**: Create a written exception with scope, reason, risk, and sunset date.
- **Approval**: Product Owner + Security + Architecture owner (minimum quorum).
- **Documentation**: Store the exception with the related story and ADR references.
- **Sunset**: Exceptions must be reviewed before expiration; expired exceptions block release.

## 10) Compliance Control Matrix

| Control ID | Requirement | Enforcement |
| --- | --- | --- |
| C-01 | Story IDs in stories/tests/commits/releases | Traceability scripts + CI |
| C-02 | ADR required for architectural/security changes | ADR template + review |
| C-03 | Coverage >=80% (Domain/Application) | Coverage script + CI |
| C-04 | Required docs present and updated | Documentation validation |
| C-05 | Security review before release | Security checklist + CI |
| C-06 | Release readiness checklist signed | Release checklist + review |
| C-07 | No secrets in code | Agent guardrails + review |
| C-08 | Dependency approvals | ADR + PO/Security approval |
| C-09 | Traceability report generated | Traceability script |
| C-10 | Exception handling documented | Governance review + checklist |

