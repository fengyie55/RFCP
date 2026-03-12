using RFCP.Business.Interfaces;

namespace RFCP.Business.Managers;

/// <summary>
/// Recipe manager skeleton for recipe loading and activation.
/// </summary>
public sealed class RecipeManager : IRecipeManager
{
    /// <inheritdoc />
    public Task LoadRecipeAsync(string recipeId, CancellationToken cancellationToken)
    {
        // TODO: Validate recipe and load process parameters into runtime state.
        return Task.CompletedTask;
    }
}
