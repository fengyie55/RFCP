namespace RFCP.Platform.Permissions;

/// <summary>
/// Defines access control operations.
/// </summary>
public interface IPermissionManager
{
    /// <summary>
    /// Evaluates whether user has specified permission.
    /// </summary>
    Task<bool> HasPermissionAsync(string userId, string permissionCode, CancellationToken cancellationToken);
}
