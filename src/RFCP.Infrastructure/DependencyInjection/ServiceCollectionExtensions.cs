using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RFCP.Infrastructure.Database;
using RFCP.Infrastructure.EventBus;
using RFCP.Infrastructure.ORM;
using RFCP.Infrastructure.PluginLoader;
using RFCP.Platform.DependencyInjection;
using RFCP.Runtime.MemoryStateStore;
using RFCP.Runtime.RuntimeServices;

namespace RFCP.Infrastructure.DependencyInjection;

/// <summary>
/// Registers RFCP infrastructure services including event bus, plugin loading, and EF Core context.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds infrastructure and shared platform/runtime services.
    /// </summary>
    public static IServiceCollection AddRfcpInfrastructure(this IServiceCollection services)
    {
        services.AddRfcpPlatformServices();
        services.AddDbContext<RfcpDbContext>(options => options.UseInMemoryDatabase("rfcp"));
        services.AddSingleton<IEventBus, InMemoryEventBus>();
        services.AddSingleton<IPluginLoader, RFCP.Infrastructure.PluginLoader.PluginLoader>();
        services.AddSingleton<MemoryStateStore>();
        services.AddSingleton<RuntimeStateService>();
        services.AddScoped<DatabaseInitializer>();
        return services;
    }

    /// <summary>
    /// Backward-compatible alias for previous registration method.
    /// </summary>
    public static IServiceCollection AddRfcpPlatform(this IServiceCollection services)
    {
        return services.AddRfcpInfrastructure();
    }
}
