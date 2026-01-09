# Security Review Checklist

**Story ID**: [ACF-###]
**Date**: [YYYY-MM-DD]
**Reviewer**: [Security Agent]

## Application Security

- [ ] AuthN/AuthZ enforced
- [ ] Input validation in place
- [ ] Output encoding for user-controlled data
- [ ] Secrets are not in code or config
- [ ] Error handling does not leak sensitive data

## Dependency Security

- [ ] `dotnet list package --vulnerable` clean
- [ ] Critical/high vulnerabilities resolved or waived
- [ ] Dependency sources approved

## Infrastructure Security

- [ ] Container runs as non-root
- [ ] Minimal base image used
- [ ] Network policies considered
- [ ] TLS enforced in production

## Privacy and Compliance

- [ ] PII handling validated
- [ ] Data retention documented
- [ ] Audit logging enabled where required

## Sign-Off

- [ ] Security agent approval
- [ ] QA approval (if required)

