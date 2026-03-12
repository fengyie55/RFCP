using RFCP.Core.Scheduler;

namespace RFCP.Core.Pipeline;

/// <summary>
/// Represents a task payload accepted by the action pipeline.
/// </summary>
public sealed class PipelineTask
{
    /// <summary>
    /// Gets or sets the source robot task.
    /// </summary>
    public required RobotTask RobotTask { get; init; }

    /// <summary>
    /// Gets or sets decomposed actions.
    /// </summary>
    public IReadOnlyList<RobotAction> Actions { get; init; } = Array.Empty<RobotAction>();
}
