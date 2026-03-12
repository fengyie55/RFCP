namespace RFCP.Platform.Alarm;

/// <summary>
/// Defines alarm management capabilities.
/// </summary>
public interface IAlarmManager
{
    /// <summary>
    /// Raises an alarm.
    /// </summary>
    Task RaiseAlarmAsync(string code, string message, CancellationToken cancellationToken);
}
