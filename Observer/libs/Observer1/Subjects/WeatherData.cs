using Observer1.Interfaces;
using Observer1.Models;

namespace Observer1.Subjects;

public class WeatherData : ISubject<WeatherDataModel>
{
    private readonly List<Interfaces.IObserver<WeatherDataModel>> _observers = [];
    private float _temperature;
    private float _humidity;
    private float _pressure;

    public void RegisterObserver(Interfaces.IObserver<WeatherDataModel> o) => _observers.Add(o);
    public void RemoveObserver(Interfaces.IObserver<WeatherDataModel> o) => _observers.Remove(o);
    public void NotifyObservers()
    {
        foreach (var observer in _observers)
            observer.Update(new WeatherDataModel(_temperature, _humidity, _pressure));
    }

    public void MeasurementsChanged() => NotifyObservers();

    public void SetMeasurements(float temp, float humidity, float pressure)
    {
        _temperature = temp;
        _humidity = humidity;
        _pressure = pressure;

        MeasurementsChanged();
    }

    public List<Interfaces.IObserver<WeatherDataModel>> Observers { get { return _observers; } }
}
