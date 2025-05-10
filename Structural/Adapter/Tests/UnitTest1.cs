using Adapter1.Adapters;
using Adapter1.Models;
using Adapter1.Processors;

namespace AdapterTests;

public class UnitTest1
{
    [Fact]
    public void XmlClientCanWorkWithJsonViaAdapter()
    {
        // Arrange
        JsonProcessor<User> jsonProcessor = new();
        var adapter = new JsonToXmlAdapter<User>(jsonProcessor);
        var user = new User(1, "Bob", "bob@example.com");

        // Act
        string xml = adapter.GetXml(user);
        User? parsedUser = adapter.ParseXml(xml);

        // Assert
        Assert.Contains("<Name>Bob</Name>", xml);
        Assert.Equal(user.Email, parsedUser?.Email);
    }

    [Fact]
    public void JsonClientCanWorkWithXmlViaAdapter()
    {
        // Arrange
        XmlProcessor<User> xmlProcessor = new();
        var adapter = new XmlToJsonAdapter<User>(xmlProcessor);
        var user = new User(1, "Bob", "bob@example.com");

        // Act
        string json = adapter.GetJson(user);
        User? parsedUser = adapter.ParseJson(json);

        // Assert
        Assert.Contains("\"Name\":\"Bob\"", json);
        Assert.Equal(user.Id, parsedUser?.Id);
    }
}
