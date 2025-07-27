namespace Singleton2;

public class Singleton
{
    private static readonly Singleton _instance = new();
    private int _counter = 0;
    private readonly object _lock = new object();

    private Singleton() { }

    public static Singleton Instance => _instance;

    public void Increment() => Interlocked.Increment(ref _counter);

    public void Decrement() => Interlocked.Decrement(ref _counter);

    public int GetCounterValue() => Interlocked.CompareExchange(ref _counter, 0, 0);

    public void Reset()
    {
        lock (_lock)
        {
            _counter = 0;
        }
    }

    public void Add(int value)
    {
        lock (_lock)
        {
            _counter += value;
        }
    }
}
