using Adapter1.Interfaces;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Adapter1.Processors;

public class JsonProcessor<T> : IJsonProcessor<T> where T : class
{
    readonly JsonSerializerOptions _options = new()
    {
        NumberHandling = JsonNumberHandling.AllowReadingFromString
    };

    public string GetJson(T user)
    {
        return JsonSerializer.Serialize(user);
    }

    public T? ParseJson(string json)
    {
        return JsonSerializer.Deserialize<T>(json, _options);
    }
}
