# Multi-Robot Scheduler

`MultiRobotTaskScheduler` maintains robot-scoped priority queues.

## Scheduling policy

- Higher priority value executes first.
- Tie-breaker is deterministic by task ID.
- Robot IDs isolate workloads per robot.

## Extension points

- Add resource locking for shared fixtures.
- Add deadline-aware scheduling.
- Add dispatch feedback from PLC/vision events.
