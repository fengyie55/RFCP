namespace RFCP.Platform.ConfigurationManager;

public sealed class ConfigurationManager
{
    private readonly Dictionary<string, string> _settings = new();

    public string? Get(string key) => _settings.GetValueOrDefault(key);
    public void Set(string key, string value) => _settings[key] = value;
}
