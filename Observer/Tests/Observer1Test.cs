using Observer1.Observers;
using Observer1.Subjects;

namespace Tests;

public class Observer1Tests
{
    [Fact]
    public void NotifiesObservers()
    {
        // Arrange
        var weatherData = new WeatherData();
        var output = new StringWriter();

        using var _ = new CurrentConditionsDisplay(weatherData, output);

        // Act
        weatherData.SetMeasurements(25f, 30f, 40f);

        // Assert
        Assert.Contains("25F degrees", output.ToString());
        Assert.Contains("30% humidity", output.ToString());
    }

    [Fact]
    public void UnsubscribesOnDispose()
    {
        // Arrange
        var weatherData = new WeatherData();
        var display = new CurrentConditionsDisplay(weatherData);

        // Act
        display.Dispose();

        // Assert
        Assert.DoesNotContain(display, weatherData.Observers);
    }
}
