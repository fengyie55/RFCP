using RFCP.Runtime.MemoryStateStore;
using RFCP.Runtime.RuntimeModels;

namespace RFCP.Runtime.RuntimeServices;

/// <summary>
/// Service API for runtime state read/write operations.
/// </summary>
public sealed class RuntimeStateService
{
    private readonly MemoryStateStore _stateStore;

    public RuntimeStateService(MemoryStateStore stateStore)
    {
        _stateStore = stateStore;
    }

    public void SetRobotState(RobotState state) => _stateStore.RobotStates[state.RobotId] = state;

    public void SetPlcState(PLCState state) => _stateStore.PlcStates[state.PlcId] = state;

    public void SetVisionState(VisionState state) => _stateStore.VisionStates[state.VisionId] = state;

    public void SetConveyorState(ConveyorState state) => _stateStore.ConveyorStates[state.ConveyorId] = state;

    public void SetSystemState(SystemState state) => _stateStore.UpdateSystemState(state);
}
