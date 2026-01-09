using System.Diagnostics;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ProjectName.Application.Common.Behaviours;

/// <summary>
/// MediatR pipeline behavior that logs slow-running requests.
/// </summary>
/// <typeparam name="TRequest">The request type.</typeparam>
/// <typeparam name="TResponse">The response type.</typeparam>
public class PerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private static readonly Action<ILogger, string, long, object?, Exception?> LogLongRunningRequest =
        LoggerMessage.Define<string, long, object?>(
            LogLevel.Warning,
            new EventId(1100, "LongRunningRequest"),
            "Long Running Request: {RequestName} ({ElapsedMilliseconds}ms) {@Request}");

    private readonly Stopwatch _timer;
    private readonly ILogger<PerformanceBehaviour<TRequest, TResponse>> _logger;

    /// <summary>
    /// Threshold in milliseconds for logging slow requests.
    /// </summary>
    private const int SlowRequestThresholdMs = 500;

    public PerformanceBehaviour(ILogger<PerformanceBehaviour<TRequest, TResponse>> logger)
    {
        _timer = new Stopwatch();
        _logger = logger;
    }

    public async Task<TResponse> Handle(
        TRequest request, 
        RequestHandlerDelegate<TResponse> next, 
        CancellationToken cancellationToken)
    {
        _timer.Start();

        var response = await next();

        _timer.Stop();

        var elapsedMilliseconds = _timer.ElapsedMilliseconds;

        if (elapsedMilliseconds > SlowRequestThresholdMs)
        {
            var requestName = typeof(TRequest).Name;

            LogLongRunningRequest(_logger, requestName, elapsedMilliseconds, request, null);
        }

        return response;
    }
}
