namespace RFCP.Infrastructure.EventBus;

/// <summary>
/// Publish / subscribe event bus abstraction.
/// </summary>
public interface IEventBus
{
    void Publish<TEvent>(TEvent @event);

    IDisposable Subscribe<TEvent>(Action<TEvent> handler);
}
