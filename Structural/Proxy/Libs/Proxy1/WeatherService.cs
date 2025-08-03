namespace Proxy1;

public class WeatherService : IWeatherService
{
    public string GetWeather(string location)
    {
        Console.WriteLine($"Requesting weather for {location} from real API..");
        Thread.Sleep(1_000);
        return "Sunny";
    }

    public decimal GetTemperature(string location)
    {
        Console.WriteLine($"Requesting temperature for {location} from real API..");
        Thread.Sleep(1_000);
        return 10.5m;
    }
}
