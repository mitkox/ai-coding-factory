# Definition of Done (DoD)

**Version**: [1.0]
**Last Updated**: [Date]
**Approved By**: [Team/Scrum Master]
**Applies To**: All user stories, features, and sprints

---

## Purpose

The Definition of Done (DoD) is a shared understanding of what it means for work to be complete. It ensures:
- Clear acceptance criteria
- Quality standards are met
- No hidden work
- Transparency in progress

---

## DoD Checklist

### 1. Code Quality ✅

**Mandatory Items**:
- [ ] Code follows project coding standards and conventions
- [ ] Code is self-reviewed before peer review
- [ ] Peer code review completed and approved
- [ ] All review comments addressed
- [ ] No static code analysis warnings or errors
- [ ] SonarQube quality gate passed
- [ ] Code complexity metrics within acceptable limits
- [ ] No code smells or anti-patterns
- [ ] Dead code removed
- [ ] Console.WriteLine or debug statements removed

**Quality Metrics**:
- Code coverage: ≥ **80%**
- Cyclomatic complexity: ≤ **15**
- Cognitive complexity: ≤ **15**
- Maintainability index: ≥ **B**
- Duplicate lines: ≤ **3%**

---

### 2. Testing ✅

**Unit Tests**:
- [ ] Unit tests written for all business logic
- [ ] Unit tests follow AAA pattern (Arrange, Act, Assert)
- [ ] Unit tests use descriptive names (Given_When_Then)
- [ ] Unit tests passing locally
- [ ] Unit tests passing in CI/CD pipeline
- [ ] Edge cases covered (null, empty, boundary values)
- [ ] Mocks used appropriately (no over-mocking)
- [ ] Test data is isolated and deterministic

**Integration Tests**:
- [ ] Integration tests written for API endpoints
- [ ] Integration tests use TestContainers or real database
- [ ] Database migrations tested
- [ ] API contracts verified
- [ ] Authentication and authorization tested
- [ ] Error scenarios tested
- [ ] All integration tests passing

**E2E Tests** (for critical flows):
- [ ] E2E tests written for critical user journeys
- [ ] E2E tests cover happy path and error paths
- [ ] E2E tests use Playwright or Selenium
- [ ] All E2E tests passing
- [ ] E2E tests automated in CI/CD

**Performance Tests** (if applicable):
- [ ] Performance tests executed for critical paths
- [ ] Response times meet SLA requirements
- [ ] Load tests under expected traffic
- [ ] Memory usage within acceptable limits
- [ ] Database queries optimized (no N+1 issues)

---

### 3. Traceability ✅

**Story Linkage**:
- [ ] Story ID is present in story definition file
- [ ] Story ID is present in test metadata (Trait/comment/naming)
- [ ] Story ID is present in commit messages
- [ ] Story ID appears in generated release notes
- [ ] Azure Boards or GitHub work item linked and set to Done

**Automated Evidence**:
- [ ] Traceability validation script passes
- [ ] Traceability report generated and stored in `artifacts/traceability`

---

### 4. Documentation ✅

**Code Documentation**:
- [ ] XML comments added for all public APIs
- [ ] XML comments describe parameters and return types
- [ ] Complex logic explained with inline comments
- [ ] No commented-out code left in repository

**API Documentation**:
- [ ] Swagger/OpenAPI documentation updated
- [ ] API endpoints documented with examples
- [ ] Request/response schemas documented
- [ ] Error responses documented
- [ ] Authentication requirements documented
- [ ] Rate limiting documented (if applicable)

**Architecture Documentation**:
- [ ] Architecture Decision Records (ADRs) updated (if needed)
- [ ] Sequence diagrams updated (if applicable)
- [ ] Data flow diagrams updated (if applicable)
- [ ] Deployment architecture documented (if changed)

**User Documentation** (if applicable):
- [ ] User guide updated
- [ ] Onboarding documentation updated
- [ ] FAQ updated
- [ ] Screenshots/screencasts added (if needed)

**Operational Documentation**:
- [ ] Runbook updated (if needed)
- [ ] Troubleshooting guide updated (if needed)
- [ ] Monitoring and alerting documented (if changed)
- [ ] Deployment instructions updated (if changed)

---

### 5. Security ✅

**Code Security**:
- [ ] No hardcoded secrets or credentials
- [ ] No SQL injection vulnerabilities
- [ ] No XSS vulnerabilities
- [ ] No CSRF vulnerabilities
- [ ] Input validation on all user inputs
- [ ] Output encoding for all outputs
- [ ] Authentication properly implemented
- [ ] Authorization properly implemented
- [ ] Security headers configured
  - [ ] X-Content-Type-Options: nosniff
  - [ ] X-Frame-Options: DENY (or SAMEORIGIN)
  - [ ] Content-Security-Policy: configured
  - [ ] X-XSS-Protection: 1; mode=block
  - [ ] Strict-Transport-Security: configured
  - [ ] Referrer-Policy: configured
  - [ ] Permissions-Policy: configured

**Security Scanning**:
- [ ] OWASP Dependency Check passed (no critical vulnerabilities)
- [ ] NuGet package vulnerability scan passed
- [ ] Container image vulnerability scan passed
- [ ] CodeQL security scan passed (if enabled)
- [ ] All critical/high vulnerabilities addressed

**Compliance** (if applicable):
- [ ] GDPR requirements met (if applicable)
- [ ] HIPAA requirements met (if applicable)
- [ ] SOC 2 requirements met (if applicable)
- [ ] PCI DSS requirements met (if applicable)

---

### 6. Build and Deployment ✅

**Build**:
- [ ] Application builds successfully (local and CI/CD)
- [ ] No build warnings or errors
- [ ] Dependencies resolved successfully
- [ ] Database migrations generated successfully

**Deployment**:
- [ ] Deployed to staging environment successfully
- [ ] Smoke tests pass on staging
- [ ] Database migrations applied successfully to staging
- [ ] Configuration verified on staging
- [ ] Health check endpoint passing on staging
- [ ] Rollback plan documented
- [ ] Deployment checklist completed

**Production Readiness**:
- [ ] Production deployment approved by Product Owner
- [ ] Production deployment approved by QA
- [ ] Production deployment approved by Security Team (if applicable)
- [ ] Change request approved (if process requires)
- [ ] Deployment window scheduled
- [ ] On-call team notified
- [ ] Monitoring and alerting configured
- [ ] Communication plan ready

---

### 7. Performance ✅

**Performance Metrics** (must meet SLA):
- [ ] API response time: < **200ms** (p95)
- [ ] API response time: < **500ms** (p99)
- [ ] Database query time: < **100ms** (p95)
- [ ] Page load time: < **3s** (p95)
- [ ] Application startup time: < **30s**
- [ ] Memory usage: < **[X] GB**
- [ ] CPU usage: < **[X]%** under normal load

**Optimizations**:
- [ ] Database queries optimized (indexes, query tuning)
- [ ] Caching implemented where appropriate
- [ ] N+1 query problems eliminated
- [ ] Memory leaks eliminated
- [ ] Connection pooling configured
- [ ] Async/await used correctly (no deadlocks)

---

### 8. Accessibility ✅

**WCAG 2.1 AA Compliance** (if applicable):
- [ ] All images have alt text
- [ ] Color contrast ratio ≥ 4.5:1
- [ ] Keyboard navigation works for all features
- [ ] Screen reader compatible
- [ ] Focus indicators visible
- [ ] Forms properly labeled
- [ ] Error messages are accessible

**Testing**:
- [ ] Accessibility scan completed (e.g., axe DevTools)
- [ ] Keyboard-only navigation tested
- [ ] Screen reader testing completed
- [ ] No accessibility violations found

---

### 9. Stakeholder Acceptance ✅

**Verification**:
- [ ] Acceptance criteria verified by Product Owner
- [ ] User story/demo presented to stakeholders
- [ ] Stakeholder feedback received and addressed
- [ ] Product Owner approval received
- [ ] QA sign-off received
- [ ] User Acceptance Testing (UAT) completed (if applicable)
- [ ] UAT approval received (if applicable)

---

## Product-Specific DoD

### For User Stories

All items in **Code Quality**, **Testing**, and **Documentation** sections above.

### For Bugs

Additional items:
- [ ] Root cause analysis completed
- [ ] Regression tests added
- [ ] Bug verified as fixed
- [ ] Related issues checked and fixed

### For Technical Debt

Additional items:
- [ ] Impact analysis documented
- [ ] Before/after metrics captured
- [ ] Code refactoring reviewed
- [ ] Technical debt marked as resolved in tracking

### For Spikes

Additional items:
- [ ] Research question answered
- [ ] PoC created (if required)
- [ ] Recommendation documented
- [ ] Estimate provided for follow-up story

### For Refactoring

Additional items:
- [ ] Before/after behavior preserved
- [ ] Tests updated and passing
- [ ] Performance improved or maintained
- [ ] Code quality improved
- [ ] Technical debt reduced

---

## Exceptions and Waivers

**Process for Waiving DoD Items**:

1. Waiver requested by **[Team Member]**
2. Impact assessment completed by **[Scrum Master/Lead]**
3. Waiver reviewed by **[Product Owner]**
4. Waiver approved by **[Manager]**
5. Waiver documented with:
   - DoD item being waived
   - Rationale for waiver
   - Timeline for compliance
   - Approval signatures

**Current Waivers**:

| Waived Item | Rationale | Approved By | Expiry Date |
|--------------|-----------|--------------|--------------|
| [Item] | [Reason] | [Name] | [Date] |
| [Item] | [Reason] | [Name] | [Date] |

---

## Continuous Improvement

**Review Frequency**: Quarterly
**Review Team**: Development Team + Scrum Master + Product Owner + QA Lead

**Review Items**:
1. Are all DoD items still relevant?
2. Should any items be added or removed?
3. Are quality metrics appropriate?
4. Is DoD too restrictive or too lenient?
5. Are teams consistently meeting DoD?

**Last Review Date**: [Date]
**Next Review Date**: [Date]

---

## References

- [Scrum Guide](https://scrumguides.org/)
- [Clean Code](https://www.amazon.com/Clean-Code-Handbook-Software-Craftsmanship/dp/0132350882)
- [Working Effectively with Legacy Code](https://www.amazon.com/Working-Effectively-Legacy-Michael-Feathers/dp/0131177055)
- [OWASP Top 10](https://owasp.org/www-project-top-ten/)
- [WCAG 2.1 Guidelines](https://www.w3.org/WAI/WCAG21/quickref/)

---

**Version History**:

| Version | Date | Changes | Approved By |
|---------|-------|---------|-------------|
| 1.0 | [Date] | Initial DoD | [Name] |

---

**Remember**: DoD is about delivering quality, not just completing tasks. Every item that meets DoD is ready for production! ✅
