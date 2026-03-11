namespace RFCP.Business.TaskManager;

public sealed class TaskManager
{
    private readonly Queue<string> _tasks = new();

    public void Add(string task) => _tasks.Enqueue(task);
    public string? Next() => _tasks.Count > 0 ? _tasks.Dequeue() : null;
}
