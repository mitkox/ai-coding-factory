namespace ProjectName.Api.Extensions;

/// <summary>
/// Extension methods for configuring the application builder.
/// </summary>
public static class ApplicationBuilderExtensions
{
    /// <summary>
    /// Adds security headers to all responses.
    /// </summary>
    /// <param name="app">The application builder.</param>
    /// <returns>The application builder for chaining.</returns>
    public static IApplicationBuilder UseSecurityHeaders(this IApplicationBuilder app)
    {
        return app.Use(async (context, next) =>
        {
            // Prevent MIME type sniffing
            context.Response.Headers.Append("X-Content-Type-Options", "nosniff");

            // Prevent clickjacking
            context.Response.Headers.Append("X-Frame-Options", "DENY");

            // Enable XSS protection
            context.Response.Headers.Append("X-XSS-Protection", "1; mode=block");

            // Referrer policy
            context.Response.Headers.Append("Referrer-Policy", "strict-origin-when-cross-origin");

            // Permissions policy (formerly Feature-Policy)
            context.Response.Headers.Append("Permissions-Policy", 
                "accelerometer=(), camera=(), geolocation=(), gyroscope=(), magnetometer=(), microphone=(), payment=(), usb=()");

            // Content Security Policy
            context.Response.Headers.Append("Content-Security-Policy", 
                "default-src 'self'; script-src 'self' 'unsafe-inline'; style-src 'self' 'unsafe-inline'; img-src 'self' data:; font-src 'self'; frame-ancestors 'none';");

            await next();
        });
    }
}
