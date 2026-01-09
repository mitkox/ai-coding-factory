# Agile Methodology & Scrum Framework

AI Coding Factory incorporates a comprehensive **Enterprise Agile Framework** designed to bridge the gap between AI-generated code and human-managed delivery. This document outlines the methodology, ceremonies, artifacts, and roles used within the system.

---

## Core Philosophy

Our approach combines the structure of **Scrum** with the flow of **Kanban**, enforcing quality through rigorous **Definition of Done (DoD)** and **Definition of Ready (DoR)** standards.

### The "AI Agile" Manifesto
1. **Working Code** over comprehensive documentation (though we generate both).
2. **AI Collaboration** over autonomous replacement.
3. **Continuous Verification** over post-development testing.
4. **Structured Prompts** over vague requirements.

---

## Scrum Framework

### 1. Sprints
- **Duration**: 2 weeks (default)
- **Focus**: Delivering a potentially shippable Increment.
- **Sprint Goal**: A concise objective for the sprint (e.g., "Implement User Authentication").

### 2. Roles

| Role | Human Responsibility | AI Agent Support |
|------|----------------------|------------------|
| **Product Owner** | Vision, ROI, Priority | **Ideation Agent**: Generates stories, acceptance criteria, roadmap alignment. |
| **Scrum Master** | Process, Coaching, Blocking | **Product Agent**: Facilitates retrospectives, tracks velocity, identifies blockers. |
| **Developers** | Architecture, Coding, QA | **Prototype, PoC, Pilot Agents**: Code generation, testing, security scanning. |

### 3. Ceremonies

#### 🗓️ Sprint Planning
- **Goal**: Define *what* to deliver and *how* to deliver it.
- **AI Support**: usage of `net-agile` skill to estimate story points and break down tasks.

#### 🔄 Daily Standup
- **Goal**: Synchronization and blocker identification.
- **AI Support**: Automated status updates from agents on ongoing tasks.

#### 🔎 Sprint Review
- **Goal**: Inspect the Incrment and adapt the Backlog.
- **AI Support**: Generation of demo scripts and release notes.

#### 💡 Sprint Retrospective
- **Goal**: Continuous improvement.
- **AI Support**: Analysis of sprint metrics (velocity, bug rate) and suggestion of process improvements.

---

## Artifacts

### 1. Product Backlog
An ordered list of everything that is known to be needed in the product.
- **Items**: Epics, User Stories, Bugs, Tech Debt.
- **Prioritization**: MoSCoW (Must, Should, Could, Won't).
- **Tracking**: Azure Boards or GitHub Issues/Projects

### 2. Sprint Backlog
The set of Product Backlog items selected for the Sprint.

### 3. User Stories
Standard format:
> "As a `<role>`, I want `<feature>` so that `<benefit>`."

**INVEST Criteria**:
- **I**ndependent
- **N**egotiable
- **V**aluable
- **E**stimable
- **S**mall
- **T**estable

### 4. Increments
The sum of all Product Backlog items completed during a Sprint and the value of the increments of all previous Sprints.

---

## Quality Gates

### ✅ Definition of Ready (DoR)
A story is ready to be worked on when:
1. [ ] Story is written in standard format
2. [ ] Acceptance criteria are clearly defined
3. [ ] Estimated constraints (size) are assigned
4. [ ] Dependencies are identified
5. [ ] UX/UI mockups are available (if applicable)

### ✅ Definition of Done (DoD)
A story is considered complete when:
1. [ ] Code is peer-reviewed (or agent-reviewed)
2. [ ] Unit tests pass (>80% coverage)
3. [ ] Integration tests pass
4. [ ] No critical/high severity security issues
5. [ ] Documentation is updated
6. [ ] Feature works in staging environment
7. [ ] Acceptance criteria are met
8. [ ] Traceability complete (story -> test -> commit -> release)

---

## Traceability and Story IDs

- Each story has a unique ID (`ACF-###`)
- Tests reference story IDs via naming, trait, or structured comment
- Commit messages include story IDs
- Release notes are generated from story IDs in commits

---

## AI Agent Integration

How the 5 Agents map to Agile stages:

| Stage | Agent | Agile Activity |
|-------|-------|----------------|
| **Concept** | `Ideation` | Backlog Refinement, User Story creation, Epic breakdown |
| **Inception**| `Prototype`| Spikes, Feasibility studies, MVP validation |
| **Build** | `PoC` | Implementation of core logic, meeting DoR |
| **Verify** | `Pilot` | Ensuring DoD compliance, CI/CD checks, Testing |
| **Release** | `Product` | Release planning, Production monitoring, Retrospectives |

---

## Metrics & KPIs

We track the following metrics to ensure health:

1. **Velocity**: Average story points completed per sprint.
2. **Cycle Time**: Time from "In Progress" to "Done".
3. **Code Coverage**: Percentage of code covered by tests (Target: >80%).
4. **Defect Density**: Bugs per 1K lines of code.

---

## Scaling

For larger enterprises, this framework supports scaling patterns:
- **Scrum of Scrums**: For coordinating multiple AI/Human teams.
- **Nexus**: For managing cross-team dependencies.
- **SAFe**: Essential SAFe configuration for portfolio management.

---

*This methodology is enforced via the `net-agile` and `net-scrum` skills found in `.opencode/skill/`.*
