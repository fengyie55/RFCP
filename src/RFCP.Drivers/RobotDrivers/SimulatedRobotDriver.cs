using RFCP.DeviceAbstraction.Interfaces;
using RFCP.DeviceAbstraction.Models;
using RFCP.Plugins.Contracts;

namespace RFCP.Drivers.RobotDrivers;

/// <summary>
/// Skeleton robot driver plugin for future vendor implementation.
/// </summary>
public sealed class SimulatedRobotDriver : IDeviceDriver, IRobot
{
    public string Name => "Simulated Robot Driver";

    public Version Version => new(1, 0, 0);

    public string DriverType => "Robot";

    public string RobotId => "SIM-ROBOT";

    public Task InitializeAsync(CancellationToken cancellationToken) => Task.CompletedTask;

    public Task ExecuteMotionAsync(MotionCommand command, CancellationToken cancellationToken) => Task.CompletedTask;

    public Task<RobotState> GetStateAsync(CancellationToken cancellationToken)
        => Task.FromResult(new RobotState(RobotId, true, false, new Pose(0, 0, 0, 0, 0, 0)));
}
