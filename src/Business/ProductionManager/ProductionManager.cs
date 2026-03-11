namespace RFCP.Business.ProductionManager;

public sealed class ProductionManager
{
    public int GoodCount { get; private set; }
    public void MarkGood() => GoodCount++;
}
