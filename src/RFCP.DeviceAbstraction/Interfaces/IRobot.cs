using RFCP.DeviceAbstraction.Models;

namespace RFCP.DeviceAbstraction.Interfaces;

/// <summary>
/// Abstract contract for robot controller integrations.
/// </summary>
public interface IRobot
{
    string RobotId { get; }

    Task InitializeAsync(CancellationToken cancellationToken);

    Task ExecuteMotionAsync(MotionCommand command, CancellationToken cancellationToken);

    Task<RobotState> GetStateAsync(CancellationToken cancellationToken);
}
