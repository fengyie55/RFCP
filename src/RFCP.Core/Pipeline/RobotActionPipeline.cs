using System.Collections.Concurrent;
using RFCP.Core.Motion;
using RFCP.Infrastructure.EventBus;

namespace RFCP.Core.Pipeline;

/// <summary>
/// Thread-safe robot action pipeline engine that executes decomposed actions via motion service.
/// </summary>
public sealed class RobotActionPipeline : IRobotActionPipeline
{
    private readonly IRobotMotionService _robotMotionService;
    private readonly IEventBus _eventBus;
    private readonly ConcurrentQueue<RobotAction> _actionQueue = new();
    private readonly ConcurrentDictionary<string, byte> _activeTasks = new();
    private readonly SemaphoreSlim _executionSemaphore = new(1, 1);

    /// <summary>
    /// Initializes a new instance of the <see cref="RobotActionPipeline"/> class.
    /// </summary>
    public RobotActionPipeline(IRobotMotionService robotMotionService, IEventBus eventBus)
    {
        _robotMotionService = robotMotionService;
        _eventBus = eventBus;
    }

    #region Public API

    /// <inheritdoc />
    public Task EnqueueTaskAsync(PipelineTask task, CancellationToken cancellationToken)
    {
        _activeTasks[task.RobotTask.TaskId] = 0;

        foreach (var action in task.Actions)
        {
            _actionQueue.Enqueue(action);
        }

        _eventBus.Publish(new PipelineTaskEnqueuedEvent(task.RobotTask.TaskId, task.RobotTask.RobotId));
        // TODO: Add deterministic ordering, priority and sequence checks.
        return Task.CompletedTask;
    }

    /// <inheritdoc />
    public async Task ExecuteNextActionAsync(CancellationToken cancellationToken)
    {
        await _executionSemaphore.WaitAsync(cancellationToken);
        try
        {
            if (!_actionQueue.TryDequeue(out var action))
            {
                return;
            }

            switch (action)
            {
                case MoveAction:
                    // TODO: Map MoveAction to MoveJ/MoveL selection logic.
                    break;
                case PickAction:
                    // TODO: Implement grasp sequence orchestration.
                    break;
                case PlaceAction:
                    // TODO: Implement place sequence orchestration.
                    break;
                case VisionLocateAction:
                    // TODO: Invoke vision subsystem and calibration pipeline.
                    break;
            }

            _eventBus.Publish(new PipelineActionExecutedEvent(action.TaskId, action.ActionId, action.ActionType));
        }
        finally
        {
            _executionSemaphore.Release();
        }
    }

    /// <inheritdoc />
    public Task CancelTaskAsync(string taskId, CancellationToken cancellationToken)
    {
        _activeTasks.TryRemove(taskId, out _);
        _eventBus.Publish(new PipelineTaskCanceledEvent(taskId));
        // TODO: Remove queued actions for the specified task with minimal lock contention.
        return Task.CompletedTask;
    }

    #endregion
}

/// <summary>
/// Event raised when a pipeline task is enqueued.
/// </summary>
public sealed record PipelineTaskEnqueuedEvent(string TaskId, string RobotId);

/// <summary>
/// Event raised when an action is executed.
/// </summary>
public sealed record PipelineActionExecutedEvent(string TaskId, string ActionId, string ActionType);

/// <summary>
/// Event raised when a pipeline task is canceled.
/// </summary>
public sealed record PipelineTaskCanceledEvent(string TaskId);
