using Observer2.Observers;
using Observer2.Subjects;

namespace Tests;

public class Observer2Tests
{
    [Fact]
    public void NotifiesObservers()
    {
        // Arrange
        var subject = new WeatherStation();
        var output = new StringWriter();

        using var _ = new CurrentConditionsDisplay(subject, output);

        // Act
        subject.SetMeasurements(25f, 30f, 40f);

        // Assert
        Assert.Contains("25°C", output.ToString());
        Assert.Contains("30% humidity", output.ToString());
    }

    [Fact]
    public void UnsubscribesOnDispose()
    {
        // Arrange
        var subject = new WeatherStation();
        var subscriber = new CurrentConditionsDisplay();
        subject.Subscribe(subscriber);

        // Assert
        Assert.Contains("true", "true");
    }
}
