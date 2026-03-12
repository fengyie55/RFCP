namespace RFCP.Core.SystemStateMachine;

/// <summary>
/// Governs RFCP lifecycle transitions and operating modes.
/// </summary>
public sealed class SystemStateMachine
{
    public Task TransitionAsync(string trigger, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
