namespace RFCP.Runtime.RuntimeModels;

/// <summary>
/// Runtime state for robot subsystem.
/// </summary>
public sealed record RobotState(string RobotId, string Status);

/// <summary>
/// Runtime state for PLC subsystem.
/// </summary>
public sealed record PLCState(string PlcId, bool IsConnected);

/// <summary>
/// Runtime state for vision subsystem.
/// </summary>
public sealed record VisionState(string VisionId, string LastResult);

/// <summary>
/// Runtime state for conveyor subsystem.
/// </summary>
public sealed record ConveyorState(string ConveyorId, bool Running);

/// <summary>
/// Runtime state for overall system.
/// </summary>
public sealed record SystemState(string Mode, bool IsRunning, DateTime UpdatedAtUtc);
