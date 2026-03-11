using RFCP.Infrastructure.PluginLoader;

namespace RFCP.Drivers.VisionDrivers;

public sealed class HalconVisionDriver : IDeviceDriver
{
    public string Name => "VisionDriver.Halcon";
    public string Category => "Vision";
    public Task Initialize(CancellationToken cancellationToken = default) => Task.CompletedTask;
}
