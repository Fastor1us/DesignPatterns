namespace Proxy1;

public class SecurityWeatherProxy(UserContext userContext) : IWeatherService
{
    private readonly IWeatherService _service = new WeatherService();

    private void CheckUserAccess()
    {
        if (!userContext.HasAccess)
            throw new UnauthorizedAccessException("Access denied");
    }

    public string GetWeather(string location)
    {
        CheckUserAccess();

        return _service.GetWeather(location);
    }

    public decimal GetTemperature(string location)
    {
        CheckUserAccess();

        return _service.GetTemperature(location);
    }
}

public record UserContext(bool HasAccess);
