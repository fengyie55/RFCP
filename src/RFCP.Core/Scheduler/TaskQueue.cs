using System.Collections.Concurrent;

namespace RFCP.Core.Scheduler;

/// <summary>
/// Thread-safe queue abstraction for robot scheduling tasks.
/// </summary>
public sealed class TaskQueue
{
    private readonly ConcurrentQueue<RobotTask> _queue = new();

    /// <summary>
    /// Enqueues a robot task.
    /// </summary>
    public void Enqueue(RobotTask task) => _queue.Enqueue(task);

    /// <summary>
    /// Attempts to dequeue a robot task.
    /// </summary>
    public bool TryDequeue(out RobotTask? task) => _queue.TryDequeue(out task);
}
