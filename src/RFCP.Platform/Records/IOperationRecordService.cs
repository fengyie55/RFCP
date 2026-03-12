namespace RFCP.Platform.Records;

/// <summary>
/// Defines operation audit record service.
/// </summary>
public interface IOperationRecordService
{
    /// <summary>
    /// Records operator action.
    /// </summary>
    Task RecordAsync(string operation, string operatorId, CancellationToken cancellationToken);
}
