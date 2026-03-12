using RFCP.Business.Interfaces;

namespace RFCP.Business.Managers;

/// <summary>
/// Production manager skeleton for production order orchestration.
/// </summary>
public sealed class ProductionManager : IProductionManager
{
    private readonly IRecipeManager _recipeManager;

    /// <summary>
    /// Initializes a new instance of the <see cref="ProductionManager"/> class.
    /// </summary>
    public ProductionManager(IRecipeManager recipeManager)
    {
        _recipeManager = recipeManager;
    }

    /// <inheritdoc />
    public async Task StartProductionAsync(string orderId, CancellationToken cancellationToken)
    {
        // TODO: Resolve recipe from order and coordinate startup sequence.
        await _recipeManager.LoadRecipeAsync(orderId, cancellationToken);
    }
}
