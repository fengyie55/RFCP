namespace RFCP.Core.Motion;

/// <summary>
/// Represents Cartesian pose and orientation for robot motion targets.
/// </summary>
public readonly record struct Pose(double X, double Y, double Z, double Rx, double Ry, double Rz);

/// <summary>
/// Represents a motion command that can be interpreted by a robot driver.
/// </summary>
public sealed class MotionCommand
{
    /// <summary>
    /// Gets or sets the unique command identifier.
    /// </summary>
    public string CommandId { get; init; } = Guid.NewGuid().ToString("N");

    /// <summary>
    /// Gets or sets the command type (MoveJ, MoveL, Stop).
    /// </summary>
    public string CommandType { get; init; } = string.Empty;

    /// <summary>
    /// Gets or sets the target pose for motion commands.
    /// </summary>
    public Pose TargetPose { get; init; }

    /// <summary>
    /// Gets or sets the motion speed parameter.
    /// </summary>
    public double Speed { get; init; }

    /// <summary>
    /// Gets or sets the motion acceleration parameter.
    /// </summary>
    public double Acceleration { get; init; }
}

/// <summary>
/// Represents the runtime state of a robot in the motion subsystem.
/// </summary>
public sealed class RobotState
{
    /// <summary>
    /// Gets or sets the robot identifier.
    /// </summary>
    public string RobotId { get; init; } = string.Empty;

    /// <summary>
    /// Gets or sets a value indicating whether the robot is connected.
    /// </summary>
    public bool IsConnected { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the robot is in alarm.
    /// </summary>
    public bool IsInAlarm { get; set; }

    /// <summary>
    /// Gets or sets the latest known pose.
    /// </summary>
    public Pose CurrentPose { get; set; }
}
