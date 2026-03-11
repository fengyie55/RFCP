using RFCP.Infrastructure.PluginLoader;

namespace RFCP.Drivers.RobotDrivers;

public sealed class KukaRobotDriver : IDeviceDriver
{
    public string Name => "RobotDriver.KUKA";
    public string Category => "Robot";
    public Task Initialize(CancellationToken cancellationToken = default) => Task.CompletedTask;
}
