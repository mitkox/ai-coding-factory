---
name: net-scrum
description: Implement Scrum framework and team structures for .NET enterprise projects
license: MIT
compatibility: opencode
metadata:
  audience: .net-developers
  methodology: scrum
  frameworks: less, safe, nexus,规模化敏捷
  enterprise: true
---

## What I Do

I help you implement enterprise Scrum framework:
- Scrum team structures and roles
- Scrum ceremonies (events) orchestration
- Scrum artifacts creation and management
- Multi-team coordination (Scrum of Scrums)
- Enterprise scaling (LeSS, SAFe, Nexus)
- Scrum metrics and reporting
- Team composition and capacity planning

## When to Use Me

Use this skill when:
- Setting up new Scrum team
- Restructuring existing teams for better alignment
- Implementing multi-team coordination
- Scaling Scrum to enterprise level
- Creating Scrum artifacts (backlogs, reports)
- Managing team capacity and velocity
- Coordinating releases across teams

## Scrum Roles

### Product Owner
**Responsibilities**:
- Owns product vision and roadmap
- Manages and prioritizes product backlog
- Accepts or rejects sprint deliverables
- Represents stakeholder interests
- Defines user stories and acceptance criteria

**Skills Required**:
- Product management
- Stakeholder communication
- Domain expertise
- Prioritization skills
- Decision-making ability

### Scrum Master
**Responsibilities**:
- Facilitates all Scrum ceremonies
- Removes impediments and blockers
- Coaches team on Scrum practices
- Protects team from external interruptions
- Ensures adherence to Definition of Done
- Tracks and reports team metrics

**Skills Required**:
- Facilitation and coaching
- Conflict resolution
- Process management
- Communication skills
- Problem-solving

### Development Team
**Responsibilities**:
- Self-organizes to complete sprint goals
- Estimates work and commits to sprint backlog
- Delivers working software incrementally
- Participates in all Scrum ceremonies
- Collaborates across team members
- Ensures quality standards

**Skills Required**:
- Technical expertise (.NET, databases, etc.)
- Cross-functional skills (frontend, backend, DevOps, QA)
- Collaboration and communication
- Self-motivation and accountability

### Stakeholders
**Responsibilities**:
- Provide feedback on increments
- Participate in sprint reviews
- Influence product roadmap and priorities
- Validate business value

## Scrum Artifacts

### Product Backlog
**Purpose**: Ordered list of all desired work for product
**Management**:
- Prioritized by Product Owner
- INVEST-compliant user stories
- Includes features, enhancements, bugs, technical debt
- Estimated by team
- Regularly refined and updated

### Sprint Backlog
**Purpose**: Subset of product backlog for current sprint
**Management**:
- Created during sprint planning
- Commitment from development team
- Contains tasks and technical work items
- Tracked throughout sprint

### Increment
**Purpose**: Sum of all work completed during sprint
**Characteristics**:
- Potentially shippable product increment
- Meets Definition of Done
- Demonstrated in sprint review

### Definition of Done (DoD)
**Purpose**: Shared understanding of completed work
**Components**:
- Code quality standards
- Testing requirements
- Documentation requirements
- Security requirements
- Deployment criteria

### Definition of Ready (DoR)
**Purpose**: Shared understanding of ready-for-development work
**Components**:
- Story quality criteria
- Acceptance criteria clarity
- Technical readiness
- Dependencies status
- Team capacity

## Scrum Ceremonies

### Sprint Planning
**Duration**: 2 hours for 2-week sprint
**Participants**: Product Owner, Scrum Master, Development Team
**Purpose**: Plan work for upcoming sprint
**Outputs**:
- Sprint backlog with committed stories
- Sprint goal and success criteria
- Task breakdown with estimates
- Risk identification

### Daily Scrum (Daily Standup)
**Duration**: 15 minutes timebox
**Participants**: Scrum Master, Development Team
**Purpose**: Synchronize daily work and identify blockers
**Format**: 3 questions per person
- What did you complete yesterday?
- What will you work on today?
- Do you have any blockers?

### Sprint Review (Demo)
**Duration**: 1 hour for 2-week sprint
**Participants**: Product Owner, Scrum Master, Development Team, Stakeholders
**Purpose**: Inspect and adapt product increment
**Activities**:
- Demo completed stories
- Gather stakeholder feedback
- Accept or reject work
- Adjust backlog as needed

### Sprint Retrospective
**Duration**: 1 hour for 2-week sprint
**Participants**: Scrum Master, Development Team (Product Owner optional)
**Purpose**: Inspect and adapt process
**Format**: Start, Stop, Continue
**Outputs**:
- List of improvements
- Action items with owners
- Process metrics review

### Backlog Refinement (Grooming)
**Duration**: 1 hour weekly
**Participants**: Product Owner, Development Team (Scrum Master optional)
**Purpose**: Prepare backlog for future sprints
**Activities**:
- Break down large stories
- Add acceptance criteria
- Estimate stories
- Prioritize backlog

## Multi-Team Coordination

### Scrum of Scrums
**Purpose**: Coordinate multiple Scrum teams working on one product

**Structure**:
- Product Owner (single) owns product backlog
- Scrum Master for each team
- Development teams (2-10 people each)
- Daily coordination meeting (15-30 minutes)
- Sprint planning for all teams
- Sprint review for all teams
- Joint retrospectives (representatives from each team)

**Coordinators**:
- Chief Product Owner
- Scrum of Scrums Master
- Release Train Engineer

### Release Planning
**Purpose**: Coordinate releases across multiple teams

**Components**:
- Release timeline
- Feature synchronization
- Integration dependencies
- Testing coordination
- Deployment windows

### Program Increment Planning
**Purpose**: Plan larger features spanning multiple sprints/teams

**Activities**:
- Define program increment goals
- Identify dependencies
- Coordinate capacity
- Plan integration points

## Enterprise Scaling Frameworks

### LeSS (Large Scale Scrum)
**Principles**:
- Whole-team focus (one product backlog)
- Customer focus (one Product Owner)
- Pure Scrum (minimal modifications)
- Transparency (open communication)
- System-wide continuous improvement

**Components**:
- Feature teams (2-9 members)
- Product Owner team
- Area Product Owners
- Scrum Master team
- All-hands meetings (once per sprint)

**Team Composition**:
- Multiple cross-functional teams
- Each team delivers end-to-end features
- Component ownership (if needed)

### SAFe (Scaled Agile Framework)

**Configuration**:
- Essential SAFe (smaller organizations)
- Large Solution SAFe (large enterprises)
- Portfolio SAFe (largest organizations)

**Levels**:
1. Portfolio: Strategic initiatives, epics
2. Large Solution: Architecture, enablers, features
3. Program: Product increments, release trains
4. Team: Agile teams, sprint execution

**Roles**:
- Epic Owners
- Solution Train Engineer
- Release Train Engineer
- Product Managers
- Product Owners
- Scrum Masters
- Agile Teams

**PI Planning**:
- Program Increment (PI) planning event
- 2 days every 8-10 weeks
- All teams participate
- Draft PI objectives and plans
- Management review and problem-solving

### Nexus

**Structure**:
- 3-9 Scrum teams
- 3-9 Scrum teams
- 3-9 Scrum teams
- (up to ~100 people)

**Components**:
- Nexus Integration Team (NIT)
- Scrum Masters from each team
- Product Owners from each team
- Key team members (representatives)
- Product Owner Nexus (all POs + key stakeholders)

**Meetings**:
- Scrum of Scrums (daily/weekly)
- Sprint planning (all teams)
- Sprint review (all teams)
- Retrospective (representatives)

## Team Structures and Patterns

### Feature Teams
**Definition**: Cross-functional teams organized around product features or capabilities

**Characteristics**:
- End-to-end responsibility for features
- Include all necessary skills (backend, frontend, DevOps, QA)
- Self-sufficient to deliver complete features
- Stable composition over time

**Benefits**:
- Reduced dependencies
- Faster delivery
- Better collaboration
- Clear ownership

### Component Teams
**Definition**: Teams organized around system components or architectural layers

**Characteristics**:
- Specialized technical skills
- Component ownership
- Clear technical boundaries
- May require coordination with other component teams

**Benefits**:
- Technical expertise development
- Clear ownership
- Consistent code quality
- Specialized tooling

### Platform Teams
**Definition**: Teams responsible for shared platforms and infrastructure

**Responsibilities**:
- Shared libraries and frameworks
- CI/CD pipelines
- DevOps infrastructure
- Architecture decisions
- Cross-team coordination

**Benefits**:
- Reduced duplication
- Consistent standards
- Improved developer experience
- Better compliance

### Squads (Spotify Model)
**Definition**: Small, autonomous, cross-functional teams aligned with product missions

**Structure**:
- Chapter: Chapter (skill-based community)
- Guild: Guild (practice-based community)
- Tribe: Tribe (group of squads in same business area)
- Alliance: Alliance (temporary group for cross-tribe initiatives)

**Benefits**:
- Autonomy and alignment balance
- Skill development through chapters/guilds
- Scalability
- Cross-pollination and learning

### Tribes (DANHE Model)
**Definition**: Stable, long-lived teams focused on business capability area

**Characteristics**:
- ~50-150 people per tribe
- Multiple squads per tribe
- Stable leadership and structure
- Aligned to business strategy

**Benefits**:
- Deep domain knowledge
- Stable team composition
- Better business alignment
- Reduced coordination overhead

## Metrics and Reporting

### Sprint Metrics

**Velocity**:
- Definition: Story points completed per sprint
- Measurement: Average of last 3-6 sprints
- Use: Capacity planning and forecasting

**Sprint Success Rate**:
- Definition: Sprints meeting sprint goal
- Target: >90% success rate

**Story Completion Rate**:
- Definition: Stories completed / stories committed
- Target: >80% completion rate

**Cycle Time**:
- Definition: Time from story start to completion
- Measurement: Working days
- Target: Decrease over time

**Lead Time**:
- Definition: Time from story creation to completion
- Measurement: Working days
- Target: Reduce lead time by X% per quarter

### Quality Metrics

**Defect Escape Rate**:
- Definition: Bugs found in production / total bugs
- Target: <10% escape rate

**Test Coverage**:
- Definition: Lines of code tested / total lines
- Target: >80% coverage

**Code Quality Score**:
- Definition: SonarQube quality gate score
- Target: ≥ B rating

**Security Vulnerabilities**:
- Definition: Critical/high severity vulnerabilities
- Target: Zero critical vulnerabilities in production

### Process Metrics

**Retrospective Action Completion**:
- Definition: Action items completed / total actions
- Target: >90% completion

**Daily Scrum Attendance**:
- Definition: Team members present / total team members
- Target: >95% attendance

**Sprint Planning Accuracy**:
- Definition: Planned vs actual completion
- Target: Within ±10% of planned

## Capacity Planning

### Team Capacity Calculation

**Factors**:
- Number of team members
- Workdays in sprint (excluding holidays, time off)
- Focus factor (percentage of productive time)
- Velocity (historical story points)
- Allocation to maintenance, meetings, overhead

**Formula**:
```
Capacity = (Team Members × Workdays × Focus Factor × Velocity) / Historical Velocity
```

### Example Calculation

**Team**: 6 developers
**Sprint Length**: 10 workdays
**Focus Factor**: 70%
**Historical Velocity**: 30 points/sprint
**Allocation**: 20% for meetings, overhead

**Calculation**:
```
Effective Workdays = 6 × 10 × 0.70 = 42 days
Less Meetings (20%) = 42 × 0.80 = 33.6 days
Velocity Factor = 30 / (6 × 10 × 0.70) = 0.71 points/day
Capacity = 33.6 × 0.71 = 24 points/sprint
```

## Release Management

### Release Planning

**Components**:
- Release timeline and milestones
- Feature scope for release
- Dependencies and integration points
- Testing and QA schedule
- Deployment windows
- Rollback plan

**Release Cadence**:
- Continuous Deployment (CD): Every successful build
- Frequent Releases: Weekly or bi-weekly
- Quarterly Releases: Major version releases
- On-Demand Releases: Critical fixes

### Release Readiness Checklist

- [ ] All features meet Definition of Done
- [ ] All tests passing (unit, integration, E2E)
- [ ] Code review completed and approved
- [ ] Security scan passed
- [ ] Performance tests meet SLA
- [ ] Documentation updated
- [ ] Stakeholder acceptance received
- [ ] Deployment plan approved
- [ ] Rollback plan tested
- [ ] Monitoring and alerting configured
- [ ] Communication plan ready

## Best Practices

### Team Formation

1. **Cross-Functional Teams**: Include all necessary skills
2. **T-Shaped Skills**: Depth in specialty, breadth in other areas
3. **Team Size**: 3-9 team members (optimal 5-7)
4. **Stable Teams**: Avoid frequent team changes
5. **Colocation**: Prefer face-to-face collaboration
6. **Psychological Safety**: Create safe environment for experimentation

### Sprint Planning

1. **Capacity-Based Planning**: Plan based on historical velocity
2. **Buffer for Unplanned**: Reserve 10-20% for unexpected work
3. **Story Sizing**: Keep stories small (≤8 points)
4. **Sprint Goal**: Clear, measurable goal for each sprint
5. **Task Breakdown**: Break stories into tasks (≤8 hours each)

### Daily Standup

1. **Timebox**: Strict 15-minute limit
2. **Stand Up**: Keep meetings standing
3. **Focus**: Collaboration, not status reporting
4. **Blockers**: Take blockers offline for resolution
5. **Attendance**: Required for all team members

### Sprint Review

1. **Demo Working Software**: Don't use slides
2. **Stakeholder Participation**: Invite Product Owner and stakeholders
3. **Feedback Collection**: Document all feedback
4. **Backlog Adjustment**: Update backlog based on feedback
5. **Keep it Short**: 2-3 minutes per story demoed

### Sprint Retrospective

1. **Blameless**: Focus on process, not people
2. **Actionable**: Create specific action items with owners
3. **Follow Up**: Track action completion in next sprint
4. **Experimentation**: Try one improvement per sprint
5. **Psychological Safety**: Encourage honest feedback

### Backlog Management

1. **INVEST Criteria**: All user stories follow INVEST
2. **Prioritization**: Use MoSCoW or WSJF
3. **Regular Grooming**: Weekly backlog refinement
4. **DoR Compliance**: Stories ready before sprint planning
5. **Transparency**: Make backlog visible to all stakeholders

## Scaling Best Practices

### 1-5 Teams (Single Team Structure)

- One Product Owner
- One Scrum Master
- Direct communication
- Simple coordination
- High collaboration

### 6-10 Teams (Scrum of Scrums)

- Product Owner team
- Daily coordination (30 minutes)
- Joint sprint planning
- Joint sprint review
- Representative retrospectives

### 11-50 Teams (LeSS/SAFe)

- Multiple Scrum of Scrums or Release Trains
- Program-level planning
- Architecture teams
- Release management
- Portfolio management

### 50+ Teams (SAFe/Portfolio SAFe)

- Portfolio management
- Program management
- Solution architecture
- Strategic alignment
- Enterprise reporting

## Example Usage

```
Use net-scrum skill to:

1. Set up new Scrum team structure
2. Create Scrum roles and responsibilities
3. Plan sprint for existing team
4. Coordinate multiple teams using Scrum of Scrums
5. Implement LeSS framework for scaling
6. Track team velocity and metrics
7. Create release plan across teams
```

I will generate complete Scrum implementation for enterprise teams.