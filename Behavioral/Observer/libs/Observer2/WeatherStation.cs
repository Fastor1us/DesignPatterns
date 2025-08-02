namespace Observer2;

public class WeatherStation : Subject<WeatherDataModel>
{
    public void SetMeasurements(float temperature, float humidity, float pressure)
    {
        NotifyObservers(new(temperature, humidity, pressure));
    }
}
