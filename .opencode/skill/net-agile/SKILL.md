---
name: net-agile
description: Implement agile development practices and ceremonies for .NET projects
license: MIT
compatibility: opencode
metadata:
  audience: .net-developers
  methodology: agile
  frameworks: scrum, kanban
---

## What I Do

I help you implement enterprise agile practices:
- User story creation and grooming
- Sprint planning and tracking
- Definition of Done (DoD)
- Definition of Ready (DoR)
- Agile ceremonies (standups, retrospectives)
- Velocity tracking and estimation
- Backlog management
- Continuous integration and delivery

## When to Use Me

Use this skill when:
- Planning a new sprint or iteration
- Creating or grooming user stories
- Setting up agile ceremonies
- Implementing DoD and DoR
- Tracking team velocity
- Managing product backlog

## Agile Artifacts

### User Story Template
```markdown
## [ID] - [Title]

**Priority**: Must Have / Should Have / Could Have / Won't Have
**Estimate**: Story Points
**Sprint**: [Sprint Number]
**Status**: Backlog / In Progress / In Review / Done

### User Story
As a [type of user],
I want to [perform an action],
So that I can [achieve a goal].

### Acceptance Criteria
- [ ] Given [precondition], when [action], then [expected outcome]
- [ ] [Additional criteria]
- [ ] [Edge cases]

### Definition of Done
- [ ] Code written and reviewed
- [ ] Unit tests with >80% coverage
- [ ] Integration tests pass
- [ ] Documentation updated
- [ ] Code quality checks pass
- [ ] Deployed to staging

### Tasks
- [ ] [Technical task 1]
- [ ] [Technical task 2]
- [ ] [Technical task 3]

### Definition of Ready
- [ ] User story has clear acceptance criteria
- [ ] Technical approach defined
- [ ] Dependencies identified
- [ ] Story estimated by team
- [ ] DoD agreed upon

### Notes
[Additional context, constraints, or risks]
```

### Sprint Planning Template
```markdown
## Sprint [Number] Planning

**Start Date**: [Date]
**End Date**: [Date]
**Sprint Goal**: [Brief goal statement]

### Team Velocity
- Previous Sprint Velocity: [points]
- Current Sprint Capacity: [points]

### Stories in Sprint
| ID | Story | Points | Priority | Owner |
|-----|-------|--------|----------|--------|
| 1   |       |        |          |        |
| 2   |       |        |          |        |

### Risks and Impediments
- [ ] [Risk 1]
- [ ] [Risk 2]

### Definition of Done for Sprint
- [ ] All user stories meet story DoD
- [ ] All tests pass (unit, integration, E2E)
- [ ] Code review completed
- [ ] Documentation updated
- [ ] Deployed to staging
- [ ] Stakeholder acceptance
- [ ] Sprint retrospective completed
```

### Daily Standup Template
```markdown
## Daily Standup - [Date]

### Team
- [ ] Team Member 1
- [ ] Team Member 2
- [ ] Team Member 3

### Updates

**[Name]**:
- **Yesterday**: What did I complete?
- **Today**: What will I work on?
- **Blockers**: Any impediments?

**[Name]**:
- **Yesterday**: What did I complete?
- **Today**: What will I work on?
- **Blockers**: Any impediments?

### Action Items
- [ ] [Action item 1]
- [ ] [Action item 2]
```

### Sprint Retrospective Template
```markdown
## Sprint [Number] Retrospective

**Date**: [Date]
**Participants**: [List]

### What Went Well
1. [Positive outcome 1]
2. [Positive outcome 2]
3. [Positive outcome 3]

### What Didn't Go Well
1. [Challenge 1]
2. [Challenge 2]
3. [Challenge 3]

### Action Items for Next Sprint
| Issue | Action Item | Owner | Due Date |
|-------|-------------|--------|----------|
| 1     |             |        |          |
| 2     |             |        |          |

### Process Improvements
1. [Improvement 1]
2. [Improvement 2]

### Metrics
- Sprint Velocity: [points]
- Stories Completed: [count] / [total]
- Defects Found: [count]
- Deployments: [count]
- Average Cycle Time: [days]
```

## Enterprise Agile Best Practices

### 1. User Story Management

**User Story INVEST Criteria:**
- **I**ndependent: Story can be delivered independently
- **N**egotiable: Details can be negotiated
- **V**aluable: Delivers value to stakeholder
- **E**stimable: Can estimate effort
- **S**mall: Can be completed in one sprint
- **T**estable: Can verify acceptance criteria

**Story Estimation:**
- Use Fibonacci sequence (1, 2, 3, 5, 8, 13, 21)
- Planning Poker for team consensus
- Consider complexity and uncertainty
- Include testing and deployment time

### 2. Sprint Planning

**Sprint Length:**
- Standard: 2 weeks
- Adjust based on team velocity
- Maintain consistent cadence

**Capacity Planning:**
- Calculate team velocity from previous sprints
- Account for holidays, time off
- Buffer for unplanned work (10-20%)
- Consider technical debt reduction

### 3. Daily Standups

**Format:**
- **15 minutes** max timebox
- **Three questions** per person
- **Focus on blockers** and collaboration
- **Standing** to keep it short

**Three Questions:**
1. What did you accomplish yesterday?
2. What will you work on today?
3. Do you have any blockers?

### 4. Sprint Review

**Purpose:**
- Demonstrate completed work
- Get stakeholder feedback
- Accept or reject user stories
- Adjust backlog based on feedback

**Agenda:**
1. Demo completed stories (1-2 min each)
2. Stakeholder feedback and acceptance
3. Sprint metrics review
4. Adjust backlog if needed

### 5. Sprint Retrospective

**Format:**
- Start, Stop, Continue (or What Went Well / What Didn't Go Well)
- Blameless environment
- Focus on process, not people
- Create action items with owners

**Key Questions:**
- What should we start doing?
- What should we stop doing?
- What should we continue doing?

### 6. Backlog Management

**Prioritization Frameworks:**

**MoSCoW Method:**
- **M**ust Have: Critical for release
- **S**hould Have: Important but not critical
- **C**ould Have: Nice to have if time permits
- **W**on't Have: Out of scope

**Kano Model:**
- Basic needs: Must have features
- Performance needs: Differentiators
- Excitement needs: Delighters

**WSJF (Weighted Shortest Job First):**
- Score = (Value + Urgency) / Size
- Prioritize highest score first

**Backlog Grooming:**
- Weekly backlog refinement
- Break down large stories (epics → features → stories)
- Ensure stories are DoD/DoR compliant
- Keep top 3-4 sprints detailed, rest at high level

### 7. Definition of Done (DoD)

**Enterprise DoD Checklist:**
```markdown
### Code Quality
- [ ] Code follows project coding standards
- [ ] Code reviewed and approved
- [ ] Static code analysis passes (SonarQube)
- [ ] No critical or high severity security vulnerabilities
- [ ] Code complexity within acceptable limits

### Testing
- [ ] Unit tests written and passing (>80% coverage)
- [ ] Integration tests written and passing
- [ ] E2E tests for critical user flows
- [ ] Performance tests meet SLA requirements
- [ ] Accessibility tests pass (WCAG 2.1 AA)

### Documentation
- [ ] API documentation updated (Swagger/OpenAPI)
- [ ] Code comments added for complex logic
- [ ] Architecture decision records (ADRs) updated
- [ ] User documentation updated (if applicable)
- [ ] Runbook updated (if applicable)

### Deployment
- [ ] Application builds successfully
- [ ] Deployed to staging environment
- [ ] Smoke tests pass on staging
- [ ] Database migrations tested
- [ ] Rollback plan documented

### Process
- [ ] User story meets acceptance criteria
- [ ] Stakeholder acceptance received
- [ ] QA sign-off completed
- [ ] Product owner approval received
```

### 8. Definition of Ready (DoR)

**Story DoR Checklist:**
```markdown
### Story Quality
- [ ] Story follows INVEST criteria
- [ ] Acceptance criteria are clear and testable
- [ ] Story is properly sized for single sprint
- [ ] Dependencies identified and documented
- [ ] Risks identified and mitigations planned

### Technical Readiness
- [ ] Technical approach understood
- [ ] Design documents reviewed
- [ ] API contracts defined
- [ ] Database schema changes identified
- [ ] Third-party integrations researched

### Team Readiness
- [ ] Story estimated by team
- [ ] Capacity verified
- [ ] Skills needed are available
- [ ] Owner assigned
- [ ] Dependencies scheduled
```

### 9. Continuous Integration/Continuous Delivery (CI/CD)

**CI/CD Best Practices:**
- Automated builds on every commit
- Automated testing on every build
- Automated code quality checks
- Automated security scanning
- Feature flags for gradual rollout
- Blue-green deployments
- Automated rollback capability
- Monitoring and alerting

### 10. Metrics and KPIs

**Key Agile Metrics:**

**Velocity Metrics:**
- Sprint velocity (points completed)
- Story completion rate
- Cycle time (story start to finish)
- Lead time (story creation to finish)

**Quality Metrics:**
- Defect escape rate
- Test coverage percentage
- Code quality score
- Security vulnerabilities found

**Process Metrics:**
- Sprint success rate
- Blocker resolution time
- Retrospective action completion
- Stakeholder satisfaction

**Delivery Metrics:**
- Deployment frequency
- Change lead time
- Mean time to recovery (MTTR)
- Release success rate

## Example Usage

```
Use net-agile skill to:

1. Create user stories for a feature
2. Plan a new sprint
3. Set up Definition of Done
4. Create retrospective template
5. Track sprint velocity
6. Manage product backlog
```

I will generate complete agile artifacts and documentation.