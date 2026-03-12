using RFCP.Core.RobotExecutor;
using RFCP.Core.Scheduler;
using RFCP.Core.StateMachine;

namespace RFCP.Core;

public sealed class DeterministicControlLoop
{
    private readonly IMultiRobotTaskScheduler _scheduler;
    private readonly RobotExecutor _executor;
    private readonly SystemStateMachine _stateMachine;

    public DeterministicControlLoop(
        IMultiRobotTaskScheduler scheduler,
        RobotExecutor executor,
        SystemStateMachine stateMachine)
    {
        _scheduler = scheduler;
        _executor = executor;
        _stateMachine = stateMachine;
    }

    private static readonly TimeSpan CycleTime = TimeSpan.FromMilliseconds(10);

    public async Task Run(string robotId, CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            var cycleStart = DateTime.UtcNow;

            ReadDeviceState();
            UpdateSystemState(_stateMachine);
            await ScheduleTasks(_scheduler, robotId, cancellationToken).ConfigureAwait(false);
            await ExecuteRobotActions(_executor, cancellationToken).ConfigureAwait(false);
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
    private static async Task ScheduleTasks(IMultiRobotTaskScheduler scheduler, string robotId, CancellationToken ct)
    {
        await scheduler.DequeueNext(robotId, ct).ConfigureAwait(false);
    }
    private static Task ExecuteRobotActions(RobotExecutor executor, CancellationToken ct) => Task.CompletedTask;
    private static void WriteDeviceCommands() { }
}
