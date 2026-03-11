namespace RFCP.DeviceAbstraction.Interfaces;

public sealed record Pose(double X, double Y, double Z, double Rx, double Ry, double Rz);

public sealed record CameraFrame(DateTime Timestamp, byte[] Data);

public sealed record DetectionResult(bool Success, Pose? ObjectPose, double Confidence);
