using Microsoft.EntityFrameworkCore;

namespace RFCP.Infrastructure.ORM;

/// <summary>
/// Entity Framework Core database context for RFCP persistence.
/// </summary>
public sealed class RfcpDbContext : DbContext
{
    public RfcpDbContext(DbContextOptions<RfcpDbContext> options)
        : base(options)
    {
    }

    public DbSet<ProductionRecord> ProductionRecords => Set<ProductionRecord>();

    public DbSet<OperationRecord> OperationRecords => Set<OperationRecord>();

    public DbSet<AlarmRecord> AlarmRecords => Set<AlarmRecord>();

    public DbSet<User> Users => Set<User>();

    public DbSet<Permission> Permissions => Set<Permission>();
}
