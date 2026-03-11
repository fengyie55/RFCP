# RFCP (Robot Flexible Control Platform)

RFCP is a modular industrial-grade robot control platform for flexible manufacturing loading/unloading systems.

## Objectives

- Integrate industrial robots, PLCs, machine vision, conveyors, and factory automation systems.
- Support multi-robot scheduling and deterministic 10 ms real-time control loops.
- Enforce hardware abstraction and plugin-driven driver extension.

## Layered Architecture

1. **Application Layer**: Production and recipe orchestration.
2. **Control Core**: Scheduler, motion abstraction, action pipeline, state control.
3. **Device Abstraction Layer**: `IRobot`, `IPLC`, `IVision`, `IConveyor`, `IIO` interfaces.
4. **Driver Plugin Layer**: Loadable robot/PLC/vision driver implementations.
5. **Hardware Layer**: Physical devices.

## Real-Time Control Loop

Cycle time is fixed at **10 ms** and executes:

1. ReadDeviceState
2. UpdateSystemState
3. ScheduleTasks
4. ExecuteRobotActions
5. WriteDeviceCommands

## Action Pipeline

Default robot task pipeline:

- MoveSafe
- VisionDetect
- MovePrePick
- MovePick
- CloseGripper
- MoveLift
- MovePrePlace
- MovePlace
- OpenGripper

## Factory Automation Interfaces

Skeleton interfaces are included for:

- OPC UA
- REST API
- MQTT
- Modbus TCP

## Build

```bash
dotnet build RFCP.sln
```
