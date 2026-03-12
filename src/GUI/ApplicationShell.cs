using RFCP.Business.ProductionManager;
using RFCP.Business.RecipeManager;
using RFCP.Business.TaskManager;

namespace RFCP.GUI;

public sealed class ApplicationShell
{
    private readonly ProductionManager _productionManager;
    private readonly RecipeManager _recipeManager;
    private readonly TaskManager _taskManager;

    public ApplicationShell(
        ProductionManager productionManager,
        RecipeManager recipeManager,
        TaskManager taskManager)
    {
        _productionManager = productionManager;
        _recipeManager = recipeManager;
        _taskManager = taskManager;
    }

    public string BuildDashboardSummary() =>
        $"Recipe={_recipeManager.ActiveRecipe ?? "None"}, PendingTask={_taskManager.Next() ?? "None"}, GoodCount={_productionManager.GoodCount}";
}
