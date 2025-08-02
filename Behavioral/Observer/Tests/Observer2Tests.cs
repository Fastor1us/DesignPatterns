using Observer2;

namespace ObserverTests;

public class Observer2Tests
{
    [Fact]
    public void NotifiesObservers()
    {
        // Arrange
        var subject = new WeatherStation();
        var output = new StringWriter();
        var observer = new Observer(output);

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
        var observer = new Observer();

        // Act
        using (subject.Subscribe(observer))
        {
        }

        // Assert
        Assert.DoesNotContain(observer, subject.GetObservers());
    }
}
