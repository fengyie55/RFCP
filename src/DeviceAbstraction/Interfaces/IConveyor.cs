namespace RFCP.DeviceAbstraction.Interfaces;

public interface IConveyor
{
    Task Start(CancellationToken cancellationToken = default);
    Task Stop(CancellationToken cancellationToken = default);
    Task<double> GetSpeed(CancellationToken cancellationToken = default);
}
