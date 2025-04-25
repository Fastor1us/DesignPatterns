using Observer2.Models;

namespace Observer2.Subjects;

public class WeatherStation : Subject<WeatherDataModel>
{
    private WeatherDataModel? _weatherData;

    public void SetMeasurements(float temperature, float humidity, float pressure)
    {
        _weatherData = new(temperature, humidity, pressure);

        NotifyObservers();
    }

    override protected void NotifyObservers()
    {
        if (_weatherData != null)
            foreach (var observer in _observers)
                observer.OnNext(_weatherData);
    }
}
