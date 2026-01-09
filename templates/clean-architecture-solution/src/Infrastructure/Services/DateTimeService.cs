using ProjectName.Application.Common.Interfaces;

namespace ProjectName.Infrastructure.Services;

/// <summary>
/// Implementation of IDateTimeService.
/// </summary>
public class DateTimeService : IDateTimeService
{
    /// <inheritdoc/>
    public DateTime UtcNow => DateTime.UtcNow;

    /// <inheritdoc/>
    public DateTime Now => DateTime.Now;

    /// <inheritdoc/>
    public DateOnly TodayUtc => DateOnly.FromDateTime(DateTime.UtcNow);
}
