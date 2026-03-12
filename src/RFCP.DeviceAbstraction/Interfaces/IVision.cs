namespace RFCP.DeviceAbstraction.Interfaces;

/// <summary>
/// Abstract contract for machine vision subsystems.
/// </summary>
public interface IVision
{
    string VisionId { get; }

    Task InitializeAsync(CancellationToken cancellationToken);

    Task<string> AcquireResultAsync(string recipeId, CancellationToken cancellationToken);
}
