namespace RFCP.Core.Scheduler;

/// <summary>
/// Represents a high-level production task assigned to a robot.
/// </summary>
public sealed class RobotTask
{
    /// <summary>
    /// Gets or sets unique task identifier.
    /// </summary>
    public string TaskId { get; init; } = Guid.NewGuid().ToString("N");

    /// <summary>
    /// Gets or sets target robot identifier.
    /// </summary>
    public string RobotId { get; init; } = string.Empty;

    /// <summary>
    /// Gets or sets task type.
    /// </summary>
    public string TaskType { get; init; } = string.Empty;

    /// <summary>
    /// Gets or sets optional shared resource keys required by the task.
    /// </summary>
    public IReadOnlyList<string> RequiredResources { get; init; } = Array.Empty<string>();
}
