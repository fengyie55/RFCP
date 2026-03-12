namespace RFCP.Core.Pipeline;

/// <summary>
/// Base class for decomposed robot actions in an execution pipeline.
/// </summary>
public abstract class RobotAction
{
    /// <summary>
    /// Gets or sets the parent task identifier.
    /// </summary>
    public string TaskId { get; init; } = string.Empty;

    /// <summary>
    /// Gets or sets action identifier for traceability.
    /// </summary>
    public string ActionId { get; init; } = Guid.NewGuid().ToString("N");

    /// <summary>
    /// Gets action type name.
    /// </summary>
    public abstract string ActionType { get; }
}

/// <summary>
/// Pick action placeholder.
/// </summary>
public sealed class PickAction : RobotAction
{
    /// <inheritdoc />
    public override string ActionType => nameof(PickAction);
}

/// <summary>
/// Place action placeholder.
/// </summary>
public sealed class PlaceAction : RobotAction
{
    /// <inheritdoc />
    public override string ActionType => nameof(PlaceAction);
}

/// <summary>
/// Move action placeholder.
/// </summary>
public sealed class MoveAction : RobotAction
{
    /// <inheritdoc />
    public override string ActionType => nameof(MoveAction);
}

/// <summary>
/// Vision location action placeholder.
/// </summary>
public sealed class VisionLocateAction : RobotAction
{
    /// <inheritdoc />
    public override string ActionType => nameof(VisionLocateAction);
}
