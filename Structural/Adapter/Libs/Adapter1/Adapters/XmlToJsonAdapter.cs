using Adapter1.Interfaces;
using System.Xml.Linq;
using System.Text.Json;

namespace Adapter1.Adapters;

public class XmlToJsonAdapter<T>(IXmlProcessor<T> xmlProcessor) : IJsonProcessor<T> where T : class
{
    public string GetJson(T user)
    {
        string xml = xmlProcessor.GetXml(user);

        XDocument xdoc = XDocument.Parse(xml);
        var elements = xdoc.Root.Elements()
            .ToDictionary(e => e.Name.LocalName, e => e.Value);

        return JsonSerializer.Serialize(elements);
    }

    public T? ParseJson(string json)
    {
        var dict = JsonSerializer.Deserialize<Dictionary<string, string>>(json);

        XElement xml = new(typeof(T).Name);
        foreach (var kv in dict)
        {
            xml.Add(new XElement(kv.Key, kv.Value));
        }

        return xmlProcessor.ParseXml(xml.ToString());
    }
}
