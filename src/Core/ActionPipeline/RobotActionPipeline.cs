using RFCP.DeviceAbstraction.Interfaces;

namespace RFCP.Core.ActionPipeline;

public interface IRobotAction
{
    string Name { get; }
    Task Execute(ActionContext context, CancellationToken cancellationToken);
}

public sealed class ActionContext
{
    public ActionContext(IRobot robot, IVision vision)
    {
        Robot = robot;
        Vision = vision;
    }

    public IRobot Robot { get; }
    public IVision Vision { get; }
    public Dictionary<string, object> Data { get; } = new();
}

public sealed class RobotActionPipeline
{
    private readonly IReadOnlyList<IRobotAction> _actions;

    public RobotActionPipeline(IEnumerable<IRobotAction> actions)
    {
        _actions = actions.ToList();
    }

    public async Task Run(ActionContext context, CancellationToken cancellationToken)
    {
        foreach (var action in _actions)
        {
            await action.Execute(context, cancellationToken).ConfigureAwait(false);
        }
    }

    public static IReadOnlyList<string> DefaultPipeline =>
    new[]
    {
        "MoveSafe",
        "VisionDetect",
        "MovePrePick",
        "MovePick",
        "CloseGripper",
        "MoveLift",
        "MovePrePlace",
        "MovePlace",
        "OpenGripper"
    };
}
