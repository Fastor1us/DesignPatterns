namespace Observer2.Subjects;

public abstract class Subject<T> : IDisposable where T : class
{
    protected readonly List<IObserver<T>> _observers = [];

    public void Subscribe(IObserver<T> observer)
    {
        if (!_observers.Contains(observer))
            _observers.Add(observer);
    }

    public void Unsubscribe(IObserver<T> observer)
    {
        if (_observers.Contains(observer))
            _observers.Remove(observer);
    }

    abstract protected void NotifyObservers();

    public void Dispose()
    {
        foreach (var observer in _observers)
            observer.OnCompleted();
    }
}
