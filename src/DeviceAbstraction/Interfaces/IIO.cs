namespace RFCP.DeviceAbstraction.Interfaces;

public interface IIO
{
    Task<bool> ReadDigital(string channel, CancellationToken cancellationToken = default);
    Task WriteDigital(string channel, bool value, CancellationToken cancellationToken = default);
}
