namespace RFCP.Platform.Records;

/// <summary>
/// Defines processing record service.
/// </summary>
public interface IProcessingRecordService
{
    /// <summary>
    /// Records processing event.
    /// </summary>
    Task RecordAsync(string recordId, CancellationToken cancellationToken);
}
