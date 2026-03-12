namespace RFCP.Platform.Records;

/// <summary>
/// Operation record service skeleton.
/// </summary>
public sealed class OperationRecordService : IOperationRecordService
{
    /// <inheritdoc />
    public Task RecordAsync(string operation, string operatorId, CancellationToken cancellationToken)
    {
        // TODO: Persist operation record to database.
        return Task.CompletedTask;
    }
}
