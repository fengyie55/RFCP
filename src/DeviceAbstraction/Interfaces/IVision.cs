namespace RFCP.DeviceAbstraction.Interfaces;

public interface IVision
{
    Task<CameraFrame> Capture(CancellationToken cancellationToken = default);
    Task<DetectionResult> DetectObject(CameraFrame frame, CancellationToken cancellationToken = default);
}
