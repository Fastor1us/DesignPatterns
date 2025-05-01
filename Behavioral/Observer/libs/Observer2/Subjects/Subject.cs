namespace Observer2.Subjects;

public abstract class Subject<T> : IObservable<T>
{
    protected readonly List<IObserver<T>> _observers = [];
    private readonly object _lock = new();

    public IDisposable Subscribe(IObserver<T> observer)
    {
        lock (_lock)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
        }
        return new Unsubscriber(this, observer);
    }

    public void Unsubscribe(IObserver<T> observer)
    {
        lock (_lock)
        {
            _observers.Remove(observer);
        }
    }

    public void NotifyObservers(T data)
    {
        lock (_lock)
        {
            foreach (var observer in _observers)
            {
                observer.OnNext(data);
            }
        }
    }

    public IReadOnlyList<IObserver<T>> GetObservers()
    {
        lock (_lock)
        {
            return _observers.ToList().AsReadOnly();
        }
    }

    private class Unsubscriber(Subject<T> subject, IObserver<T> observer) : IDisposable
    {
        public void Dispose()
        {
            subject.Unsubscribe(observer);
        }
    }
}
