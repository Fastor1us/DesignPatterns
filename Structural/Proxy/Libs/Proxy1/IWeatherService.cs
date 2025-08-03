namespace Proxy1;

public interface IWeatherService
{
    string GetWeather(string location);
    decimal GetTemperature(string location);
}
