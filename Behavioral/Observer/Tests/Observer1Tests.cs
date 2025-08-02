using Observer1;

namespace ObserverTests;

public class Observer1Tests
{
    [Fact]
    public void NotifiesObservers()
    {
        // Arrange
        var subject = new Subject();
        var output = new StringWriter();

        using var _ = new Observer(subject, output);

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
        var subject = new Subject();
        var observer = new Observer(subject);

        // Act
        observer.Dispose();

        // Assert
        Assert.DoesNotContain(observer, subject.Observers);
    }
}
