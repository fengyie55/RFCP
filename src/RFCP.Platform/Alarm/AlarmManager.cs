namespace RFCP.Platform.Alarm;

/// <summary>
/// Alarm manager skeleton for alarm lifecycle operations.
/// </summary>
public sealed class AlarmManager : IAlarmManager
{
    /// <inheritdoc />
    public Task RaiseAlarmAsync(string code, string message, CancellationToken cancellationToken)
    {
        // TODO: Push alarm to event bus and persistent alarm log.
        return Task.CompletedTask;
    }
}
