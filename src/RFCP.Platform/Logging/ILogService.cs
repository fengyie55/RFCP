namespace RFCP.Platform.Logging;

/// <summary>
/// Defines logging abstraction for cross-module diagnostics.
/// </summary>
public interface ILogService
{
    /// <summary>
    /// Writes an informational message.
    /// </summary>
    void Info(string message);

    /// <summary>
    /// Writes an error message.
    /// </summary>
    void Error(string message);
}
