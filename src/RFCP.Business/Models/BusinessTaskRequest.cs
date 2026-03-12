namespace RFCP.Business.Models;

/// <summary>
/// Represents a business-level request that can be translated into a core robot task.
/// </summary>
public sealed class BusinessTaskRequest
{
    /// <summary>
    /// Gets or sets the external business task identifier.
    /// </summary>
    public string RequestId { get; init; } = Guid.NewGuid().ToString("N");

    /// <summary>
    /// Gets or sets target robot id.
    /// </summary>
    public string RobotId { get; init; } = string.Empty;

    /// <summary>
    /// Gets or sets high-level operation type.
    /// </summary>
    public string OperationType { get; init; } = string.Empty;

    /// <summary>
    /// Gets or sets required shared resource keys.
    /// </summary>
    public IReadOnlyList<string> RequiredResources { get; init; } = Array.Empty<string>();
}
