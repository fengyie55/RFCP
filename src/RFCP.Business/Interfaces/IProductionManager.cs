namespace RFCP.Business.Interfaces;

/// <summary>
/// Defines production order orchestration capabilities.
/// </summary>
public interface IProductionManager
{
    /// <summary>
    /// Starts production flow for an order.
    /// </summary>
    Task StartProductionAsync(string orderId, CancellationToken cancellationToken);
}
