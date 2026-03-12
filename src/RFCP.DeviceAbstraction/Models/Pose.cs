namespace RFCP.DeviceAbstraction.Models;

/// <summary>
/// Represents a robot tool center point pose in Cartesian space.
/// </summary>
public sealed record Pose(double X, double Y, double Z, double Rx, double Ry, double Rz);
