using RFCP.Infrastructure.PluginLoader;

namespace RFCP.Drivers.PLCDrivers;

public sealed class SiemensPlcDriver : IDeviceDriver
{
    public string Name => "PLCDriver.Siemens";
    public string Category => "PLC";
    public Task Initialize(CancellationToken cancellationToken = default) => Task.CompletedTask;
}
