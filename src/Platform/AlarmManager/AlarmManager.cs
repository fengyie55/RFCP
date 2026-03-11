namespace RFCP.Platform.AlarmManager;

public sealed class AlarmManager
{
    public event Action<string>? AlarmRaised;

    public void Raise(string code) => AlarmRaised?.Invoke(code);
}
