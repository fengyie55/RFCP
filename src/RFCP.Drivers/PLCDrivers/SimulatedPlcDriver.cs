using RFCP.DeviceAbstraction.Interfaces;
using RFCP.Plugins.Contracts;

namespace RFCP.Drivers.PLCDrivers;

/// <summary>
/// Skeleton PLC driver plugin for future vendor implementation.
/// </summary>
public sealed class SimulatedPlcDriver : IDeviceDriver, IPLC
{
    public string Name => "Simulated PLC Driver";

    public Version Version => new(1, 0, 0);

    public string DriverType => "PLC";

    public string PlcId => "SIM-PLC";

    public Task InitializeAsync(CancellationToken cancellationToken) => Task.CompletedTask;

    public Task<bool> ReadBitAsync(string address, CancellationToken cancellationToken) => Task.FromResult(false);

    public Task WriteBitAsync(string address, bool value, CancellationToken cancellationToken) => Task.CompletedTask;
}
