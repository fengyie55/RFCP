namespace RFCP.Core.Scheduler;

public sealed record RobotTask(string Id, string RobotId, int Priority, Func<CancellationToken, Task> ExecuteAsync);

public interface IMultiRobotTaskScheduler
{
    void Enqueue(RobotTask task);
    Task<RobotTask?> DequeueNext(string robotId, CancellationToken cancellationToken = default);
}

public sealed class MultiRobotTaskScheduler : IMultiRobotTaskScheduler
{
    private readonly object _lock = new();
    private readonly List<RobotTask> _queue = new();

    public void Enqueue(RobotTask task)
    {
        lock (_lock)
        {
            _queue.Add(task);
        }
    }

    public Task<RobotTask?> DequeueNext(string robotId, CancellationToken cancellationToken = default)
    {
        lock (_lock)
        {
            var next = _queue
                .Where(t => t.RobotId == robotId)
                .OrderByDescending(t => t.Priority)
                .ThenBy(t => t.Id)
                .FirstOrDefault();

            if (next is not null)
            {
                _queue.Remove(next);
            }

            return Task.FromResult(next);
        }
    }
}
