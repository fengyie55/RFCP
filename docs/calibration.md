# Vision Coordinate Calibration

`VisionCoordinateCalibration` provides a baseline coordinate transform skeleton between robot and vision frames.

## Current approach

- Uses reference delta between robot frame and vision frame.
- Returns calibrated offset `Pose` for downstream motion planning.

## Future improvements

- Multi-point fitting (least squares).
- Hand-eye calibration matrix solving.
- Distortion compensation and uncertainty scoring.
