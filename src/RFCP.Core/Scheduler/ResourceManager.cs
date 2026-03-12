using System.Collections.Concurrent;

namespace RFCP.Core.Scheduler;

/// <summary>
/// Thread-safe shared resource manager used by scheduler for conflict avoidance.
/// </summary>
public sealed class ResourceManager
{
    private readonly ConcurrentDictionary<string, string> _resourceLocks = new();

    /// <summary>
    /// Attempts to reserve a shared resource for a task.
    /// </summary>
    public bool TryAcquire(string resourceKey, string taskId)
    {
        return _resourceLocks.TryAdd(resourceKey, taskId);
    }

    /// <summary>
    /// Releases a shared resource.
    /// </summary>
    public void Release(string resourceKey)
    {
        _resourceLocks.TryRemove(resourceKey, out _);
    }

    /// <summary>
    /// Queries current owner of a resource.
    /// </summary>
    public string? GetOwner(string resourceKey)
    {
        _resourceLocks.TryGetValue(resourceKey, out var owner);
        return owner;
    }
}
