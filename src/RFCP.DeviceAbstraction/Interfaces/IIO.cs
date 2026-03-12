namespace RFCP.DeviceAbstraction.Interfaces;

/// <summary>
/// Abstract contract for generic digital/analog I/O access.
/// </summary>
public interface IIO
{
    Task<double> ReadAnalogAsync(string channel, CancellationToken cancellationToken);

    Task WriteAnalogAsync(string channel, double value, CancellationToken cancellationToken);
}
