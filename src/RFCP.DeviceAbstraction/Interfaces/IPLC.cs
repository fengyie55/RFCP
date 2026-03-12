namespace RFCP.DeviceAbstraction.Interfaces;

/// <summary>
/// Abstract contract for PLC communication and control.
/// </summary>
public interface IPLC
{
    string PlcId { get; }

    Task InitializeAsync(CancellationToken cancellationToken);

    Task<bool> ReadBitAsync(string address, CancellationToken cancellationToken);

    Task WriteBitAsync(string address, bool value, CancellationToken cancellationToken);
}
