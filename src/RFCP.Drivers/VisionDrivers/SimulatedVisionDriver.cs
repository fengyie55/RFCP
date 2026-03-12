using RFCP.DeviceAbstraction.Interfaces;
using RFCP.Plugins.Contracts;

namespace RFCP.Drivers.VisionDrivers;

/// <summary>
/// Skeleton vision driver plugin for future vendor implementation.
/// </summary>
public sealed class SimulatedVisionDriver : IDeviceDriver, IVision
{
    public string Name => "Simulated Vision Driver";

    public Version Version => new(1, 0, 0);

    public string DriverType => "Vision";

    public string VisionId => "SIM-VISION";

    public Task InitializeAsync(CancellationToken cancellationToken) => Task.CompletedTask;

    public Task<string> AcquireResultAsync(string recipeId, CancellationToken cancellationToken)
        => Task.FromResult("Pending");
}
