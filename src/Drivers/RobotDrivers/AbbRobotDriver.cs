using RFCP.Infrastructure.PluginLoader;

namespace RFCP.Drivers.RobotDrivers;

public sealed class AbbRobotDriver : IDeviceDriver
{
    public string Name => "RobotDriver.ABB";
    public string Category => "Robot";
    public Task Initialize(CancellationToken cancellationToken = default) => Task.CompletedTask;
}
