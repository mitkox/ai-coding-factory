---
name: net-observability
description: Implement observability patterns with OpenTelemetry, structured logging, and distributed tracing
license: MIT
compatibility: opencode
metadata:
  audience: .net-developers
  framework: aspnetcore
  patterns: opentelemetry, serilog, metrics
---

## What I Do

I help you implement enterprise observability patterns:
- Structured logging with Serilog
- Distributed tracing with OpenTelemetry
- Metrics collection with Prometheus
- Health checks for Kubernetes
- Correlation IDs for request tracking
- Application Performance Monitoring (APM)

## When to Use Me

Use this skill when:
- Setting up logging infrastructure
- Implementing distributed tracing
- Adding metrics and monitoring
- Configuring health checks
- Preparing for production deployment

## Packages Required

```xml
<PackageReference Include="Serilog.AspNetCore" Version="8.0.0" />
<PackageReference Include="Serilog.Sinks.Console" Version="5.0.1" />
<PackageReference Include="Serilog.Sinks.Seq" Version="6.0.0" />
<PackageReference Include="Serilog.Enrichers.Environment" Version="2.3.0" />
<PackageReference Include="Serilog.Enrichers.Thread" Version="3.1.0" />
<PackageReference Include="OpenTelemetry" Version="1.7.0" />
<PackageReference Include="OpenTelemetry.Extensions.Hosting" Version="1.7.0" />
<PackageReference Include="OpenTelemetry.Instrumentation.AspNetCore" Version="1.7.0" />
<PackageReference Include="OpenTelemetry.Instrumentation.Http" Version="1.7.0" />
<PackageReference Include="OpenTelemetry.Exporter.Prometheus.AspNetCore" Version="1.7.0-rc.1" />
<PackageReference Include="OpenTelemetry.Exporter.Jaeger" Version="1.5.1" />
```

## Serilog Configuration

### Program.cs Setup
```csharp
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Configure Serilog
builder.Host.UseSerilog((context, loggerConfiguration) =>
{
    loggerConfiguration
        .ReadFrom.Configuration(context.Configuration)
        .Enrich.FromLogContext()
        .Enrich.WithMachineName()
        .Enrich.WithEnvironmentName()
        .Enrich.WithThreadId()
        .Enrich.WithProperty("Application", "YourAppName")
        .WriteTo.Console(
            outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {CorrelationId} {Message:lj} {Properties:j}{NewLine}{Exception}")
        .WriteTo.Seq("http://localhost:5341"); // Optional: Seq server
});
```

### appsettings.json
```json
{
  "Serilog": {
    "MinimumLevel": {
      "Default": "Information",
      "Override": {
        "Microsoft": "Warning",
        "Microsoft.Hosting.Lifetime": "Information",
        "Microsoft.EntityFrameworkCore": "Warning",
        "System": "Warning"
      }
    },
    "WriteTo": [
      {
        "Name": "Console",
        "Args": {
          "theme": "Serilog.Sinks.SystemConsole.Themes.AnsiConsoleTheme::Code, Serilog.Sinks.Console"
        }
      }
    ]
  }
}
```

## OpenTelemetry Configuration

### Distributed Tracing Setup
```csharp
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using OpenTelemetry.Metrics;

builder.Services.AddOpenTelemetry()
    .ConfigureResource(resource => resource
        .AddService(serviceName: "YourServiceName", serviceVersion: "1.0.0"))
    .WithTracing(tracing => tracing
        .AddSource("YourServiceName")
        .AddAspNetCoreInstrumentation()
        .AddHttpClientInstrumentation()
        .AddEntityFrameworkCoreInstrumentation()
        .AddJaegerExporter(options =>
        {
            options.AgentHost = "localhost";
            options.AgentPort = 6831;
        }))
    .WithMetrics(metrics => metrics
        .AddAspNetCoreInstrumentation()
        .AddHttpClientInstrumentation()
        .AddRuntimeInstrumentation()
        .AddPrometheusExporter());
```

## Correlation ID Middleware

```csharp
public class CorrelationIdMiddleware
{
    private const string CorrelationIdHeader = "X-Correlation-Id";
    private readonly RequestDelegate _next;

    public CorrelationIdMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var correlationId = context.Request.Headers[CorrelationIdHeader].FirstOrDefault()
            ?? Guid.NewGuid().ToString();

        context.Items["CorrelationId"] = correlationId;
        context.Response.Headers[CorrelationIdHeader] = correlationId;

        using (LogContext.PushProperty("CorrelationId", correlationId))
        {
            await _next(context);
        }
    }
}
```

## Health Checks

```csharp
builder.Services.AddHealthChecks()
    .AddNpgSql(connectionString, name: "database", tags: new[] { "ready" })
    .AddRedis(redisConnectionString, name: "redis", tags: new[] { "ready" })
    .AddCheck("self", () => HealthCheckResult.Healthy(), tags: new[] { "live" });

// Map endpoints
app.MapHealthChecks("/health");
app.MapHealthChecks("/health/ready", new HealthCheckOptions
{
    Predicate = check => check.Tags.Contains("ready")
});
app.MapHealthChecks("/health/live", new HealthCheckOptions
{
    Predicate = check => check.Tags.Contains("live")
});
```

## Custom Metrics

```csharp
using System.Diagnostics.Metrics;

public class ApplicationMetrics
{
    private readonly Counter<long> _requestCounter;
    private readonly Histogram<double> _requestDuration;
    
    public ApplicationMetrics(IMeterFactory meterFactory)
    {
        var meter = meterFactory.Create("YourApp.Metrics");
        
        _requestCounter = meter.CreateCounter<long>(
            "app.requests.total",
            description: "Total number of requests");
            
        _requestDuration = meter.CreateHistogram<double>(
            "app.requests.duration",
            unit: "ms",
            description: "Request duration in milliseconds");
    }
    
    public void RecordRequest(string endpoint, long durationMs)
    {
        _requestCounter.Add(1, new KeyValuePair<string, object?>("endpoint", endpoint));
        _requestDuration.Record(durationMs, new KeyValuePair<string, object?>("endpoint", endpoint));
    }
}
```

## Best Practices

1. **Structured Logging**: Always use structured logging with properties
2. **Correlation IDs**: Propagate correlation IDs across services
3. **Log Levels**: Use appropriate log levels (Debug, Information, Warning, Error, Critical)
4. **Sensitive Data**: Never log sensitive data (passwords, tokens, PII)
5. **Performance**: Be mindful of logging overhead in hot paths
6. **Health Checks**: Implement both liveness and readiness probes
7. **Metrics**: Track business and technical metrics separately

## Example Usage

```
Use net-observability skill to:

1. Set up Serilog with structured logging
2. Add OpenTelemetry distributed tracing
3. Configure Prometheus metrics
4. Implement health checks for Kubernetes
5. Add correlation ID tracking
```

I will generate complete observability infrastructure following .NET 8 best practices.
