using Bridge1.Abstraction;
using Bridge1.Implementation;
using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace BridgeTests;

public class UnitTest1
{
    [Fact]
    public void WindowsRenderer_ShouldRenderCorrectMessage()
    {
        // Arrange
        var renderer = new WindowsRenderer();
        var output = new StringWriter();
        Console.SetOut(output);
        var text = "save";

        // Act
        renderer.RenderButton(text);
        var result = output.ToString();

        // Assert
        Assert.Contains($"Windows button: [{text}] (WinAPI)", result);
    }

    [Fact]
    public void LinuxRenderer_ShouldRenderCorrectMessage()
    {
        // Arrange
        var renderer = new LinuxRenderer();
        var output = new StringWriter();
        Console.SetOut(output);
        var isChecked = true;

        // Act
        renderer.RenderCheckbox(isChecked);
        var result = output.ToString();

        // Assert
        Assert.Contains($"Linux checkbox: {(isChecked ? "☑️" : "⬜")} (LinuxAPI)", result);
    }
}
