namespace RFCP.DeviceAbstraction.Interfaces;

/// <summary>
/// Abstract contract for conveyor control devices.
/// </summary>
public interface IConveyor
{
    string ConveyorId { get; }

    Task StartAsync(CancellationToken cancellationToken);

    Task StopAsync(CancellationToken cancellationToken);
}
