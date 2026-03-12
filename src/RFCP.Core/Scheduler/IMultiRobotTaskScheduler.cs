namespace RFCP.Core.Scheduler;

/// <summary>
/// Defines a thread-safe multi-robot task scheduling interface.
/// </summary>
public interface IMultiRobotTaskScheduler
{
    /// <summary>
    /// Schedules a task for dispatch.
    /// </summary>
    Task ScheduleTaskAsync(RobotTask task, CancellationToken cancellationToken);

    /// <summary>
    /// Cancels a scheduled task.
    /// </summary>
    Task CancelTaskAsync(string taskId, CancellationToken cancellationToken);

    /// <summary>
    /// Queries scheduler status for a task.
    /// </summary>
    Task<string> QueryStatusAsync(string taskId, CancellationToken cancellationToken);
}
