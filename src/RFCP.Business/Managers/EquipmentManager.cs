using System.Collections.Concurrent;
using RFCP.Business.Interfaces;

namespace RFCP.Business.Managers;

/// <summary>
/// Equipment manager skeleton with thread-safe registration state.
/// </summary>
public sealed class EquipmentManager : IEquipmentManager
{
    private readonly ConcurrentDictionary<string, byte> _equipment = new();

    /// <inheritdoc />
    public Task RegisterEquipmentAsync(string equipmentId, CancellationToken cancellationToken)
    {
        _equipment.TryAdd(equipmentId, 0);
        // TODO: Persist equipment metadata and synchronize with platform services.
        return Task.CompletedTask;
    }
}
