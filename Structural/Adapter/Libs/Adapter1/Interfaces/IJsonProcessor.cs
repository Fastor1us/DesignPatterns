namespace Adapter1.Interfaces;

public interface IJsonProcessor<T> where T : class
{
    string GetJson(T data);
    T? ParseJson(string json);
}
