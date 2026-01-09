# Multi-Team Coordination (Scrum of Scrums)

**Project Name**: [Project Name]
**Date**: [Creation Date]
**Last Updated**: [Last Updated Date]
**Framework**: Scrum of Scrums
**Team Structure**: [Single Team / Scrum of Scrums / LeSS / SAFe / Nexus]

---

## Overview

### Coordination Structure

| Level | Teams | Coordination Body | Frequency |
|-------|-------|------------------|----------|
| Team Level | [Team names] | Team-specific Scrum of Scrums | Weekly |
| Program Level | [Team groups] | Chief Product Owner | Weekly |
| Product Level | [All teams] | Scrum of Scrums (representatives from all teams) | Bi-weekly |
| Portfolio Level | [All teams] | Portfolio Management Team | Monthly |

---

## Team Structure

### Scrum of Scrums Configuration

#### Teams Map

| Team Name | Type | Members | Focus Area | PO | SM |
|----------|------|---------|-----------|-----|----|
| [Team A] | Feature / Component / Platform | [Count] | [Area] | [Name] | [Name] |
| [Team B] | Feature / Component / Platform | [Count] | [Area] | [Name] | [Name] |
| [Team C] | Feature / Component / Platform | [Count] | [Area] | [Name] | [Name] |
| [Team D] | Feature / Component / Platform | [Count] | [Area] | [Name] | [Name] |

#### Team Dependencies

| Dependent Team | Dependency | Type | Status | Risk Level |
|-----------------|-----------|-----|---------|-----------|
| [Team A] | [Depends on Team B] | [Technical/Business] | 📋 Pending / ✅ Available / ⚠️ At Risk | 🟢 Low / 🟡 Medium / 🔴 High |
| [Team B] | [Depends on Team C] | [Technical/Business] | 📋 Pending / ✅ Available / ⚠️ At Risk | 🟢 Low / 🟡 Medium / 🔴 High |
| [Team C] | [Depends on Team D] | [Technical/Business] | 📋 Pending / ✅ Available / ⚠️ At Risk | 🟢 Low / 🟡 Medium / 🔴 High |

---

## Coordination Roles

### Chief Product Owner

**Name**: [Name]
**Responsibilities**:
- [ ] Owns overall product vision and roadmap
- [ ] Coordinates Product Owners across all teams
- [ ] Manages product backlog at portfolio level
- [ ] Makes final decisions on trade-offs between teams
- [ ] Ensures alignment across teams
- [ ] Represents product to stakeholders and leadership

**Time Allocation**: [X]% of time (can serve multiple teams)

### Scrum of Scrums Master

**Name**: [Name]
**Responsibilities**:
- [ ] Coordinates all Scrum Masters
- [ ] Facilitates joint ceremonies (sprint planning, review, retrospectives)
- [ ] Ensures consistent Scrum practices across teams
- [ ] Identifies and resolves cross-team dependencies
- [ ] Tracks overall program velocity and metrics
- [ ] Removes impediments blocking teams

**Time Allocation**: [X]% of time (dedicated coordination role)

### Release Train Engineer

**Name**: [Name]
**Responsibilities**:
- [ ] Coordinates releases across all teams
- [ ] Manages release calendar and milestones
- [ ] Ensures integration points are tested
- [ ] Manages deployment pipelines
- [ ] Coordinates testing across teams
- [ ] Facilitates release planning and retrospectives

**Time Allocation**: [X]% of time

### Architecture Team (if applicable)

**Lead**: [Name]
**Responsibilities**:
- [ ] Defines architectural principles and standards
- [ ] Reviews architecture across all teams
- [ ] Approves major architectural changes
- [ ] Resolves architectural conflicts
- [ ] Ensures technical standards are followed

---

## Coordination Cadence

### Daily Coordination

**Scrum of Scrums Meeting**
- **Frequency**: Daily
- **Duration**: 30 minutes
- **Participants**: Scrum Master from each team
- **Agenda**:
  - Daily updates from each team
  - Cross-team blockers
  - Escalated issues
  - Daily priority adjustments

### Weekly Coordination

**Product Owner Sync**
- **Frequency**: Weekly
- **Duration**: 1 hour
- **Participants**: All Product Owners, Chief Product Owner, Scrum of Scrums Master
- **Agenda**:
  - Portfolio roadmap review
  - Cross-team priorities
  - Dependency coordination
  - Resource allocation

**Scrum Master Sync**
- **Frequency**: Weekly
- **Duration**: 30 minutes
- **Participants**: All Scrum Masters, Scrum of Scrums Master
- **Agenda**:
  - Team velocity comparison
  - Best practices sharing
  - Common impediments discussion
  - Process improvement ideas

**Release Planning**
- **Frequency**: Weekly (or per release)
- **Duration**: 2 hours
- **Participants**: Scrum of Scrums, Release Train Engineer, Team representatives
- **Agenda**:
  - Release timeline and milestones
  - Feature coordination
  - Integration testing planning
  - Risk assessment

### Bi-Weekly Coordination

**Sprint Planning (All Teams)**
- **Frequency**: Bi-weekly
- **Duration**: 2 hours
- **Participants**: All teams
- **Agenda**:
  - Program increment (PI) goals
  - Team capacity allocation
  - Story allocation to teams
  - Cross-team dependencies

**Sprint Review (All Teams)**
- **Frequency**: Bi-weekly
- **Duration**: 1.5 hours
- **Participants**: All teams, stakeholders
- **Agenda**:
  - Demo of all team increments
  - Stakeholder feedback
  - Program increment validation

### Monthly Coordination

**Retrospective (All Teams)**
- **Frequency**: Monthly
- **Duration**: 2 hours
- **Participants**: All teams
- **Agenda**:
  - What went well across all teams
  - What didn't go well
  - Process improvements
  - Action items with owners

**Portfolio Review**
- **Frequency**: Monthly
- **Duration**: 1.5 hours
- **Participants**: Chief Product Owner, Product Owners, Stakeholders, Leadership
- **Agenda**:
  - Portfolio health and metrics
  - Strategic roadmap review
  - Business value assessment
  - Resource planning

---

## Cross-Team Dependencies Management

### Dependency Tracking

| Dependency ID | From Team | To Team | Type | Status | Owner | Target Date |
|----------------|-----------|---------|-----|---------|--------|-------------|
| [ID] | [Team A] | [Team B] | [Technical/Business/API/Database] | 📋 Pending / 🚧 In Progress / ✅ Complete | [Name] | [Date] |
| [ID] | [Team C] | [Team A] | [Technical/Business/API/Database] | 📋 Pending / 🚧 In Progress / ✅ Complete | [Name] | [Date] |
| [ID] | [Team B] | [Team C] | [Technical/Business/API/Database] | 📋 Pending / 🚧 In Progress / ✅ Complete | [Name] | [Date] |

### Risk Management

| Risk | Teams Affected | Probability | Impact | Mitigation Strategy | Owner | Status |
|------|---------------|-------------|---------|-------------------|--------|--------|
| [Risk 1] | [Teams] | 🟢 Low / 🟡 Medium / 🔴 High | 🟢 Low / 🟡 Medium / 🔴 High | [Strategy] | [Name] | 📋 Pending / 🚧 In Progress / ✅ Complete |
| [Risk 2] | [Teams] | 🟢 Low / 🟡 Medium / 🔴 High | 🟢 Low / 🟡 Medium / 🔴 High | [Strategy] | [Name] | 📋 Pending / 🚧 In Progress / ✅ Complete |

---

## Program Management

### Program Increment (PI) Planning

**PI**: [PI Number]
**Start Date**: [Date]
**End Date**: [Date]
**Duration**: [X] sprints (8-10 weeks)

**PI Objectives**:
1. [ ] [Objective 1]
2. [ ] [Objective 2]
3. [ ] [Objective 3]

**PI Goals**:
| Team | Goals | Dependencies | Stories Allocated | Capacity Used |
|------|-------|-------------|-------------------|--------------|
| [Team A] | [Goals] | [Dependencies] | [X] stories / [X] points | [X]% |
| [Team B] | [Goals] | [Dependencies] | [X] stories / [X] points | [X]% |
| [Team C] | [Goals] | [Dependencies] | [X] stories / [X] points | [X]% |

**PI Metrics**:
- Total Points: [X]
- Total Stories: [X]
- Teams Participating: [X]
- Target PI End Date: [Date]

### Sprint Planning for All Teams

**Sprint**: [Number] (within PI)
**Planning Meeting Date**: [Date]
**Planning Meeting Duration**: 2 hours

**Team Allocations**:

| Team | PO | SM | Team Size | Capacity (Points) | Stories Committed |
|------|-------|----|----------|----------------|----------------|
| [Team A] | [Name] | [Name] | [X] | [X] | [X] |
| [Team B] | [Name] | [Name] | [X] | [X] | [X] |
| [Team C] | [Name] | [Name] | [X] | [X] | [X] |

**Cross-Team Coordination**:
- Dependencies identified and documented
- Integration points defined
- Shared resources allocated
- Testing coordination planned

---

## Communication Channels

### Coordination Channels

| Channel | Purpose | Members | Frequency |
|---------|---------|---------|----------|
| Scrum of Scrums Slack | Daily coordination | All Scrum Masters | Daily |
| Product Owners Channel | Portfolio management | All Product Owners + CPO | Weekly |
| Architecture Channel | Technical coordination | Tech leads + Architects | Weekly |
| Release Train Channel | Release coordination | All teams + RTE | Weekly |
| All-Hands Channel | Announcements | All team members | As needed |

### Decision Making

**Escalation Paths**:
- **Team Level**: Team-specific issues resolved at team level
- **Coordination Level**: Cross-team issues escalated to Scrum of Scrums
- **Program Level**: Strategic issues escalated to CPO and Leadership
- **Governance**: Major changes require stakeholder approval

**Decision Framework**:
1. **Technical Decisions**: Architecture team + Tech leads
2. **Product Decisions**: Product Owners + CPO
3. **Process Decisions**: Scrum of Scrums + Scrum Masters
4. **Resource Decisions**: CPO + Line management

---

## Metrics and Reporting

### Program Metrics

| Metric | Target | Current | Trend |
|--------|--------|---------|-------|
| PI Velocity | [X] points/PI | [X] | [↑→→/↓→→/→] |
| Sprint Success Rate | >90% | [X]% | [↑→→/↓→→/→] |
| Cross-Team Blockers | <5 at any time | [X] | [↑→→/↓→→/→] |
| Dependency Resolution Time | <5 days | [X] days | [↑→→/↓→→/→] |
| Release Success Rate | >95% | [X]% | [↑→→/↓→→/→] |

### Team-Level Metrics

| Team | Velocity | Stability | Quality Score | Satisfaction |
|------|---------|-----------|--------------|------------|
| [Team A] | [X] | [↑→→/↓→→/→] | [Grade] | [1-5] |
| [Team B] | [X] | [↑→→/↓→→/→] | [Grade] | [1-5] |
| [Team C] | [X] | [↑→→/↓→→/→] | [Grade] | [1-5] |

### Reporting

**Daily Dashboard**: Program-level metrics updated
- Team status and progress
- Cross-team blockers
- Incidents and escalations

**Weekly Report**: Sent to all stakeholders
- Program progress summary
- Risk and dependency status
- Upcoming releases

**Monthly Review**: Executive summary
- Program health metrics
- Strategic roadmap updates
- Budget and resource utilization

---

## Release Management

### Release Roadmap

| Release | Version | Target Date | Features | Teams Involved | Status |
|---------|---------|------------|---------|---------------|---------|
| [R1.0] | [Version] | [Date] | [Feature list] | [Teams] | 📋 Planning / 🚧 Development / 🧪 Testing / ✅ Released |
| [R1.1] | [Version] | [Date] | [Feature list] | [Teams] | 📋 Planning / 🚧 Development / 🧪 Testing / ✅ Released |
| [R2.0] | [Version] | [Date] | [Feature list] | [Teams] | 📋 Planning / 🚧 Development / 🧪 Testing / ✅ Released |

### Release Readiness Checklist

- [ ] All Definition of Done items met
- [ ] Integration tests passing
- [ ] E2E tests passing
- [ ] Security scan passed
- [ ] Performance tests meet SLA
- [ ] Documentation complete
- [ ] Rollback plan tested
- [ ] Communication plan ready
- [ ] Stakeholder approval received
- [ ] Deployment window confirmed

---

## Best Practices

### Coordination

1. **Clear Communication Channels**
   - Established channels for different purposes
   - Right people in right channels
   - Async communication for non-urgent items

2. **Consistent Cadence**
   - Regular meetings with consistent schedule
   - Time-boxed ceremonies
   - Respect everyone's time

3. **Early Dependency Identification**
   - Identify dependencies early in PI planning
   - Communicate dependencies clearly
   - Track and manage dependencies actively

4. **Shared Definition of Done**
   - Consistent DoD across all teams
   - Quality standards shared
   - Integration testing requirements defined

5. **Cross-Team Collaboration**
   - Encourage cross-team knowledge sharing
   - Pair programming across teams
   - Shared code reviews
   - Joint design sessions

### Team Autonomy

1. **Team Self-Organization**
   - Teams organize their own work
   - Team decides how to achieve sprint goals
   - Cross-team dependencies are exceptions

2. **Clear Boundaries**
   - Clear responsibilities and accountabilities
   - Minimize cross-team interference
   - Respect team autonomy

3. **Alignment Through Vision**
   - Shared product vision aligns teams
   - Clear program objectives guide autonomy
   - Coordination provides direction, not control

### Scaling Considerations

1. **Start Small**
   - Begin with 2-3 teams
   - Scale up as framework matures
   - Learn from each scaling step

2. **Maintain Culture**
   - Preserve team culture as scaling
   - Keep practices that work
   - Adapt framework as needed

3. **Invest in Coordination**
   - Dedicate resources to coordination
   - Don't underestimate coordination overhead
   - Scale coordination team with teams

---

## Continuous Improvement

### Regular Assessments

**Quarterly Review**:
- [ ] Team effectiveness evaluation
- [ ] Process efficiency assessment
- [ ] Coordination overhead review
- [ ] Tooling and infrastructure review
- [ ] Team satisfaction survey

**Optimization Areas**:
- [ ] Reduce coordination overhead
- [ ] Improve cross-team communication
- [ ] Streamline decision making
- [ ] Enhance dependency management
- [ ] Better alignment of incentives

### Experiments

**Current Experiments**:
- [ ] [Experiment 1]: [Description] - [Owner] - [Expected Outcome]
- [ ] [Experiment 2]: [Description] - [Owner] - [Expected Outcome]

---

## Appendices

### Contact Information

| Role | Name | Email | Phone | Time Zone |
|-------|------|-------|-------|-----------|
| Chief Product Owner | [Name] | [email] | [phone] | [TZ] |
| Scrum of Scrums Master | [Name] | [email] | [phone] | [TZ] |
| Release Train Engineer | [Name] | [email] | [phone] | [TZ] |

### Meeting Schedule

| Meeting | Day | Time | Location | Participants |
|---------|-----|--------|----------|-------------|
| Daily Scrum of Scrums | [Mon-Fri] | [Time] | [Platform] | All Scrum Masters |
| Product Owner Sync | [Day] | [Time] | [Platform] | All POs + CPO |
| Release Planning | [Day] | [Time] | [Platform] | Scrum of Scrums + Reps |
| PI Planning | [Day] | [Time] | [Platform] | All teams |

### Links and Resources

- [Product Backlog]: [URL]
- [Program Board]: [URL]
- [Architecture Documentation]: [URL]
- [Release Roadmap]: [URL]
- [Metrics Dashboard]: [URL]

---

**Version History**:

| Version | Date | Changes | Approved By |
|---------|-------|---------|-------------|
| 1.0 | [Date] | Initial multi-team coordination template | [Name] |

---

**Remember**: Effective multi-team coordination balances alignment with autonomy. Keep communication clear, dependencies managed, and focus on delivering value!**