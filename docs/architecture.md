# RFCP Architecture

## Layer responsibilities

### Application Layer
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
