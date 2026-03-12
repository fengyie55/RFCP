namespace RFCP.Business.Interfaces;

/// <summary>
/// Defines equipment registration and state operations.
/// </summary>
public interface IEquipmentManager
{
    /// <summary>
    /// Registers an equipment asset into business context.
    /// </summary>
    Task RegisterEquipmentAsync(string equipmentId, CancellationToken cancellationToken);
}
