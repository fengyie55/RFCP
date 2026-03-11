using RFCP.DeviceAbstraction.Interfaces;

namespace RFCP.Core.ActionPipeline;

public interface IRobotAction
{
    string Name { get; }
    Task Execute(ActionContext context, CancellationToken cancellationToken);
}

public sealed class ActionContext(IRobot robot, IVision vision)
{
    public IRobot Robot { get; } = robot;
    public IVision Vision { get; } = vision;
    public Dictionary<string, object> Data { get; } = new();
}

public sealed class RobotActionPipeline(IEnumerable<IRobotAction> actions)
{
    private readonly IReadOnlyList<IRobotAction> _actions = actions.ToList();

    public async Task Run(ActionContext context, CancellationToken cancellationToken)
    {
        foreach (var action in _actions)
        {
            await action.Execute(context, cancellationToken).ConfigureAwait(false);
        }
    }

    public static IReadOnlyList<string> DefaultPipeline =>
    [
        "MoveSafe",
        "VisionDetect",
        "MovePrePick",
        "MovePick",
        "CloseGripper",
        "MoveLift",
        "MovePrePlace",
        "MovePlace",
        "OpenGripper"
    ];
}
