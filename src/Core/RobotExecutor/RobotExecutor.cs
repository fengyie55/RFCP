using RFCP.Core.ActionPipeline;

namespace RFCP.Core.RobotExecutor;

public sealed class RobotExecutor
{
    private readonly RobotActionPipeline _pipeline;

    public RobotExecutor(RobotActionPipeline pipeline)
    {
        _pipeline = pipeline;
    }

    public Task Execute(ActionContext context, CancellationToken cancellationToken = default) =>
        _pipeline.Run(context, cancellationToken);
}
