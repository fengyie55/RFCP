using RFCP.DeviceAbstraction.Interfaces;

namespace RFCP.Core.MotionEngine;

public sealed class VisionCoordinateCalibration
{
    public Pose Calibrate(Pose robotReference, Pose visionReference)
    {
        return new Pose(
            visionReference.X - robotReference.X,
            visionReference.Y - robotReference.Y,
            visionReference.Z - robotReference.Z,
            visionReference.Rx - robotReference.Rx,
            visionReference.Ry - robotReference.Ry,
            visionReference.Rz - robotReference.Rz);
    }
}
