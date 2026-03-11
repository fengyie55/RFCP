using RFCP.Core.ActionPipeline;

namespace RFCP.Core.RobotExecutor;

public sealed class RobotExecutor(RobotActionPipeline pipeline)
{
    public Task Execute(ActionContext context, CancellationToken cancellationToken = default) =>
        pipeline.Run(context, cancellationToken);
}
