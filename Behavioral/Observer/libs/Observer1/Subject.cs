namespace Observer1;

public class Subject : ISubject<WeatherDataModel>
{
    private readonly List<IObserver<WeatherDataModel>> _observers = [];
    private WeatherDataModel? _weatherData;

    public void RegisterObserver(IObserver<WeatherDataModel> o) => _observers.Add(o);
    public void RemoveObserver(IObserver<WeatherDataModel> o) => _observers.Remove(o);
    public void NotifyObservers()
    {
        if (_weatherData != null)
            foreach (var observer in _observers)
                observer.Update(_weatherData!);
    }

    public void SetMeasurements(float temp, float humidity, float pressure)
    {
        _weatherData = new(temp, humidity, pressure);

        NotifyObservers();
    }

    public List<IObserver<WeatherDataModel>> Observers { get { return _observers; } }
}
