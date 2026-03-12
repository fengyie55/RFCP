namespace RFCP.DeviceAbstraction.Models;

/// <summary>
/// Represents a deterministic motion command to be executed by a robot.
/// </summary>
public sealed record MotionCommand(string CommandId, Pose TargetPose, double Speed, double Acceleration);
