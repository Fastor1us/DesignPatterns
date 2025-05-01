using Decorator1;

namespace Tests;

public class UnitTest1
{
    [Fact]
    public void Write_ShouldConvertTextToUpperCase()
    {
        // Arrange
        var memoryStream = new MemoryStream();
        var streamWriter = new StreamWriter(memoryStream);
        var upperWriter = new UpperCaseTextWriter(streamWriter);

        // Act
        upperWriter.Write("hello");
        upperWriter.Flush();

        // Assert
        memoryStream.Position = 0;
        var reader = new StreamReader(memoryStream);
        string result = reader.ReadToEnd();
        Assert.Equal("HELLO", result);
    }

    [Fact]
    public void Write_ShouldConvertTextToLowerCase()
    {
        // Arrange
        var memoryStream = new MemoryStream();
        var streamWriter = new StreamWriter(memoryStream);
        var lowerWriter = new LowerCaseTextWriter(streamWriter);

        // Act
        lowerWriter.Write("HELLO");
        lowerWriter.Flush();

        // Assert
        memoryStream.Position = 0;
        var reader = new StreamReader(memoryStream);
        string result = reader.ReadToEnd();
        Assert.Equal("hello", result);
    }
}