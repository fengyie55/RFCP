using RFCP.Infrastructure.PluginLoader;

namespace RFCP.Drivers.RobotDrivers;

public sealed class FanucRobotDriver : IDeviceDriver
{
    public string Name => "RobotDriver.FANUC";
    public string Category => "Robot";
    public Task Initialize(CancellationToken cancellationToken = default) => Task.CompletedTask;
}
