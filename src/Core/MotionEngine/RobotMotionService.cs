using RFCP.DeviceAbstraction.Interfaces;

namespace RFCP.Core.MotionEngine;

public interface IRobotMotionService
{
    Task MoveJoint(IRobot robot, double[] joints, double speedRatio, CancellationToken cancellationToken = default);
    Task MoveLinear(IRobot robot, Pose pose, double speedRatio, CancellationToken cancellationToken = default);
}

public sealed class RobotMotionService : IRobotMotionService
{
    public Task MoveJoint(IRobot robot, double[] joints, double speedRatio, CancellationToken cancellationToken = default) =>
        robot.MoveJ(joints, speedRatio, cancellationToken);

    public Task MoveLinear(IRobot robot, Pose pose, double speedRatio, CancellationToken cancellationToken = default) =>
        robot.MoveL(pose, speedRatio, cancellationToken);
}
