namespace RFCP.Core.MotionPlanner;

/// <summary>
/// Plans safe, collision-aware robot motions.
/// </summary>
public sealed class MotionPlanner
{
    public Task PlanAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
