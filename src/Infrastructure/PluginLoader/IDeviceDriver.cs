namespace RFCP.Infrastructure.PluginLoader;

public interface IDeviceDriver
{
    string Name { get; }
    string Category { get; }
    Task Initialize(CancellationToken cancellationToken = default);
}
