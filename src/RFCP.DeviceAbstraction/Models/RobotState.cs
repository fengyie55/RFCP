namespace RFCP.DeviceAbstraction.Models;

/// <summary>
/// Represents robot telemetry and execution state.
/// </summary>
public sealed record RobotState(string RobotId, bool IsEnabled, bool IsInAlarm, Pose CurrentPose);
