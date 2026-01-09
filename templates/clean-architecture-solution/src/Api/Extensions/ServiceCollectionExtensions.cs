namespace ProjectName.Api.Extensions;

/// <summary>
/// Extension methods for configuring API services.
/// </summary>
public static class ServiceCollectionExtensions
{
    private static readonly string[] DefaultCorsOrigins = { "http://localhost:3000" };
    private static readonly string[] HealthCheckLiveTags = { "live" };

    /// <summary>
    /// Adds API layer services to the service collection.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="configuration">The application configuration.</param>
    /// <returns>The service collection for chaining.</returns>
    public static IServiceCollection AddApiServices(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        // Add controllers
        services.AddControllers();

        // Add Swagger/OpenAPI
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Title = "ProjectName API",
                Version = "v1",
                Description = "Enterprise .NET Clean Architecture API",
                Contact = new Microsoft.OpenApi.Models.OpenApiContact
                {
                    Name = "Support",
                    Email = "support@example.com"
                }
            });

            // Add JWT authentication to Swagger
            options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                Name = "Authorization",
                In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

            options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
            {
                {
                    new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                    {
                        Reference = new Microsoft.OpenApi.Models.OpenApiReference
                        {
                            Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });

            // Include XML comments
            var xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml", SearchOption.TopDirectoryOnly);
            foreach (var xmlFile in xmlFiles)
            {
                options.IncludeXmlComments(xmlFile);
            }
        });

        // Add CORS
        services.AddCors(options =>
        {
            options.AddPolicy("AllowedOrigins", policy =>
            {
                var origins = configuration.GetSection("Cors:AllowedOrigins").Get<string[]>() 
                    ?? DefaultCorsOrigins;
                
                policy
                    .WithOrigins(origins)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
            });
        });

        // Add Health Checks
        services.AddHealthChecks()
            .AddCheck("self", () => Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckResult.Healthy(), 
                tags: HealthCheckLiveTags);

        // Add HttpContext accessor
        services.AddHttpContextAccessor();

        // Add CurrentUserService
        services.AddScoped<Application.Common.Interfaces.ICurrentUserService, Services.CurrentUserService>();

        return services;
    }
}
