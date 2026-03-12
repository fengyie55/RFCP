namespace RFCP.Plugins.Models;

/// <summary>
/// Describes plugin metadata for discovery and loading.
/// </summary>
public sealed class PluginManifest
{
    public string Name { get; init; } = string.Empty;

    public string AssemblyPath { get; init; } = string.Empty;

    public string EntryType { get; init; } = string.Empty;

    public string DriverType { get; init; } = string.Empty;

    public string Version { get; init; } = "1.0.0";
}
