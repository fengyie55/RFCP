namespace RFCP.DeviceAbstraction.Interfaces;

public interface IRobot
{
    Task Connect(CancellationToken cancellationToken = default);
    Task MoveJ(double[] jointTargets, double speedRatio, CancellationToken cancellationToken = default);
    Task MoveL(Pose targetPose, double speedRatio, CancellationToken cancellationToken = default);
    Task Stop(CancellationToken cancellationToken = default);
    Task<Pose> GetPose(CancellationToken cancellationToken = default);
}
