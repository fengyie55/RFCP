namespace RFCP.Infrastructure.FAInterface;

public interface IFactoryAutomationProtocol
{
    string Name { get; }
    Task Publish(string topic, string payload, CancellationToken cancellationToken = default);
}

public sealed class OpcUaInterface : IFactoryAutomationProtocol
{
    public string Name => "OPC UA";
    public Task Publish(string topic, string payload, CancellationToken cancellationToken = default) => Task.CompletedTask;
}

public sealed class RestApiInterface : IFactoryAutomationProtocol
{
    public string Name => "REST API";
    public Task Publish(string topic, string payload, CancellationToken cancellationToken = default) => Task.CompletedTask;
}

public sealed class MqttInterface : IFactoryAutomationProtocol
{
    public string Name => "MQTT";
    public Task Publish(string topic, string payload, CancellationToken cancellationToken = default) => Task.CompletedTask;
}

public sealed class ModbusTcpInterface : IFactoryAutomationProtocol
{
    public string Name => "Modbus TCP";
    public Task Publish(string topic, string payload, CancellationToken cancellationToken = default) => Task.CompletedTask;
}
