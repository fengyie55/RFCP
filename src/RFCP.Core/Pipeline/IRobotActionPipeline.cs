namespace RFCP.Core.Pipeline;

/// <summary>
/// Defines a thread-safe action pipeline interface for robot task execution.
/// </summary>
public interface IRobotActionPipeline
{
    /// <summary>
    /// Enqueues a pipeline task.
    /// </summary>
    Task EnqueueTaskAsync(PipelineTask task, CancellationToken cancellationToken);

    /// <summary>
    /// Executes the next available action.
    /// </summary>
    Task ExecuteNextActionAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Cancels all pending actions for a task.
    /// </summary>
    Task CancelTaskAsync(string taskId, CancellationToken cancellationToken);
}
