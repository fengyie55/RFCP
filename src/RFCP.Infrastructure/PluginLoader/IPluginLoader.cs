using RFCP.Plugins.Contracts;

namespace RFCP.Infrastructure.PluginLoader;

/// <summary>
/// Defines plugin loading operations for dynamically discovered device drivers.
/// </summary>
public interface IPluginLoader
{
    /// <summary>
    /// Loads plugin instances from the configured plugins folder.
    /// </summary>
    Task<IReadOnlyCollection<IPlugin>> LoadFromPluginsFolderAsync(string pluginsFolder, CancellationToken cancellationToken);
}
