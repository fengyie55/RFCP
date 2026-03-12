using System.Collections.Concurrent;

namespace RFCP.Platform.Configuration;

/// <summary>
/// Configuration manager skeleton using thread-safe storage.
/// </summary>
public sealed class ConfigurationManager : IConfigurationManager
{
    private readonly ConcurrentDictionary<string, string> _values = new();

    /// <inheritdoc />
    public Task<string?> GetValueAsync(string key, CancellationToken cancellationToken)
    {
        _values.TryGetValue(key, out var value);
        // TODO: Load from external configuration providers.
        return Task.FromResult<string?>(value);
    }
}
