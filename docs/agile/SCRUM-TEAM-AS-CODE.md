# Scrum Team as Code

## Purpose

Define a Scrum team as explicit agent roles with enforceable responsibilities. The goal is to make delivery repeatable, auditable, and continuously verifiable.

## Team Roles (AI Agents)

| Role | Agent | Primary Responsibilities |
| --- | --- | --- |
| Product Owner | `product-owner` | Owns story IDs, acceptance criteria, prioritization |
| Scrum Master | `scrum-master` | Enforces DoR/DoD, flow, traceability compliance |
| Developer | `developer` | Implements stories, updates tests and docs |
| QA/Test | `qa` | Ensures test linkage, coverage, and non-functional verification |
| Security | `security` | Threat modeling, security review checklist |
| DevOps | `devops` | CI, release readiness, deployment checks |

Agents are defined in `.opencode/agent` and wired in `.opencode/opencode.json`.

## Scrum Workflows

### 1) Sprint Planning

**Inputs**:
- Epics and story definitions
- Definition of Ready (DoR)
- Capacity and velocity metrics
- Azure Boards or GitHub backlog state

**Steps**:
1. Product Owner proposes backlog with story IDs
2. Scrum Master validates DoR for each candidate story
3. Developers estimate and break down technical tasks
4. QA and Security tag required tests and reviews
5. DevOps confirms release gating requirements

**Outputs**:
- Sprint backlog with story IDs
- Traceability expectations recorded per story

### 2) Sprint Execution

**Steps**:
1. Developers implement stories with tests referencing story IDs
2. QA verifies test coverage and traceability
3. Security performs targeted review for each story
4. DevOps runs CI gates and validates artifacts

**Required Artifacts**:
- Updated story file
- Test references for story ID
- ADRs if architecture changed

### 3) Sprint Review and Retrospective

**Review**:
- Demonstrate completed stories
- Generate release notes from commits
- Validate traceability report

**Retrospective**:
- Review compliance metrics
- Capture waivers and action items

## Metrics

- Story throughput per sprint
- Traceability compliance rate
- Coverage thresholds by layer
- Security findings per release
