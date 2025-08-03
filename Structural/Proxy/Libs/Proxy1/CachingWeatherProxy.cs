using Microsoft.Extensions.Caching.Memory;

namespace Proxy1;

public class CachingWeatherProxy : IWeatherService
{
    private readonly IMemoryCache _cache = new MemoryCache(new MemoryCacheOptions());
    private readonly IWeatherService _service = new WeatherService();
    private readonly TimeSpan _cacheTtl = TimeSpan.FromMinutes(5);

    public string GetWeather(string location)
    {
        if (_cache.Get(location + "_weather") is string cachedWeather)
            return cachedWeather;

        var result = _service.GetWeather(location);
        _cache.Set(location + "_weather", result, DateTimeOffset.Now.Add(_cacheTtl));
        return result;
    }

    public decimal GetTemperature(string location)
    {
        if (_cache.Get(location + "_temp") is decimal cachedTemp)
            return cachedTemp;

        var result = _service.GetTemperature(location);
        _cache.Set(location + "_temp", result, DateTimeOffset.Now.Add(_cacheTtl));
        return result;
    }
}
