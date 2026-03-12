# RFCP Architecture

## Project split overview

The solution is decomposed into dedicated projects to keep dependency flow explicit and maintainable:

- `RFCP.DeviceAbstraction`: hardware-facing contracts (`IRobot`, `IPLC`, `IVision`, etc.).
- `RFCP.Core`: deterministic scheduling, action pipeline, motion engine, and state machine.
- `RFCP.Platform`: cross-cutting platform services (logging, alarm, records, configuration) and factory integration protocols.
- `RFCP.Plugins`: plugin contracts and runtime plugin loader.
- `RFCP.Drivers`: vendor driver implementations that satisfy plugin contracts.
- `RFCP.Business`: recipe/production/task orchestration for manufacturing workflows.
- `RFCP.GUI`: operator-facing shell composition and presentation entry abstractions.

## Dependency direction

To keep architecture clean, projects should follow this direction:

`RFCP.GUI` → `RFCP.Business` → (`RFCP.Core`, `RFCP.Platform`) → `RFCP.DeviceAbstraction`

`RFCP.Drivers` → `RFCP.Plugins`

All runtime hardware access must stay behind interfaces and plugin boundaries.

## Layer responsibilities

### Business Layer
Coordinates recipes, production logic, and task plans for each line or cell.

### Control Core
Provides deterministic execution primitives:
- `MultiRobotTaskScheduler`
- `RobotMotionService`
- `RobotActionPipeline`
- `DeterministicControlLoop`
- `SystemStateMachine`

### Device Abstraction Layer
Defines contracts that isolate hardware-specific details from application logic.

### Driver Plugin Layer
Loads implementations at runtime through `PluginLoader` and `IDeviceDriver`.

### Hardware Layer
Industrial robot controllers, PLC racks, smart cameras, conveyors, and I/O modules.

## Design principles

- Dependency injection between all modules.
- Deterministic loop timing for control stability.
- Plugin extensibility for driver evolution.
- Clear isolation between business logic and hardware commands.
