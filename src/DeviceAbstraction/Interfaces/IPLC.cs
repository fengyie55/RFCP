namespace RFCP.DeviceAbstraction.Interfaces;

public interface IPLC
{
    Task<object?> Read(string address, CancellationToken cancellationToken = default);
    Task Write(string address, object value, CancellationToken cancellationToken = default);
}
