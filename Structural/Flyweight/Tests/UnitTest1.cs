using Flyweight1;

namespace FlyweightTests;

public class UnitTest1
{
    [Fact]
    public void FlyweightFactory_ReturnsSameInstance_ForSameKey()
    {
        // Arrange
        var factory = new FlyweightFactory();

        // Act
        var flyweight1 = factory.GetFlyweight('A');
        var flyweight2 = factory.GetFlyweight('A');

        // Assert
        Assert.Same(flyweight1, flyweight2);
    }

    [Fact]
    public void FlyweightFactory_CreatesNewInstance_OnlyForNewKeys()
    {
        // Arrange
        var factory = new FlyweightFactory();

        // Act
        var flyweightA = factory.GetFlyweight('A');
        var flyweightB = factory.GetFlyweight('B');
        var flyweightA2 = factory.GetFlyweight('A');

        // Assert
        Assert.Equal(2, factory.GetFlyweightsCount());
        Assert.Same(flyweightA, flyweightA2);
        Assert.NotSame(flyweightA, flyweightB);
    }

    [Fact]
    public void CharacterFlyweight_DisplaysCorrectInfo()
    {
        // Arrange
        var flyweight = new CharacterFlyweight('X');
        var output = new StringWriter();
        Console.SetOut(output);

        // Act
        flyweight.Display(10, 20);
        var result = output.ToString();

        // Assert
        Assert.Contains("Symbol: X, Position: (10, 20)", result);
    }
}
