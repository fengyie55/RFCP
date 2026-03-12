using RFCP.Business.Models;

namespace RFCP.Business.Interfaces;

/// <summary>
/// Defines business task dispatch operations.
/// </summary>
public interface ITaskManager
{
    /// <summary>
    /// Submits a business task to core scheduler.
    /// </summary>
    Task SubmitTaskAsync(BusinessTaskRequest request, CancellationToken cancellationToken);

    /// <summary>
    /// Cancels a submitted task.
    /// </summary>
    Task CancelTaskAsync(string taskId, CancellationToken cancellationToken);
}
