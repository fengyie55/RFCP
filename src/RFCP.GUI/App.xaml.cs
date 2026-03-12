using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using RFCP.GUI.Views;

namespace RFCP.GUI;

/// <summary>
/// WPF application entry point.
/// </summary>
public partial class App : Application
{
    private ServiceProvider? _serviceProvider;

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        _serviceProvider = Program.BuildServices();
        var window = _serviceProvider.GetRequiredService<MainWindow>();
        window.Show();
    }
}
