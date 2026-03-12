using RFCP.Business.Interfaces;
using RFCP.Business.Models;
using RFCP.GUI.MVVM;
using RFCP.Platform.Logging;

namespace RFCP.GUI.ViewModels;

/// <summary>
/// Main window view model for operator-level commands and status.
/// </summary>
public sealed class MainWindowViewModel : ViewModelBase
{
    private readonly ITaskManager _taskManager;
    private readonly ILogService _logService;
    private string _status = "Ready";

    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
    /// </summary>
    public MainWindowViewModel(ITaskManager taskManager, ILogService logService)
    {
        _taskManager = taskManager;
        _logService = logService;
        StartSampleTaskCommand = new RelayCommand(async _ => await StartSampleTaskAsync(), _ => true);
    }

    /// <summary>
    /// Gets current UI status text.
    /// </summary>
    public string Status
    {
        get => _status;
        set => SetProperty(ref _status, value);
    }

    /// <summary>
    /// Gets command to submit a sample task to business/core layers.
    /// </summary>
    public RelayCommand StartSampleTaskCommand { get; }

    #region Command Handlers

    private async Task StartSampleTaskAsync()
    {
        var request = new BusinessTaskRequest
        {
            RobotId = "SIM-ROBOT",
            OperationType = "PickPlaceCycle",
            RequiredResources = new[] { "RobotZone-A", "Conveyor-1" }
        };

        // TODO: Replace hard-coded request with operator-selected recipe and task inputs.
        await _taskManager.SubmitTaskAsync(request, CancellationToken.None);
        _logService.Info($"Submitted sample task {request.RequestId}.");
        Status = $"Task {request.RequestId} submitted.";
    }

    #endregion
}
