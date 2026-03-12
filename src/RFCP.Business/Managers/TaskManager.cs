using RFCP.Business.Interfaces;
using RFCP.Business.Models;
using RFCP.Core.Scheduler;

namespace RFCP.Business.Managers;

/// <summary>
/// Task manager skeleton that forwards business tasks to the multi-robot scheduler.
/// </summary>
public sealed class TaskManager : ITaskManager
{
    private readonly IMultiRobotTaskScheduler _scheduler;

    /// <summary>
    /// Initializes a new instance of the <see cref="TaskManager"/> class.
    /// </summary>
    public TaskManager(IMultiRobotTaskScheduler scheduler)
    {
        _scheduler = scheduler;
    }

    /// <inheritdoc />
    public Task SubmitTaskAsync(BusinessTaskRequest request, CancellationToken cancellationToken)
    {
        var task = new RobotTask
        {
            TaskId = request.RequestId,
            RobotId = request.RobotId,
            TaskType = request.OperationType,
            RequiredResources = request.RequiredResources
        };

        // TODO: Apply business validation and dispatch policy.
        return _scheduler.ScheduleTaskAsync(task, cancellationToken);
    }

    /// <inheritdoc />
    public Task CancelTaskAsync(string taskId, CancellationToken cancellationToken)
    {
        // TODO: Add cancellation policy and audit log.
        return _scheduler.CancelTaskAsync(taskId, cancellationToken);
    }
}
