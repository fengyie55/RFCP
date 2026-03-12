namespace RFCP.Platform.Records;

/// <summary>
/// Processing record service skeleton.
/// </summary>
public sealed class ProcessingRecordService : IProcessingRecordService
{
    /// <inheritdoc />
    public Task RecordAsync(string recordId, CancellationToken cancellationToken)
    {
        // TODO: Persist processing record to database.
        return Task.CompletedTask;
    }
}
