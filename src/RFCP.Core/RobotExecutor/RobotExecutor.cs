namespace RFCP.Core.RobotExecutor;

/// <summary>
/// Executes robot commands against abstracted robot devices.
/// </summary>
public sealed class RobotExecutor
{
    public Task ExecuteAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
