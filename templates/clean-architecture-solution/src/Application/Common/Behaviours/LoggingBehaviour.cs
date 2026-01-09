using MediatR;
using Microsoft.Extensions.Logging;

namespace ProjectName.Application.Common.Behaviours;

/// <summary>
/// MediatR pipeline behavior that logs all requests and responses.
/// </summary>
/// <typeparam name="TRequest">The request type.</typeparam>
/// <typeparam name="TResponse">The response type.</typeparam>
public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private static readonly Action<ILogger, string, object?, Exception?> LogHandlingRequest =
        LoggerMessage.Define<string, object?>(
            LogLevel.Information,
            new EventId(1000, "HandlingRequest"),
            "Handling {RequestName} {@Request}");

    private static readonly Action<ILogger, string, object?, Exception?> LogHandledRequest =
        LoggerMessage.Define<string, object?>(
            LogLevel.Information,
            new EventId(1001, "HandledRequest"),
            "Handled {RequestName} with response {@Response}");

    private static readonly Action<ILogger, string, string, Exception?> LogHandlingError =
        LoggerMessage.Define<string, string>(
            LogLevel.Error,
            new EventId(1002, "HandlingRequestError"),
            "Error handling {RequestName}: {ErrorMessage}");

    private readonly ILogger<LoggingBehaviour<TRequest, TResponse>> _logger;

    public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(
        TRequest request, 
        RequestHandlerDelegate<TResponse> next, 
        CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;

        LogHandlingRequest(_logger, requestName, request, null);

        try
        {
            var response = await next();

            LogHandledRequest(_logger, requestName, response, null);

            return response;
        }
        catch (Exception ex)
        {
            LogHandlingError(_logger, requestName, ex.Message, ex);

            throw;
        }
    }
}
