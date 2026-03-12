namespace RFCP.Platform.Configuration;

/// <summary>
/// Defines centralized configuration access.
/// </summary>
public interface IConfigurationManager
{
    /// <summary>
    /// Gets configuration value by key.
    /// </summary>
    Task<string?> GetValueAsync(string key, CancellationToken cancellationToken);
}
