namespace Observer1;

public interface ISubject<T>
{
    void RegisterObserver(IObserver<T> o);
    void RemoveObserver(IObserver<T> o);
    void NotifyObservers();
}

public interface IObserver<T>
{
    void Update(T model);
}
