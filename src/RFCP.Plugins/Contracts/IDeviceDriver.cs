namespace RFCP.Plugins.Contracts;

/// <summary>
/// Represents a replaceable hardware driver plugin.
/// </summary>
public interface IDeviceDriver : IPlugin
{
    string DriverType { get; }
}
