# RFCP Project Instructions

This project is an industrial robot control platform.

Technology:
- C#
- .NET
- Industrial automation

Architecture:

core
platform
drivers
plugins
business

Rules:

1. Device drivers must be implemented as plugins
2. Hardware must be abstracted by interfaces
3. Real-time control loop must be deterministic
4. Robot tasks must use an action pipeline
5. All modules must use dependency injection
