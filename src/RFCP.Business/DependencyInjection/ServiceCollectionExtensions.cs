using Microsoft.Extensions.DependencyInjection;
using RFCP.Business.Interfaces;
using RFCP.Business.Managers;

namespace RFCP.Business.DependencyInjection;

/// <summary>
/// Registers business layer services.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds business managers and interfaces to DI.
    /// </summary>
    public static IServiceCollection AddRfcpBusiness(this IServiceCollection services)
    {
        services.AddSingleton<IRecipeManager, RecipeManager>();
        services.AddSingleton<IProductionManager, ProductionManager>();
        services.AddSingleton<ITaskManager, TaskManager>();
        services.AddSingleton<IEquipmentManager, EquipmentManager>();
        return services;
    }
}
