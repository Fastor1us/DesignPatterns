using Adapter1.Interfaces;
using System.Text.Json;
using System.Xml.Linq;

namespace Adapter1.Adapters;

/// <summary>
/// Adapter that converts between JSON and XML formats for simple objects.
/// Note: This implementation works only with flat objects (no nested objects or collections).
/// For complex objects use custom serialization/deserialization logic.
/// </summary>
/// <typeparam name="T">Type of object to process (must be a class)</typeparam>
/// <remarks>
/// This is a simplified educational implementation that:
/// 1) Converts each JSON property to XML element. 
/// 2) Presumes all values can be safely converted to strings. 
/// 3) Doesn't handle nested objects or arrays
/// </remarks>
public class JsonToXmlAdapter<T>(IJsonProcessor<T> jsonProcessor) : IXmlProcessor<T> where T : class
{
    public string GetXml(T user)
    {
        string json = jsonProcessor.GetJson(user);

        using JsonDocument doc = JsonDocument.Parse(json);
        XElement xml = new(typeof(T).Name);

        foreach (JsonProperty prop in doc.RootElement.EnumerateObject())
        {
            xml.Add(new XElement(prop.Name, prop.Value.ToString()));
        }

        return xml.ToString();
    }

    public T? ParseXml(string xml)
    {
        XDocument xdoc = XDocument.Parse(xml);
        var elements = xdoc.Root.Elements()
            .ToDictionary(e => e.Name.LocalName, e => e.Value);

        string json = JsonSerializer.Serialize(elements);

        return jsonProcessor.ParseJson(json);
    }
}
