using System.Windows;
using RFCP.GUI.ViewModels;

namespace RFCP.GUI.Views;

/// <summary>
/// Main HMI shell window for operators.
/// </summary>
public partial class MainWindow : Window
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindow"/> class.
    /// </summary>
    public MainWindow(MainWindowViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
