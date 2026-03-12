using RFCP.DeviceAbstraction.Interfaces;
using RFCP.Plugins.Contracts;

namespace RFCP.Drivers.ConveyorDrivers;

/// <summary>
/// Skeleton conveyor driver plugin for future vendor implementation.
/// </summary>
public sealed class SimulatedConveyorDriver : IDeviceDriver, IConveyor
{
    public string Name => "Simulated Conveyor Driver";

    public Version Version => new(1, 0, 0);

    public string DriverType => "Conveyor";

    public string ConveyorId => "SIM-CONVEYOR";

    public Task InitializeAsync(CancellationToken cancellationToken) => Task.CompletedTask;

    public Task StartAsync(CancellationToken cancellationToken) => Task.CompletedTask;

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
