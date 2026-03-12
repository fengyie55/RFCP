using Microsoft.Extensions.DependencyInjection;
using RFCP.Business.DependencyInjection;
using RFCP.Core.DependencyInjection;
using RFCP.GUI.Services;
using RFCP.GUI.ViewModels;
using RFCP.GUI.Views;
using RFCP.Infrastructure.DependencyInjection;

namespace RFCP.GUI;

/// <summary>
/// Configures dependency injection for RFCP GUI startup.
/// </summary>
public static class Program
{
    /// <summary>
    /// Builds service provider for application startup.
    /// </summary>
    public static ServiceProvider BuildServices()
    {
        var services = new ServiceCollection();
        services.AddRfcpInfrastructure();
        services.AddRfcpCoreEngine();
        services.AddRfcpBusiness();

        services.AddSingleton<MainWindowViewModel>();
        services.AddSingleton<UiNavigationService>();
        services.AddSingleton<MainWindow>();

        return services.BuildServiceProvider();
    }
}
