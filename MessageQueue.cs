using System.Collections.Concurrent;

public class MessageQueue<T>
{
    private readonly ConcurrentQueue<T> _queue = new();

    public void Enqueue(T item) => _queue.Enqueue(item);

    public bool TryDequeue(out T item) => _queue.TryDequeue(out item);

    public int Count => _queue.Count;
}
