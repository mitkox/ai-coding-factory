# Security Policy

## Supported Versions

We release patches for security vulnerabilities for the following versions:

| Version | Supported          |
| ------- | ------------------ |
| 1.x.x   | :white_check_mark: |
| < 1.0   | :x:                |

## Reporting a Vulnerability

We take the security of AI Coding Factory seriously. If you discover a security vulnerability, please report it responsibly.

### Where to Report

**Please DO NOT report security vulnerabilities through public issue trackers (Azure Boards or GitHub).**

Instead, please report security vulnerabilities via **GitHub Security Advisories** (private reporting).

You should receive a response within 48 hours. If you do not, please follow up via the advisory thread.

### What to Include

Please include the following information in your report:

- **Type of vulnerability** (e.g., buffer overflow, SQL injection, cross-site scripting, etc.)
- **Full paths of source file(s)** related to the vulnerability
- **Location of the affected source code** (tag/branch/commit or direct URL)
- **Any special configuration** required to reproduce the issue
- **Step-by-step instructions** to reproduce the issue
- **Proof-of-concept or exploit code** (if possible)
- **Impact of the issue**, including how an attacker might exploit it

### What to Expect

After you submit a report, we will:

1. **Acknowledge receipt** of your vulnerability report within 48 hours
2. **Confirm the vulnerability** and determine its severity
3. **Work on a fix** and prepare a security advisory
4. **Release the fix** and publicly disclose the vulnerability
5. **Credit you** for the discovery (if you wish)

### Disclosure Policy

- **Vulnerability reports** are kept confidential until a fix is available
- **Security advisories** are published after fixes are released
- **Credit** is given to security researchers who report vulnerabilities responsibly

## Security Best Practices

When using AI Coding Factory, follow these security best practices:

### 1. Protect Your API Keys

```bash
# Never commit API keys to version control
echo ".env" >> .gitignore
echo "appsettings.*.json" >> .gitignore
echo "**/secrets.json" >> .gitignore

# Use environment variables
export OPENCODE_API_KEY="your-key-here"
export SONARQUBE_TOKEN="your-token-here"
```

### 1a. Use .env.example Only

- Use `.env.example` as the template for environment configuration
- Never commit `.env` files or secrets

### 2. Local Inference Security

- Run local inference servers (vLLM, LM Studio) behind a firewall
- Use authentication for inference endpoints
- Limit network access to localhost only
- Keep inference software updated

### 2a. Air-Gapped Guidance

- Mirror package feeds and container images to internal registries
- Disable external MCP integrations unless explicitly approved
- Block outbound network access for inference servers

### 3. Permission Configuration

Configure strict permissions in `.opencode/opencode.json`:

```json
{
  "permission": {
    "bash": {
      "git *": "allow",
      "dotnet *": "allow",
      "docker *": "ask",
      "rm -rf *": "deny",
      "*": "deny"
    },
    "edit": "ask",
    "write": "ask"
  }
}
```

### 4. Generated Code Security

- **Always review** AI-generated code before committing
- Run **security audits** using `@net-security-auditor` agent
- Use **OWASP dependency checks** for vulnerability scanning
- Enable **SonarQube integration** for code quality and security
- Run **automated security tests** in CI/CD pipeline

### 5. Database Security

```csharp
// ✅ DO: Use parameterized queries (EF Core)
var users = await context.Users
    .Where(u => u.Email == email)
    .ToListAsync();

// ❌ DON'T: Use string concatenation
var sql = $"SELECT * FROM Users WHERE Email = '{email}'"; // SQL Injection risk!
```

### 6. Authentication & Authorization

```csharp
// ✅ DO: Use built-in authentication
[Authorize(Roles = "Admin")]
public class AdminController : ControllerBase { }

// ✅ DO: Validate JWT tokens
services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => {
        options.TokenValidationParameters = new TokenValidationParameters {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true
        };
    });

// ❌ DON'T: Store passwords in plain text
// ❌ DON'T: Use weak hashing algorithms (MD5, SHA1)
```

### 7. Input Validation

```csharp
// ✅ DO: Use FluentValidation
public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(256);

        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(8)
            .Matches(@"[A-Z]").WithMessage("Password must contain uppercase")
            .Matches(@"[a-z]").WithMessage("Password must contain lowercase")
            .Matches(@"[0-9]").WithMessage("Password must contain number")
            .Matches(@"[\W]").WithMessage("Password must contain special character");
    }
}
```

### 8. Secrets Management

```bash
# Use .NET User Secrets for development
dotnet user-secrets init
dotnet user-secrets set "Jwt:Secret" "your-secret-key"

# Use environment variables for production
export JWT_SECRET="your-production-secret"
export DATABASE_PASSWORD="your-db-password"

# Use Azure Key Vault or AWS Secrets Manager for enterprise
```

### 9. HTTPS Configuration

```csharp
// Program.cs - Enforce HTTPS
app.UseHttpsRedirection();

// Add HSTS headers
app.UseHsts();

// Add security headers
app.Use(async (context, next) =>
{
    context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
    context.Response.Headers.Add("X-Frame-Options", "DENY");
    context.Response.Headers.Add("X-XSS-Protection", "1; mode=block");
    context.Response.Headers.Add("Referrer-Policy", "no-referrer");
    context.Response.Headers.Add("Content-Security-Policy", "default-src 'self'");
    await next();
});
```

### 10. Dependency Management

```bash
# Regular dependency updates
dotnet outdated

# Vulnerability scanning
dotnet list package --vulnerable

# Use Dependabot (configured in .github/dependabot.yml)
```

## Security Checklist for Generated Projects

Use this checklist before deploying AI-generated applications:

- [ ] All secrets removed from code and configuration files
- [ ] Input validation implemented using FluentValidation
- [ ] Authentication and authorization configured
- [ ] HTTPS enforced in production
- [ ] Security headers configured
- [ ] SQL injection prevention (parameterized queries only)
- [ ] XSS prevention (output encoding)
- [ ] CSRF protection enabled
- [ ] CORS configured with specific origins (not *)
- [ ] Error handling doesn't leak sensitive information
- [ ] Logging configured (no sensitive data in logs)
- [ ] Dependencies scanned for vulnerabilities
- [ ] Security tests included in test suite
- [ ] Code reviewed by security expert
- [ ] Penetration testing completed (for production)

## Known Security Considerations

### AI-Generated Code

- **Review all generated code** - AI can inadvertently generate insecure patterns
- **Use security agents** - Run `@net-security-auditor` before production
- **Test thoroughly** - AI-generated code should have the same test coverage as human-written code

### Local Inference

- **Model access** - Ensure local inference servers are not exposed to the internet
- **API authentication** - Always use API keys for inference endpoints
- **Resource limits** - Configure resource limits to prevent DoS

### Plugin System

- **Review plugins** - Custom plugins have full system access
- **Code review** - All plugins should be reviewed before use
- **Sandboxing** - Consider sandboxing plugins in production

## Security Updates

Subscribe to security updates:

- Watch this repository for security advisories
- Check the [CHANGELOG.md](CHANGELOG.md) for security fixes

## Third-Party Security

We depend on these security tools:

- **SonarQube** - Code quality and security analysis
- **OWASP Dependency Check** - Vulnerability scanning
- **Snyk** - Continuous security monitoring
- **Azure DevOps or GitHub security alerts** - Dependency vulnerability alerts (if enabled)

## Compliance

AI Coding Factory can help generate code that complies with:

- **OWASP Top 10** - Security best practices
- **GDPR** - Data protection (with proper configuration)
- **SOC 2** - Security controls (when deployed properly)
- **PCI DSS** - Payment card industry standards (with additional controls)

## Contact

For security concerns, contact:

- **GitHub Security Advisories** (preferred)
- **Response Time**: Within 48 hours

Thank you for helping keep AI Coding Factory and our users safe!
