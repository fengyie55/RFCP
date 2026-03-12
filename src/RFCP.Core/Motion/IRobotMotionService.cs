namespace RFCP.Core.Motion;

/// <summary>
/// Defines a thread-safe robot motion abstraction for connect/disconnect and command execution.
/// </summary>
public interface IRobotMotionService
{
    /// <summary>
    /// Connects to a specific robot controller.
    /// </summary>
    Task ConnectAsync(string robotId, CancellationToken cancellationToken);

    /// <summary>
    /// Disconnects from a specific robot controller.
    /// </summary>
    Task DisconnectAsync(string robotId, CancellationToken cancellationToken);

    /// <summary>
    /// Executes a joint-space motion command (MoveJ).
    /// </summary>
    Task ExecuteMoveJAsync(string robotId, MotionCommand command, CancellationToken cancellationToken);

    /// <summary>
    /// Executes a linear-space motion command (MoveL).
    /// </summary>
    Task ExecuteMoveLAsync(string robotId, MotionCommand command, CancellationToken cancellationToken);

    /// <summary>
    /// Stops robot motion as quickly and safely as possible.
    /// </summary>
    Task StopAsync(string robotId, CancellationToken cancellationToken);

    /// <summary>
    /// Plans an intermediate trajectory between two poses.
    /// </summary>
    Task<IReadOnlyList<Pose>> PlanTrajectoryAsync(string robotId, Pose start, Pose target, CancellationToken cancellationToken);

    /// <summary>
    /// Gets the latest known robot state.
    /// </summary>
    Task<RobotState> GetStateAsync(string robotId, CancellationToken cancellationToken);
}
