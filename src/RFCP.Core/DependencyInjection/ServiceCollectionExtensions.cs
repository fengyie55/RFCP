using Microsoft.Extensions.DependencyInjection;
using RFCP.Core.Motion;
using RFCP.Core.Pipeline;
using RFCP.Core.Scheduler;

namespace RFCP.Core.DependencyInjection;

/// <summary>
/// Registers RFCP core engine services for dependency injection.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds core motion, pipeline, and scheduler services.
    /// </summary>
    public static IServiceCollection AddRfcpCoreEngine(this IServiceCollection services)
    {
        services.AddSingleton<IRobotMotionService, RobotMotionService>();
        services.AddSingleton<IRobotActionPipeline, RobotActionPipeline>();
        services.AddSingleton<TaskQueue>();
        services.AddSingleton<ResourceManager>();
        services.AddSingleton<IMultiRobotTaskScheduler, MultiRobotTaskScheduler>();

        return services;
    }
}
