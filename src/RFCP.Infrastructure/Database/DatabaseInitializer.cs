using RFCP.Infrastructure.ORM;

namespace RFCP.Infrastructure.Database;

/// <summary>
/// Performs database initialization and schema bootstrapping.
/// </summary>
public sealed class DatabaseInitializer
{
    private readonly RfcpDbContext _dbContext;

    public DatabaseInitializer(RfcpDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task InitializeAsync(CancellationToken cancellationToken)
    {
        return _dbContext.Database.EnsureCreatedAsync(cancellationToken);
    }
}
