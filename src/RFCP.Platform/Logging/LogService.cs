using System.Collections.Concurrent;

namespace RFCP.Platform.Logging;

/// <summary>
/// Thread-safe in-memory logging service skeleton.
/// </summary>
public sealed class LogService : ILogService
{
    private readonly ConcurrentQueue<string> _entries = new();

    /// <inheritdoc />
    public void Info(string message)
    {
        _entries.Enqueue($"INFO:{DateTime.UtcNow:O}:{message}");
        // TODO: Integrate external logger sink.
    }

    /// <inheritdoc />
    public void Error(string message)
    {
        _entries.Enqueue($"ERROR:{DateTime.UtcNow:O}:{message}");
        // TODO: Integrate external logger sink.
    }
}
