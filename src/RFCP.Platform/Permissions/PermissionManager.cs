using System.Collections.Concurrent;

namespace RFCP.Platform.Permissions;

/// <summary>
/// Permission manager skeleton with thread-safe in-memory permission map.
/// </summary>
public sealed class PermissionManager : IPermissionManager
{
    private readonly ConcurrentDictionary<string, HashSet<string>> _permissionMap = new();

    /// <inheritdoc />
    public Task<bool> HasPermissionAsync(string userId, string permissionCode, CancellationToken cancellationToken)
    {
        if (!_permissionMap.TryGetValue(userId, out var permissions))
        {
            return Task.FromResult(false);
        }

        lock (permissions)
        {
            return Task.FromResult(permissions.Contains(permissionCode));
        }
    }
}
