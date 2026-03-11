namespace RFCP.Platform.Logging;

public interface ILogService
{
    void Info(string message);
    void Error(string message, Exception? exception = null);
}

public sealed class LogService : ILogService
{
    public void Info(string message) => Console.WriteLine($"[INFO] {DateTime.UtcNow:o} {message}");
    public void Error(string message, Exception? exception = null) => Console.WriteLine($"[ERROR] {DateTime.UtcNow:o} {message} {exception}");
}
