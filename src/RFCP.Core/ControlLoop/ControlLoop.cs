namespace RFCP.Core.ControlLoop;

/// <summary>
/// Hosts the deterministic real-time control loop.
/// </summary>
public sealed class ControlLoop
{
    public Task TickAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
