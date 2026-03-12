using System.Collections.Concurrent;
using RFCP.Core.Pipeline;
using RFCP.Infrastructure.EventBus;

namespace RFCP.Core.Scheduler;

/// <summary>
/// Thread-safe multi-robot task scheduler skeleton with shared-resource coordination.
/// </summary>
public sealed class MultiRobotTaskScheduler : IMultiRobotTaskScheduler
{
    private readonly TaskQueue _taskQueue;
    private readonly ResourceManager _resourceManager;
    private readonly IRobotActionPipeline _pipeline;
    private readonly IEventBus _eventBus;
    private readonly ConcurrentDictionary<string, string> _taskStatus = new();
    private readonly SemaphoreSlim _dispatchSemaphore = new(1, 1);

    /// <summary>
    /// Initializes a new instance of the <see cref="MultiRobotTaskScheduler"/> class.
    /// </summary>
    public MultiRobotTaskScheduler(
        TaskQueue taskQueue,
        ResourceManager resourceManager,
        IRobotActionPipeline pipeline,
        IEventBus eventBus)
    {
        _taskQueue = taskQueue;
        _resourceManager = resourceManager;
        _pipeline = pipeline;
        _eventBus = eventBus;
    }

    #region Scheduler API

    /// <inheritdoc />
    public async Task ScheduleTaskAsync(RobotTask task, CancellationToken cancellationToken)
    {
        _taskQueue.Enqueue(task);
        _taskStatus[task.TaskId] = "Queued";

        _eventBus.Publish(new SchedulerTaskQueuedEvent(task.TaskId, task.RobotId));
        await DispatchNextAsync(cancellationToken);
    }

    /// <inheritdoc />
    public Task CancelTaskAsync(string taskId, CancellationToken cancellationToken)
    {
        _taskStatus[taskId] = "Canceled";
        _eventBus.Publish(new SchedulerTaskCanceledEvent(taskId));
        // TODO: Ensure cancellation flows to queue/pipeline and resource cleanup.
        return Task.CompletedTask;
    }

    /// <inheritdoc />
    public Task<string> QueryStatusAsync(string taskId, CancellationToken cancellationToken)
    {
        return Task.FromResult(_taskStatus.TryGetValue(taskId, out var status) ? status : "Unknown");
    }

    #endregion

    #region Internal Dispatch

    private async Task DispatchNextAsync(CancellationToken cancellationToken)
    {
        await _dispatchSemaphore.WaitAsync(cancellationToken);
        try
        {
            if (!_taskQueue.TryDequeue(out var task) || task is null)
            {
                return;
            }

            // TODO: Add collision checks and deterministic route arbitration.
            var resourcesAcquired = task.RequiredResources.All(resource => _resourceManager.TryAcquire(resource, task.TaskId));
            if (!resourcesAcquired)
            {
                _taskStatus[task.TaskId] = "WaitingResource";
                _taskQueue.Enqueue(task);
                return;
            }

            var pipelineTask = new PipelineTask
            {
                RobotTask = task,
                Actions = Array.Empty<RobotAction>() // TODO: Plug in decomposition strategy.
            };

            _taskStatus[task.TaskId] = "Dispatched";
            await _pipeline.EnqueueTaskAsync(pipelineTask, cancellationToken);
            _eventBus.Publish(new SchedulerTaskDispatchedEvent(task.TaskId, task.RobotId));
        }
        finally
        {
            _dispatchSemaphore.Release();
        }
    }

    #endregion
}

/// <summary>
/// Event raised when a scheduler task enters queue.
/// </summary>
public sealed record SchedulerTaskQueuedEvent(string TaskId, string RobotId);

/// <summary>
/// Event raised when a scheduler task is dispatched to pipeline.
/// </summary>
public sealed record SchedulerTaskDispatchedEvent(string TaskId, string RobotId);

/// <summary>
/// Event raised when a scheduler task is canceled.
/// </summary>
public sealed record SchedulerTaskCanceledEvent(string TaskId);
