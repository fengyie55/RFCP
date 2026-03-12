namespace RFCP.Infrastructure.ORM;

/// <summary>
/// Production record entity.
/// </summary>
public sealed class ProductionRecord
{
    public Guid Id { get; set; }
    public string OrderId { get; set; } = string.Empty;
    public DateTime StartedAtUtc { get; set; }
    public DateTime? CompletedAtUtc { get; set; }
}

/// <summary>
/// Operation record entity.
/// </summary>
public sealed class OperationRecord
{
    public Guid Id { get; set; }
    public string OperatorId { get; set; } = string.Empty;
    public string OperationCode { get; set; } = string.Empty;
    public DateTime TimestampUtc { get; set; }
}

/// <summary>
/// Alarm record entity.
/// </summary>
public sealed class AlarmRecord
{
    public Guid Id { get; set; }
    public string AlarmCode { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public DateTime RaisedAtUtc { get; set; }
}

/// <summary>
/// User entity.
/// </summary>
public sealed class User
{
    public Guid Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public ICollection<Permission> Permissions { get; set; } = new List<Permission>();
}

/// <summary>
/// Permission entity.
/// </summary>
public sealed class Permission
{
    public Guid Id { get; set; }
    public string Code { get; set; } = string.Empty;
}
