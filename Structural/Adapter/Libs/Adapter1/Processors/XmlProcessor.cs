using System.Xml.Serialization;

namespace Adapter1.Processors;

public class XmlProcessor<T> : IXmlProcessor<T> where T : class
{
    public string GetXml(T user)
    {
        var serializer = new XmlSerializer(typeof(T));
        using var writer = new StringWriter();
        serializer.Serialize(writer, user);
        return writer.ToString();
    }

    public T? ParseXml(string xml)
    {
        var serializer = new XmlSerializer(typeof(T));
        using var reader = new StringReader(xml);
        var user = serializer.Deserialize(reader);
        return user == null ? null : user as T;
    }
}
