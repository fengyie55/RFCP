using System.Reflection;

namespace RFCP.Infrastructure.PluginLoader;

public sealed class PluginLoader
{
    public IEnumerable<IDeviceDriver> LoadDrivers(string pluginDirectory)
    {
        if (!Directory.Exists(pluginDirectory))
        {
            yield break;
        }

        foreach (var dll in Directory.EnumerateFiles(pluginDirectory, "*.dll"))
        {
            var assembly = Assembly.LoadFrom(dll);
            var driverTypes = assembly
                .GetTypes()
                .Where(t => typeof(IDeviceDriver).IsAssignableFrom(t) && !t.IsAbstract);

            foreach (var driverType in driverTypes)
            {
                if (Activator.CreateInstance(driverType) is IDeviceDriver driver)
                {
                    yield return driver;
                }
            }
        }
    }
}
