# Scrum Team Structure

**Project Name**: [Project Name]
**Date**: [Creation Date]
**Last Updated**: [Last Updated Date]
**Framework**: Scrum
**Team Type**: Feature Team / Component Team / Platform Team / Squads / Tribe

---

## Team Overview

### Vision

[Describe the team's vision and purpose. What is the team trying to achieve?]

### Mission

[Describe the team's mission. How will the team achieve its vision?]

### Goals

**Primary Goal**: [Brief, measurable goal]
**Secondary Goals**:
- [ ] [Goal 1]
- [ ] [Goal 2]
- [ ] [Goal 3]

---

## Team Composition

### Team Members

| Name | Role | Specialization | Focus Area | Email |
|------|-------|---------------|-------------|--------|
| [Name] | [Developer/DevOps/QA/etc.] | [.NET/JavaScript/DevOps/etc.] | [Feature/Module/etc.] | [email] |
| [Name] | [Developer/DevOps/QA/etc.] | [.NET/JavaScript/DevOps/etc.] | [Feature/Module/etc.] | [email] |
| [Name] | [Developer/DevOps/QA/etc.] | [.NET/JavaScript/DevOps/etc.] | [Feature/Module/etc.] | [email] |

**Team Size**: [X] members
**Optimal Size**: 3-5 members for Feature Teams, 5-9 for Component Teams

### AI Agent Roles

| Agent | Role | Primary Focus |
| --- | --- | --- |
| product-owner | Product Owner | Story IDs, acceptance criteria, backlog |
| scrum-master | Scrum Master | DoR/DoD enforcement, flow, traceability |
| developer | Developer | Implementation, tests, documentation |
| qa | QA/Test | Coverage, test linkage, verification |
| security | Security | Threat modeling, security review |
| devops | DevOps | CI, release readiness, deployments |

### Roles and Responsibilities

#### Product Owner
**Name**: [Name]
**Responsibilities**:
- Owns product backlog and prioritization
- Defines user stories and acceptance criteria
- Accepts or rejects sprint deliverables
- Represents stakeholder interests
- Provides clear product vision

**Time Allocation**: [X]% (typically 50-75% for dedicated PO, less for shared)

**Location**: [Location: On-site / Remote / Hybrid]

#### Scrum Master
**Name**: [Name]
**Responsibilities**:
- Facilitates all Scrum ceremonies
- Removes impediments and blockers
- Coaches team on Scrum practices
- Ensures adherence to Definition of Done
- Protects team from external interruptions
- Tracks and reports team metrics

**Time Allocation**: [X]% (can serve multiple teams)

**Location**: [Location: On-site / Remote / Hybrid]

#### Development Team Members

**Team Lead (if applicable)**: [Name]
**Responsibilities**:
- Technical leadership
- Code review coordination
- Technical decision-making within team
- Mentoring junior team members
- Architectural guidance

#### Team Members

| Name | Skills | Responsibilities | Allocation |
|------|--------|-----------------|------------|
| [Name] | [.NET, React, PostgreSQL, Docker, etc.] | [Specific responsibilities] | [100%] |

---

## Team Charter

### Values

1. **[Value 1]**: [Description of how this value manifests]
2. **[Value 2]**: [Description of how this value manifests]
3. **[Value 3]**: [Description of how this value manifests]
4. **[Value 4]**: [Description of how this value manifests]

**Common Team Values**:
- Transparency: Open communication about progress and issues
- Respect: Respect different opinions and expertise
- Commitment: Committed to sprint goals and team success
- Focus: Focus on sprint work and avoid distractions
- Courage: Courage to speak up about issues and try new approaches
- Openness: Open to feedback and new ideas

### Norms and Working Agreements

#### Communication

- **Tools**: [Slack, Teams, Discord, email]
- **Response Time**: [Expected response time]
- **Meeting Etiquette**: [Be on time, no side conversations, etc.]
- **Decision Making**: [Consensus, majority vote, lead decision]

#### Collaboration

- **Code Review Process**: [Description of review process]
- **Knowledge Sharing**: [Regular presentations, pair programming, etc.]
- **Documentation Standards**: [API docs, code comments, design docs]
- **Pair Programming**: [When and how pair programming is used]

#### Quality Standards

- **Definition of Done**: [Reference or inline checklist]
- **Code Quality**: [Style guidelines, static analysis, etc.]
- **Testing Standards**: [Unit, integration, E2E requirements]
- **Review Process**: [Mandatory peer review, review checklist]

#### Process

- **Sprint Length**: [2 weeks / 3 weeks / other]
- **Ceremonies**: [Daily standup, sprint planning, review, retrospective]
- **Backlog Management**: [Tool and process]
- **Release Cadence**: [Continuous deployment, scheduled releases, etc.]

---

## Working Arrangements

### Location and Hours

**Location**: [Physical office / Remote / Hybrid]
**Time Zone**: [Primary time zone]
**Working Hours**: [e.g., 9:00 AM - 5:00 PM UTC]
**Core Hours**: [Hours when all team members should be available]

### Meetings and Collaboration

**Daily Standup**: [Time and platform]
**Sprint Planning**: [Day of week and duration]
**Sprint Review**: [Day of week and duration]
**Sprint Retrospective**: [Day of week and duration]
**Backlog Refinement**: [Day of week and duration]

**Collaboration Tools**:
- **Code Repository**: [Azure Repos / GitHub]
- **Project Management**: [Azure Boards / GitHub Projects]
- **Communication**: [Slack, Teams, Discord]
- **Documentation**: [Confluence, Notion, etc.]

---

## Capacity and Velocity

### Historical Velocity

**Average Velocity**: [X] story points per sprint
**Velocity Trend**: [Increasing / Stable / Decreasing]
**Velocity Range**: [Min] - [Max] points
**Number of Sprints**: [X] sprints of data

### Capacity Planning

**Team Members**: [X]
**Sprint Length**: [X] days
**Work Days**: [X] days (excluding weekends, holidays, time off)
**Focus Factor**: [X]% (percentage of productive time)
**Effective Capacity**: [X] days
**Available Hours**: [X] hours

**Capacity Formula**:
```
Effective Work Days = Work Days × Focus Factor
Available Capacity = (Effective Work Days × Velocity) / Sprint Length
```

### Example Calculation

```
Team Size: 6 developers
Sprint Length: 10 workdays
Focus Factor: 70%
Historical Velocity: 30 points/sprint

Effective Work Days = 6 × 10 × 0.70 = 42 days
Capacity = (42 × 30) / 10 = 126 points/sprint
```

---

## Dependencies

### External Dependencies

| Dependency | Type | Status | Owner | Risk Level |
|------------|------|---------|--------|-----------|
| [External API/Service] | [Technical/Business] | 📋 Pending / ✅ Available / ⚠️ At Risk | [Low/Medium/High] |
| [External Team/Feature] | [Upstream/Downstream] | 📋 Pending / ✅ Available / ⚠️ At Risk | [Low/Medium/High] |

### Internal Dependencies

| Dependency | Type | Status | Resolution Plan |
|------------|------|---------|----------------|
| [Other Team/Feature] | [Upstream/Downstream] | 📋 Pending / ✅ Complete | [Plan] |
| [Shared Component/Library] | [Technical] | 📋 Pending / ✅ Complete | [Plan] |

---

## Metrics and KPIs

### Sprint Metrics

| Metric | Target | Current | Status |
|--------|--------|---------|--------|
| Sprint Success Rate | >90% | [X]% | 🟢 On Track / 🟡 Behind / 🔴 Off Track |
| Story Completion Rate | >80% | [X]% | 🟢 On Track / 🟡 Behind / 🔴 Off Track |
| Velocity Stability | ±10% | [±X]% | 🟢 On Track / 🟡 Behind / 🔴 Off Track |

### Quality Metrics

| Metric | Target | Current | Status |
|--------|--------|---------|--------|
| Code Coverage | >80% | [X]% | 🟢 On Track / 🟡 Behind / 🔴 Off Track |
| Defect Escape Rate | <10% | [X]% | 🟢 On Track / 🟡 Behind / 🔴 Off Track |
| Code Quality Score | ≥ B | [Grade] | 🟢 On Track / 🟡 Behind / 🔴 Off Track |

### Process Metrics

| Metric | Target | Current | Status |
|--------|--------|---------|--------|
| Retrospective Action Completion | >90% | [X]% | 🟢 On Track / 🟡 Behind / 🔴 Off Track |
| Daily Standup Attendance | >95% | [X]% | 🟢 On Track / 🟡 Behind / 🔴 Off Track |
| Planning Accuracy | Within ±10% | [±X]% | 🟢 On Track / 🟡 Behind / 🔴 Off Track |

---

## Risks and Challenges

### Current Risks

| Risk | Probability | Impact | Mitigation Strategy | Owner |
|------|-------------|---------|-------------------|--------|
| [Risk 1] | 🟢 Low / 🟡 Medium / 🔴 High | 🟢 Low / 🟡 Medium / 🔴 High | [Strategy] | [Name] |
| [Risk 2] | 🟢 Low / 🟡 Medium / 🔴 High | 🟢 Low / 🟡 Medium / 🔴 High | [Strategy] | [Name] |

### Known Challenges

**[Challenge 1]**: [Description and current mitigation]

**[Challenge 2]**: [Description and current mitigation]

**[Challenge 3]**: [Description and current mitigation]

---

## Success Criteria

### Team Success

- [ ] Team members are engaged and motivated
- [ ] Team velocity is stable or increasing
- [ ] Sprint goals are consistently met (>90%)
- [ ] Quality metrics meet or exceed targets
- [ ] Stakeholders are satisfied with deliverables

### Product Success

- [ ] Features deliver customer value
- [ ] Product backlog is well-managed
- [ ] Release cadence is predictable
- [ ] Customer satisfaction is high
- [ ] Time to market is acceptable

---

## Continuous Improvement

### Improvement Areas

**Process Improvements**:
1. [Area 1]: [Action plan]
2. [Area 2]: [Action plan]
3. [Area 3]: [Action plan]

**Technical Improvements**:
1. [Area 1]: [Action plan]
2. [Area 2]: [Action plan]
3. [Area 3]: [Action plan]

**Team Improvements**:
1. [Area 1]: [Action plan]
2. [Area 2]: [Action plan]
3. [Area 3]: [Action plan]

### Learning and Development

**Training Needs**:
- [ ] [Skill 1]: [Training plan]
- [ ] [Skill 2]: [Training plan]
- [ ] [Skill 3]: [Training plan]

**Knowledge Sharing**:
- **Weekly**: [Topic]
- **Bi-weekly**: [Topic]
- **Monthly**: [Topic]

---

## Review and Approval

### Team Charter Approval

**Product Owner**: [Signature] - [Date]
**Scrum Master**: [Signature] - [Date]
**Development Team**: [Signatures] - [Date]
**Engineering Management**: [Signature] - [Date] (if applicable)

### Charter Review

**Frequency**: Quarterly or when team composition changes significantly
**Last Review**: [Date]
**Next Review**: [Date]

---

## Notes and Attachments

[Additional context, links to documents, diagrams, etc.]

---

**Version History**:

| Version | Date | Changes | Approved By |
|---------|-------|---------|-------------|
| 1.0 | [Date] | Initial team charter | [Name] |

---

**Remember**: A high-performing Scrum team is built on trust, collaboration, and continuous improvement. Use this structure to create and maintain effective teams!**
