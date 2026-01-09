# Developer Playbook

**Version**: 1.0
**Last Updated**: [Date]

---

## Role Overview

Developers are the people in the Scrum Team that are committed to creating any aspect of a usable Increment each Sprint. They are cross-functional, self-organizing, and accountable for delivering high-quality working software.

---

## Core Responsibilities

### 1. Increment Delivery

- [ ] **Create the Sprint Backlog** - Plan work for the sprint
- [ ] **Deliver usable Increments** - Working software each sprint
- [ ] **Ensure quality** - Meet Definition of Done
- [ ] **Adapt daily** - Adjust plan based on progress
- [ ] **Hold each other accountable** - As professionals

### 2. Technical Excellence

- [ ] **Write clean code** - Readable, maintainable, tested
- [ ] **Follow coding standards** - Consistent patterns
- [ ] **Review code thoroughly** - Catch issues early
- [ ] **Reduce technical debt** - Continuously improve codebase
- [ ] **Stay current** - Learn new technologies and practices

### 3. Collaboration

- [ ] **Self-organize** - Decide how to accomplish work
- [ ] **Cross-train** - Share knowledge with teammates
- [ ] **Support teammates** - Help when needed
- [ ] **Communicate openly** - Share progress and blockers
- [ ] **Participate in events** - Engage in Scrum ceremonies

---

## Daily Activities

### Morning Routine
- [ ] Review assigned tasks and priorities
- [ ] Check overnight communications
- [ ] Prepare standup update (yesterday, today, blockers)
- [ ] Update task status in tracking system

### During the Day
- [ ] Attend Daily Scrum (15 min)
- [ ] Write code and tests
- [ ] Review teammates' pull requests
- [ ] Pair/mob program when appropriate
- [ ] Document as you go

### End of Day
- [ ] Commit work in progress
- [ ] Update task status
- [ ] Note any blockers for tomorrow
- [ ] Respond to pending reviews

---

## Sprint Event Participation

### Sprint Planning

**Your Role**:
- [ ] Clarify story requirements with Product Owner
- [ ] Help break down stories into tasks
- [ ] Estimate work using team method (Planning Poker, T-shirt sizing)
- [ ] Commit only to what you can deliver
- [ ] Identify dependencies and risks

### Daily Scrum

**Your Update** (1-2 minutes):
1. What did I complete yesterday?
2. What will I work on today?
3. Do I have any blockers?

**Best Practices**:
- Be concise
- Focus on sprint goal work
- Raise blockers immediately
- Take detailed discussions offline

### Backlog Refinement

**Your Role**:
- [ ] Ask clarifying questions
- [ ] Provide technical perspective
- [ ] Help estimate effort
- [ ] Identify technical risks
- [ ] Suggest implementation approaches

### Sprint Review

**Your Role**:
- [ ] Demo completed work
- [ ] Answer technical questions
- [ ] Listen to stakeholder feedback
- [ ] Note suggested changes

### Sprint Retrospective

**Your Role**:
- [ ] Participate openly and honestly
- [ ] Suggest improvements
- [ ] Volunteer for action items
- [ ] Follow through on commitments

---

## Coding Standards

### Code Quality Principles

1. **Readable**: Code should be self-documenting
2. **Simple**: Avoid unnecessary complexity
3. **DRY**: Don't Repeat Yourself
4. **SOLID**: Follow SOLID principles
5. **Tested**: Write tests for your code

### C# Naming Conventions

| Type | Convention | Example |
|------|------------|---------|
| Class | PascalCase | `UserService` |
| Interface | I + PascalCase | `IUserRepository` |
| Method | PascalCase | `GetUserById` |
| Property | PascalCase | `FirstName` |
| Private Field | _camelCase | `_userRepository` |
| Parameter | camelCase | `userId` |
| Local Variable | camelCase | `currentUser` |
| Constant | PascalCase | `MaxRetryCount` |

### Code Review Checklist

**Before Submitting**:
- [ ] Code builds without warnings
- [ ] All tests pass
- [ ] Self-reviewed for obvious issues
- [ ] Meaningful commit messages
- [ ] PR description is clear

**When Reviewing**:
- [ ] Code is readable and maintainable
- [ ] Logic is correct
- [ ] Edge cases handled
- [ ] Tests are adequate
- [ ] No security vulnerabilities
- [ ] Performance is acceptable
- [ ] Documentation is updated

---

## Testing Practices

### Test Pyramid

```
       /\
      /  \       E2E Tests (10%)
     /----\      Critical user flows
    /      \     
   /--------\    Integration Tests (20%)
  /          \   API endpoints, database
 /------------\  
/              \ Unit Tests (70%)
                 Business logic, utilities
```

### Unit Test Structure (AAA Pattern)

```csharp
[Fact]
public void Method_Scenario_ExpectedResult()
{
    // Arrange
    var sut = new SystemUnderTest();
    var input = "test";
    
    // Act
    var result = sut.Method(input);
    
    // Assert
    Assert.Equal(expected, result);
}
```

### Test Naming Convention

```
Method_Scenario_ExpectedResult
```

Examples:
- `GetUser_WhenUserExists_ReturnsUser`
- `GetUser_WhenUserNotFound_ReturnsNull`
- `CreateOrder_WhenItemsEmpty_ThrowsException`

---

## Git Workflow

### Branch Naming

| Type | Format | Example |
|------|--------|---------|
| Feature | `feature/STORY-123-short-description` | `feature/US-456-user-login` |
| Bug Fix | `fix/BUG-123-short-description` | `fix/BUG-789-login-error` |
| Hotfix | `hotfix/issue-description` | `hotfix/critical-payment-bug` |

### Commit Messages (Conventional Commits)

```
type(scope): subject

body (optional)

footer (optional)
```

**Types**:
- `feat:` New feature
- `fix:` Bug fix
- `docs:` Documentation only
- `style:` Formatting, no code change
- `refactor:` Code restructuring
- `test:` Adding tests
- `chore:` Build process, dependencies

**Examples**:
```
feat(auth): add JWT refresh token support

Implement refresh token rotation for improved security.
Tokens expire after 15 minutes with a 7-day refresh window.

Closes #123
```

### Pull Request Best Practices

- Keep PRs small (<400 lines when possible)
- One logical change per PR
- Include context in description
- Link to related issues
- Request reviews promptly
- Address feedback constructively

---

## Technical Debt Management

### Technical Debt Types

| Type | Example | Priority |
|------|---------|----------|
| **Deliberate** | Quick fix to meet deadline | Track, plan to fix |
| **Accidental** | Discovered design flaw | Assess impact |
| **Bit Rot** | Outdated dependencies | Regular maintenance |
| **Knowledge** | Team didn't know better | Learn and improve |

### Managing Technical Debt

1. **Track it**: Log tech debt as backlog items
2. **Make it visible**: Include in sprint planning
3. **Allocate time**: 10-20% of sprint capacity
4. **Prioritize ruthlessly**: Based on risk/impact
5. **Prevent accumulation**: Code reviews, standards

---

## Collaboration Practices

### Pair Programming

**When to Pair**:
- Complex or risky code
- Onboarding new team members
- Knowledge sharing
- Stuck on a problem
- Code reviews finding many issues

**Pair Programming Styles**:
- **Driver-Navigator**: One types, one reviews
- **Ping-Pong**: Alternate after each test
- **Strong Style**: Navigator does all thinking

### Mob Programming

**When to Mob**:
- Whole team needs to understand
- Critical architectural decisions
- Complex integration work
- Team learning sessions

---

## Definition of Done Checklist

### Code Complete
- [ ] Feature implemented as per acceptance criteria
- [ ] Code follows coding standards
- [ ] Self-reviewed before PR

### Quality Assured
- [ ] Unit tests written (>80% coverage)
- [ ] Integration tests for API/DB
- [ ] All tests passing
- [ ] No critical code smell issues

### Reviewed
- [ ] Peer code review completed
- [ ] All review comments addressed
- [ ] At least 1 approval

### Deployed
- [ ] Deployed to staging environment
- [ ] Smoke tests pass
- [ ] No regressions

### Documented
- [ ] Code is self-documenting
- [ ] API documentation updated (if applicable)
- [ ] README updated (if applicable)

---

## Common Anti-Patterns to Avoid

### ❌ Lone Wolf
**Problem**: Works in isolation, doesn't share or collaborate
**Impact**: Knowledge silos, inconsistent code
**Solution**: Pair program, attend team events, share knowledge

### ❌ Gold Plating
**Problem**: Over-engineering beyond requirements
**Impact**: Wasted effort, delayed deliveries
**Solution**: Deliver what's asked, iterate based on feedback

### ❌ Cowboy Coder
**Problem**: Commits directly, skips reviews and tests
**Impact**: Bugs in production, broken builds
**Solution**: Follow team process, embrace code reviews

### ❌ Perfectionist
**Problem**: Never ships, always "improving"
**Impact**: Missed deadlines, frustrated team
**Solution**: Ship increments, refactor later

### ❌ Silent Struggler
**Problem**: Doesn't raise blockers or ask for help
**Impact**: Delayed work, burnout
**Solution**: Communicate early, ask for help

---

## Growth and Learning

### Skills to Develop

**Technical**:
- [ ] Language expertise (C#, etc.)
- [ ] Framework mastery (ASP.NET Core, EF Core)
- [ ] Testing strategies
- [ ] DevOps practices
- [ ] Cloud platforms (Azure, AWS)

**Soft Skills**:
- [ ] Communication
- [ ] Collaboration
- [ ] Problem-solving
- [ ] Time management
- [ ] Giving and receiving feedback

### Learning Resources

- [Official .NET Documentation](https://docs.microsoft.com/en-us/dotnet/)
- [Clean Code by Robert C. Martin](https://www.amazon.com/Clean-Code-Handbook-Software-Craftsmanship/dp/0132350882)
- [Pragmatic Programmer](https://www.amazon.com/Pragmatic-Programmer-journey-mastery-Anniversary/dp/0135957052)
- [.NET Rocks Podcast](https://www.dotnetrocks.com/)

---

## Checklist: Am I Being Effective?

### Daily Self-Assessment
- [ ] Am I making progress on sprint work?
- [ ] Did I raise any blockers promptly?
- [ ] Did I help a teammate today?
- [ ] Did I leave the codebase better than I found it?
- [ ] Am I meeting Definition of Done?

---

*"Developers are the people in the Scrum Team that are committed to creating any aspect of a usable Increment each Sprint." - Scrum Guide*
