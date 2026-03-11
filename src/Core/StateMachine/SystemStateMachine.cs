namespace RFCP.Core.StateMachine;

public enum SystemState
{
    Idle,
    Running,
    Paused,
    Faulted,
    Stopped
}

public sealed class SystemStateMachine
{
    public SystemState Current { get; private set; } = SystemState.Idle;

    public void TransitionTo(SystemState next) => Current = next;
}
