namespace RFCP.Plugins.Contracts;

/// <summary>
/// Base contract for all dynamically loadable RFCP plugins.
/// </summary>
public interface IPlugin
{
    string Name { get; }

    Version Version { get; }

    Task InitializeAsync(CancellationToken cancellationToken);
}
