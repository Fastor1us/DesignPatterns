using Observer1.Interfaces;
using Observer1.Models;

namespace Observer1.Subjects;

public class WeatherData : ISubject<WeatherDataModel>
{
    private readonly List<Interfaces.IObserver<WeatherDataModel>> _observers = [];
    private WeatherDataModel? _weatherData;

    public void RegisterObserver(Interfaces.IObserver<WeatherDataModel> o) => _observers.Add(o);
    public void RemoveObserver(Interfaces.IObserver<WeatherDataModel> o) => _observers.Remove(o);
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

    public List<Interfaces.IObserver<WeatherDataModel>> Observers { get { return _observers; } }
}
