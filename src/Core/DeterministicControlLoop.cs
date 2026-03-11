using RFCP.Core.RobotExecutor;
using RFCP.Core.Scheduler;
using RFCP.Core.StateMachine;

namespace RFCP.Core;

public sealed class DeterministicControlLoop(
    IMultiRobotTaskScheduler scheduler,
    RobotExecutor executor,
    SystemStateMachine stateMachine)
{
    private static readonly TimeSpan CycleTime = TimeSpan.FromMilliseconds(10);

    public async Task Run(string robotId, CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            var cycleStart = DateTime.UtcNow;

            ReadDeviceState();
            UpdateSystemState(stateMachine);
            await ScheduleTasks(scheduler, robotId, cancellationToken).ConfigureAwait(false);
            await ExecuteRobotActions(executor, cancellationToken).ConfigureAwait(false);
            WriteDeviceCommands();

            var elapsed = DateTime.UtcNow - cycleStart;
            var wait = CycleTime - elapsed;
            if (wait > TimeSpan.Zero)
            {
                await Task.Delay(wait, cancellationToken).ConfigureAwait(false);
            }
        }
    }

    private static void ReadDeviceState() { }
    private static void UpdateSystemState(SystemStateMachine machine) { }
    private static Task ScheduleTasks(IMultiRobotTaskScheduler scheduler, string robotId, CancellationToken ct) => scheduler.DequeueNext(robotId, ct);
    private static Task ExecuteRobotActions(RobotExecutor executor, CancellationToken ct) => Task.CompletedTask;
    private static void WriteDeviceCommands() { }
}
