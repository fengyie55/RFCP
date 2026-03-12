# RFCP (Robot Flexible Control Platform)

RFCP is a modular industrial-grade robot control platform for flexible manufacturing loading/unloading systems.

## Objectives

- Integrate industrial robots, PLCs, machine vision, conveyors, and factory automation systems.
- Support multi-robot scheduling and deterministic 10 ms real-time control loops.
- Enforce hardware abstraction and plugin-driven driver extension.

## Layered Architecture

1. **Business Layer (`RFCP.Business`)**: Production/recipe/task orchestration.
2. **Control Core (`RFCP.Core`)**: Scheduler, motion abstraction, action pipeline, state control, deterministic control loop.
3. **Device Abstraction (`RFCP.DeviceAbstraction`)**: `IRobot`, `IPLC`, `IVision`, `IConveyor`, `IIO` contracts.
4. **Platform Layer (`RFCP.Platform`)**: Logging, alarm, configuration, record, and FA protocol integrations.
5. **Plugin Layer (`RFCP.Plugins`)**: Driver plugin contract and dynamic plugin loading.
6. **Driver Layer (`RFCP.Drivers`)**: Vendor-specific robot/PLC/vision drivers as plugin implementations.
7. **GUI Layer (`RFCP.GUI`)**: Operator-facing application shell and presentation composition root.

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

## Solution Projects

- `src/RFCP.DeviceAbstraction.csproj`
- `src/RFCP.Core.csproj`
- `src/RFCP.Platform.csproj`
- `src/RFCP.Plugins.csproj`
- `src/RFCP.Drivers.csproj`
- `src/RFCP.Business.csproj`
- `src/RFCP.GUI.csproj`

## Build

```bash
dotnet build RFCP.sln
```
