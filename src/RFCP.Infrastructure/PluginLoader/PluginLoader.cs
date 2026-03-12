using System.Reflection;
using RFCP.Plugins.Contracts;

namespace RFCP.Infrastructure.PluginLoader;

/// <summary>
/// Dynamically loads plugins from a filesystem folder (default: /plugins).
/// </summary>
public sealed class PluginLoader : IPluginLoader
{
    /// <inheritdoc />
    public Task<IReadOnlyCollection<IPlugin>> LoadFromPluginsFolderAsync(string pluginsFolder, CancellationToken cancellationToken)
    {
        var loaded = new List<IPlugin>();

        if (!Directory.Exists(pluginsFolder))
        {
            return Task.FromResult<IReadOnlyCollection<IPlugin>>(loaded);
        }

        foreach (var assemblyPath in Directory.EnumerateFiles(pluginsFolder, "*.dll", SearchOption.TopDirectoryOnly))
        {
            cancellationToken.ThrowIfCancellationRequested();

            // TODO: Add secure assembly validation and manifest-based filtering.
            var assembly = Assembly.LoadFrom(assemblyPath);
            foreach (var type in assembly.GetTypes())
            {
                if (!typeof(IPlugin).IsAssignableFrom(type) || type.IsAbstract || type.IsInterface)
                {
                    continue;
                }

                if (Activator.CreateInstance(type) is IPlugin plugin)
                {
                    loaded.Add(plugin);
                }
            }
        }

        return Task.FromResult<IReadOnlyCollection<IPlugin>>(loaded);
    }
}
