using Observer2.Observers;
using Observer2.Subjects;

namespace ObserverTests;

public class Observer2Tests
{
    [Fact]
    public void NotifiesObservers()
    {
        // Arrange
        var subject = new WeatherStation();
        var output = new StringWriter();
        var observer = new CurrentConditionsDisplay(output);

        using var _ = subject.Subscribe(observer);

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
        var observer = new CurrentConditionsDisplay();

        // Act
        using (subject.Subscribe(observer))
        {
        }

        // Assert
        Assert.DoesNotContain(observer, subject.GetObservers());
    }
}
