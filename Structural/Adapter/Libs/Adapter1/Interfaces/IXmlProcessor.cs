namespace Adapter1.Interfaces;

public interface IXmlProcessor<T> where T : class
{
    string GetXml(T data);
    T? ParseXml(string xml);
}
