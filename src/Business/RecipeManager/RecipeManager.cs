namespace RFCP.Business.RecipeManager;

public sealed class RecipeManager
{
    public string? ActiveRecipe { get; private set; }
    public void Load(string recipeName) => ActiveRecipe = recipeName;
}
