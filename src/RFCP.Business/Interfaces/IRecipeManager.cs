namespace RFCP.Business.Interfaces;

/// <summary>
/// Defines recipe lifecycle operations for production orchestration.
/// </summary>
public interface IRecipeManager
{
    /// <summary>
    /// Loads the recipe into runtime context.
    /// </summary>
    Task LoadRecipeAsync(string recipeId, CancellationToken cancellationToken);
}
