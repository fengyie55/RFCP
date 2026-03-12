using System.Collections.Concurrent;
using RFCP.Runtime.RuntimeModels;

namespace RFCP.Runtime.MemoryStateStore;

/// <summary>
/// Thread-safe in-memory state repository for deterministic runtime access.
/// </summary>
public sealed class MemoryStateStore
{
    public ConcurrentDictionary<string, RobotState> RobotStates { get; } = new();

    public ConcurrentDictionary<string, PLCState> PlcStates { get; } = new();

    public ConcurrentDictionary<string, VisionState> VisionStates { get; } = new();

    public ConcurrentDictionary<string, ConveyorState> ConveyorStates { get; } = new();

    public SystemState CurrentSystemState { get; private set; } = new("Idle", false, DateTime.UtcNow);

    public void UpdateSystemState(SystemState state)
    {
        CurrentSystemState = state;
    }
}
