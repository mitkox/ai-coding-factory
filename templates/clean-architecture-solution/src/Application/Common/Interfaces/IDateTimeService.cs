namespace ProjectName.Application.Common.Interfaces;

/// <summary>
/// Interface for date/time service to enable testability.
/// </summary>
public interface IDateTimeService
{
    /// <summary>
    /// Gets the current UTC date and time.
    /// </summary>
    DateTime UtcNow { get; }

    /// <summary>
    /// Gets the current local date and time.
    /// </summary>
    DateTime Now { get; }

    /// <summary>
    /// Gets today's date in UTC.
    /// </summary>
    DateOnly TodayUtc { get; }
}
