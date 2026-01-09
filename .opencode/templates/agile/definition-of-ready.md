# Definition of Ready (DoR)

**Version**: [1.0]
**Last Updated**: [Date]
**Approved By**: [Team/Scrum Master]
**Applies To**: All user stories, features, and tasks before entering sprint backlog

---

## Purpose

The Definition of Ready (DoR) is a checklist that ensures work items are sufficiently understood and prepared before development begins. This prevents:
- Mid-sprint surprises and delays
- Unclear requirements and rework
- Blocked stories due to missing information
- Inaccurate estimates
- Missed dependencies

**DoR ensures that**: When a story is pulled from backlog, it can be completed without further clarification.

---

## DoR Checklist

### 1. User Story Quality ✅

**Story Structure**:
- [ ] Story follows user story format: "As a [type of user], I want to [perform an action], So that I can [achieve a goal]"
- [ ] Story has a unique ID in format `ACF-###`
- [ ] Story is independent (no dependencies on other in-progress stories)
- [ ] Story is negotiable (details can be clarified)
- [ ] Story is valuable (clear business value)
- [ ] Story is estimable (team understands enough to estimate)
- [ ] Story is small enough to complete in one sprint (≤[X] story points)
- [ ] Story is testable (acceptance criteria can be verified)

**INVEST Criteria**:
- [ ] **I**ndependent: Can be delivered independently
- [ ] **N**egotiable: Details can be discussed and adjusted
- [ ] **V**aluable: Delivers measurable value to stakeholder
- [ ] **E**stimable: Team can estimate effort reliably
- [ ] **S**mall: Fits within a single sprint
- [ ] **T**estable: Acceptance criteria can be verified

---

### 2. Acceptance Criteria ✅

**Clarity and Measurability**:
- [ ] Acceptance criteria are clear and unambiguous
- [ ] Each criterion can be verified as pass/fail
- [ ] All acceptance criteria are testable
- [ ] Edge cases are covered in acceptance criteria
- [ ] Non-functional requirements are specified
  - [ ] Performance requirements defined
  - [ ] Security requirements defined
  - [ ] Accessibility requirements defined (if applicable)
  - [ ] Compatibility requirements defined

**Completeness**:
- [ ] Acceptance criteria cover the user's goal
- [ ] Acceptance criteria cover normal flows
- [ ] Acceptance criteria cover error flows
- [ ] Acceptance criteria cover edge cases
- [ ] Minimum viable product (MVP) scope is clear

---

### 3. Design and Requirements ✅

**Functional Requirements**:
- [ ] Business requirements are documented
- [ ] User flows are mapped out
- [ ] UI/UX designs are provided (if applicable)
  - [ ] Wireframes created and reviewed
  - [ ] Mockups created and approved
  - [ ] User journey documented
- [ ] Business rules are documented
- [ ] Data models are defined
- [ ] Integration points are identified

**Technical Requirements**:
- [ ] API contracts are defined (if external integrations)
  - [ ] Request schemas documented
  - [ ] Response schemas documented
  - [ ] Error responses documented
- [ ] Database schema changes are identified
  - [ ] New tables/columns defined
  - [ ] Migration scripts planned
- [ ] Third-party dependencies are researched
- [ ] Performance requirements are specified
- [ ] Scalability requirements are specified

**Architecture Considerations**:
- [ ] Impact on existing architecture is understood
- [ ] Impact on other systems is understood
- [ ] Data flow is documented
- [ ] Security implications are considered
- [ ] Caching strategy is considered (if applicable)

---

### 4. Estimation ✅

**Team Estimation**:
- [ ] Story has been estimated by development team
- [ ] Estimation used Planning Poker or team consensus
- [ ] Estimate is in story points (Fibonacci: 1, 2, 3, 5, 8, 13, 21)
- [ ] Story points reflect complexity, uncertainty, and effort
- [ ] Story is properly sized (typically 3-8 points)
- [ ] Estimate includes time for:
  - [ ] Implementation
  - [ ] Unit testing
  - [ ] Integration testing
  - [ ] Code review
  - [ ] Bug fixes
  - [ ] Documentation

**Time Estimates** (optional):
- [ ] Time estimates are provided (if story points not used)
- [ ] Time estimates include buffer (10-20%)
- [ ] Time estimates are broken down by task

---

### 5. Technical Readiness ✅

**Technical Approach**:
- [ ] Technical approach is understood by team
- [ ] Design documents have been reviewed
- [ ] Architecture Decision Record (ADR) created (if needed)
- [ ] Technical risks have been identified
- [ ] Proof of Concept (PoC) completed (if complex/uncertain)

**Dependencies Identified**:
- [ ] Internal dependencies are identified
  - [ ] Stories/features this depends on are listed
  - [ ] Status of dependencies is known
- [ ] External dependencies are identified
  - [ ] External APIs/services are listed
  - [ ] Access to external APIs is verified
  - [ ] External API documentation is available
- [ ] Library/package dependencies are identified
  - [ ] Required NuGet packages are listed
  - [ ] Package compatibility is verified

**Feasibility**:
- [ ] Technical feasibility is confirmed
- [ ] Implementation complexity is understood
- [ ] Skills required are available in team
- [ ] Team capacity can accommodate the story

---

### 6. Dependencies and Blockers ✅

**Upstream Dependencies**:
- [ ] All dependencies are listed
- [ ] Status of each dependency is known
  - [ ] Dependency 1: ✅ Available / ⚠️ At Risk / ❌ Not Available
  - [ ] Dependency 2: ✅ Available / ⚠️ At Risk / ❌ Not Available
- [ ] Blockers are documented (if any)
- [ ] Mitigation strategies are documented (if blockers exist)

**Timeline Coordination**:
- [ ] Dependency delivery dates are confirmed
- [ ] Story is scheduled after dependencies are available
- [ ] Contingency plan exists for late dependencies

---

### 7. Resources and Skills ✅

**Team Availability**:
- [ ] Required skills are available in the team
- [ ] Team members are assigned or identified
- [ ] Team capacity is verified for sprint duration
- [ ] Time off/holidays are accounted for
- [ ] Training needs are identified (if gaps exist)

**Environment Readiness**:
- [ ] Development environments are available
- [ ] Test environments are available
- [ ] Required tools and software are installed
- [ ] Access to necessary systems is verified

---

### 8. Documentation ✅

**Story Documentation**:
- [ ] User story is documented in backlog system
- [ ] Azure Boards or GitHub work item created and linked
- [ ] All attachments are added (designs, specs, etc.)
- [ ] Story has clear title and description
- [ ] Story has appropriate priority set
- [ ] Story is linked to epic/feature (if applicable)
- [ ] Story has appropriate tags/labels

**Supporting Documentation**:
- [ ] Relevant ADRs are linked
- [ ] Relevant architecture diagrams are linked
- [ ] Relevant API documentation is linked
- [ ] Relevant database documentation is linked

---

### 9. Traceability Readiness ✅

**Traceability Plan**:
- [ ] Test strategy documented (unit/integration/e2e)
- [ ] Story ID will be used in test metadata
- [ ] Commit message format agreed (e.g., `ACF-123: summary`)
- [ ] Release notes will be generated from commit IDs

---

### 10. Risk Assessment ✅

**Risks Identified**:
- [ ] Technical risks are identified
- [ ] Schedule risks are identified
- [ ] Resource risks are identified
- [ ] Dependency risks are identified
- [ ] Each risk has mitigation strategy

**Risk Mitigation**:
| Risk | Probability | Impact | Mitigation Strategy | Owner |
|------|-------------|---------|-------------------|--------|
| [Risk 1] | 🟢 Low / 🟡 Medium / 🔴 High | 🟢 Low / 🟡 Medium / 🔴 High | [Strategy] | [Name] |
| [Risk 2] | 🟢 Low / 🟡 Medium / 🔴 High | 🟢 Low / 🟡 Medium / 🔴 High | [Strategy] | [Name] |

---

### 11. Product Owner Approval ✅

**Product Owner Review**:
- [ ] Story has been reviewed by Product Owner
- [ ] Story priorities are confirmed
- [ ] Acceptance criteria are validated
- [ ] Business value is confirmed
- [ ] Story is approved for development

**Priority Confirmation**:
- [ ] Priority level is confirmed (Must Have/Should Have/Could Have)
- [ ] Sprint placement is agreed upon
- [ ] Story is added to sprint backlog (if applicable)

---

## DoR Decision Process

### Ready for Development

A story is "Ready" when:
1. ✅ All mandatory items in **User Story Quality** section are checked
2. ✅ All mandatory items in **Acceptance Criteria** section are checked
3. ✅ All mandatory items in **Design and Requirements** section are checked
4. ✅ All mandatory items in **Estimation** section are checked
5. ✅ All mandatory items in **Technical Readiness** section are checked
6. ✅ All mandatory items in **Dependencies and Blockers** section are checked
7. ✅ All mandatory items in **Documentation** section are checked
8. ✅ Product Owner has approved the story

### Not Ready for Development

A story is "Not Ready" if:
- ❌ Any mandatory item is unchecked
- ❌ Story is too large (>13 points)
- ❌ Acceptance criteria are unclear
- ❌ Dependencies are not available
- ❌ Technical approach is not understood

**Action Required**: Address missing items before story can be pulled into sprint.

---

## DoR Waiver Process

**Process**:
1. Waiver requested by **[Team Member]**
2. Risk assessment completed by **[Scrum Master/Lead]**
3. Waiver reviewed by **[Product Owner]**
4. Waiver approved by **[Manager]** (if required)
5. Waiver documented with timeline for compliance

**Waiver Template**:

```markdown
## DoR Waiver

**Story ID**: [ID]
**Story Title**: [Title]
**Waiver Date**: [Date]
**Requested By**: [Name]

### Items Being Waived

- [ ] [DoR item 1]
- [ ] [DoR item 2]
- [ ] [DoR item 3]

### Rationale for Waiver

[Explain why item cannot be met and what will be done instead]

### Risk Assessment

**Probability of Issue**: 🟢 Low / 🟡 Medium / 🔴 High
**Impact of Issue**: 🟢 Low / 🟡 Medium / 🔴 High
**Overall Risk**: 🟢 Low / 🟡 Medium / 🔴 High

### Mitigation Strategy

[What will be done to mitigate the risk?]

### Compliance Timeline

[When will the waived item be completed?]

### Approvals

**Scrum Master**: [Signature] - [Date]
**Product Owner**: [Signature] - [Date]
**Manager**: [Signature] - [Date] (if applicable)
```

---

## DoR Review and Improvement

**Review Frequency**: Monthly or after each sprint retrospective

**Review Questions**:
1. Are all DoR items still relevant?
2. Should any items be added or removed?
3. Are stories meeting DoR being completed more successfully?
4. Is the estimation process working well?
5. Are dependencies being identified earlier?

**Last Review Date**: [Date]
**Next Review Date**: [Date]

---

## Examples

### Example of a Story That is Ready ✅

**Title**: User Authentication with JWT
**Story Points**: 5
**DoR Status**: ✅ READY

**Checks**:
- [x] Follows user story format
- [x] Acceptance criteria are clear
- [x] Estimated by team (5 points)
- [x] Technical approach understood (use existing JWT skill)
- [x] No blockers
- [x] Product Owner approved
- [x] All dependencies available

### Example of a Story That is Not Ready ❌

**Title**: Advanced AI-Powered Recommendation Engine
**Story Points**: 21 (too large)
**DoR Status**: ❌ NOT READY

**Missing Items**:
- [ ] Acceptance criteria unclear (what defines "good recommendations"?)
- [ ] Too large (break down into stories of ≤8 points)
- [ ] Technical approach not researched (which ML model? framework?)
- [ ] Product Owner not yet reviewed
- [ ] Dependencies on ML research sprint not confirmed

**Action**: Break down into smaller stories, clarify acceptance criteria, complete technical research, get Product Owner approval.

---

## References

- [User Stories and Requirements](https://www.amazon.com/Requirements-Gathering-Agile-Teams-MacDonald/dp/0999516012)
- [Agile Estimating and Planning](https://www.amazon.com/Agile-Estimating-Planning-Robert-C-Cline/dp/0132390283)
- [User Story Mapping](https://www.amazon.com/User-Story-Mapping-Jeff-Patton/dp/0062314687)
- [Scrum Guide](https://scrumguides.org/)

---

**Version History**:

| Version | Date | Changes | Approved By |
|---------|-------|---------|-------------|
| 1.0 | [Date] | Initial DoR | [Name] |

---

**Remember**: DoR is about preventing problems before they start. A story that is Ready is a story that can be completed! 🎯
