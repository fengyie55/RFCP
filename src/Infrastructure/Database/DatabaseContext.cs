namespace RFCP.Infrastructure.Database;

public sealed class DatabaseContext
{
    public Task SaveChanges(CancellationToken cancellationToken = default) => Task.CompletedTask;
}
