# User Story Template

---
id: ACF-0000
title: [Story Title]
status: [Backlog/In Progress/Done]
owner: [Product Owner]
---

## ACF-0000 - [Story Title]

**Created**: [Date]
**Updated**: [Date]
**Author**: [Name]
**Priority**: 🚨 Must Have / 📋 Should Have / 💡 Could Have / ❌ Won't Have
**Story Points**: [1, 2, 3, 5, 8, 13, 21]
**Sprint**: [Sprint Number]
**Status**: 📝 Backlog / 🚧 In Progress / 🔍 In Review / ✅ Done
**Epic**: [Epic Name]
**Theme**: [Sprint Theme]
**Azure DevOps or GitHub Work Item**: [Link or ID]

---

## User Story

As a **[type of user]**,
I want to **[perform an action]**,
So that I can **[achieve a goal/obtain value]**.

---

## Acceptance Criteria

Use Given-When-Then format for clear, testable criteria:

- [ ] **Given** [precondition], **when** [action], **then** [expected outcome]
- [ ] **Given** [precondition], **when** [action], **then** [expected outcome]
- [ ] **Given** [precondition], **when** [action], **then** [expected outcome]
- [ ] **Given** [precondition], **when** [action], **then** [expected outcome]

**Non-Functional Requirements:**
- [ ] Performance: [requirement, e.g., response time < 200ms]
- [ ] Security: [requirement, e.g., requires authentication]
- [ ] Accessibility: [requirement, e.g., WCAG 2.1 AA compliant]
- [ ] Compatibility: [requirement, e.g., works on Chrome, Firefox, Safari]

**Edge Cases:**
- [ ] [Edge case 1, e.g., What happens when X fails?]
- [ ] [Edge case 2, e.g., What if Y is null?]
- [ ] [Edge case 3, e.g., How does system handle Z error?]

---

## Traceability

**Story ID**: ACF-0000  
**Test References**: [Test class/methods, traits, or files]  
**Commit References**: [Commit IDs or PR links]  
**Release References**: [Release tag/notes]  

---

## Definition of Done

- [ ] **Code Implementation**
  - [ ] Code follows project coding standards
  - [ ] Code is self-reviewed
  - [ ] Peer code review completed and approved
  - [ ] No SonarQube critical or high severity issues
  - [ ] Code complexity within acceptable limits

- [ ] **Testing**
  - [ ] Unit tests written for all business logic
  - [ ] Unit tests passing (>80% code coverage)
  - [ ] Integration tests written for API endpoints
  - [ ] Integration tests passing
  - [ ] E2E tests for critical user flows
  - [ ] All tests passing in CI/CD pipeline

- [ ] **Documentation**
  - [ ] API documentation updated (Swagger/OpenAPI)
  - [ ] XML comments added for public APIs
  - [ ] Architecture Decision Record (ADR) created (if needed)
  - [ ] User documentation updated (if applicable)
  - [ ] Deployment runbook updated (if needed)

- [ ] **Quality & Security**
  - [ ] Static code analysis passes
  - [ ] Security scan passes (no critical vulnerabilities)
  - [ ] Dependency vulnerability scan passes
  - [ ] Performance tests meet SLA requirements
  - [ ] Accessibility tests pass (WCAG 2.1 AA)

- [ ] **Deployment**
  - [ ] Application builds successfully
  - [ ] Deployed to staging environment
  - [ ] Database migrations tested on staging
  - [ ] Smoke tests pass on staging
  - [ ] Rollback plan documented
  - [ ] Production deployment approved

- [ ] **Stakeholder Acceptance**
  - [ ] Demo completed with stakeholders
  - [ ] All acceptance criteria verified
  - [ ] QA sign-off received
  - [ ] Product Owner approval received

---

## Definition of Ready

Before starting development, ensure story is DoR:

- [ ] **Story Quality**
  - [ ] Story follows INVEST criteria
  - [ ] Acceptance criteria are clear and measurable
  - [ ] Story is properly sized for single sprint
  - [ ] Story has clear business value
  - [ ] Dependencies identified and documented

- [ ] **Technical Readiness**
  - [ ] Technical approach understood and documented
  - [ ] Design documents reviewed and approved
  - [ ] API contracts defined (if external integrations)
  - [ ] Database schema changes identified and reviewed
  - [ ] Third-party integrations researched
  - [ ] Feasibility confirmed

- [ ] **Team Readiness**
  - [ ] Story estimated by team using Planning Poker
  - [ ] Team capacity verified
  - [ ] Skills needed are available or training scheduled
  - [ ] Story owner/developer assigned
  - [ ] Dependencies scheduled and tracked
  - [ ] DoR checklist completed

---

## Technical Tasks

Break down story into technical tasks:

- [ ] **Task 1**: [Description] - [Owner] - [Estimate (hours)]
- [ ] **Task 2**: [Description] - [Owner] - [Estimate (hours)]
- [ ] **Task 3**: [Description] - [Owner] - [Estimate (hours)]
- [ ] **Task 4**: [Description] - [Owner] - [Estimate (hours)]
- [ ] **Task 5**: [Description] - [Owner] - [Estimate (hours)]

**Total Estimate**: [X] hours

---

## Dependencies

**Upstream Dependencies** (things this story depends on):
- [ ] [Dependency 1] - [Status]
- [ ] [Dependency 2] - [Status]

**Downstream Dependencies** (things that depend on this story):
- [ ] [Story/Feature 1]
- [ ] [Story/Feature 2]

---

## Risks and Assumptions

**Risks**:
- [ ] [Risk 1] - [Mitigation Strategy] - [Owner]
- [ ] [Risk 2] - [Mitigation Strategy] - [Owner]

**Assumptions**:
- [ ] [Assumption 1] - [Validation Plan]
- [ ] [Assumption 2] - [Validation Plan]

---

## Design and Architecture

**UI/UX Design**:
- [ ] Mockups/wireframes created and reviewed
- [ ] User flow documented

**API Design**:
- [ ] Endpoints defined
- [ ] Request/response models defined
- [ ] Error responses defined

**Database Design**:
- [ ] Schema changes documented
- [ ] Migration scripts prepared
- [ ] Performance considerations documented

**Integration Points**:
- [ ] External APIs identified
- [ ] Message queues identified
- [ ] Event streams identified

---

## Notes and Discussion

[Add any additional context, questions, or discussion items]

---

## History

| Date | Action | By |
|-------|--------|-----|
| [Date] | [Story created] | [Name] |
| [Date] | [Status changed, notes added, etc.] | [Name] |
| [Date] | [Status changed, notes added, etc.] | [Name] |

---

## Checklist for Starting Development

- [ ] Story is in "Ready" status
- [ ] DoR checklist completed
- [ ] Tasks created and estimated
- [ ] Dependencies confirmed
- [ ] Owner assigned
- [ ] Sprint capacity verified

**Ready to Start Development**: [Yes/No]

---

**Remember**: Agile is about delivering value incrementally. Keep stories small, focused, and valuable! 🚀
