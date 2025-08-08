using Builder1;

namespace BuilderTests;

public class UnitTest1
{
    [Fact]
    public void BuildStandardHouse_ReturnsCorrectHouse()
    {
        // Arrange
        var builder = new HouseBuilder();
        var director = new HouseDirector(builder);

        // Act
        var house = director.BuildStandardHouse();

        // Assert
        Assert.Equal(4, house.Walls);
        Assert.Equal(2, house.Doors);
        Assert.Equal(6, house.Windows);
        Assert.True(house.HasRoof);
        Assert.False(house.HasGarage);
    }

    [Fact]
    public void Builder_CanBeReusedAfterReset()
    {
        // Arrange
        var builder = new HouseBuilder();

        // Act
        var house1 = builder.BuildWalls(4).GetResult();
        var house2 = builder.BuildWalls(2).GetResult();

        // Assert
        Assert.Equal(4, house1.Walls);
        Assert.Equal(2, house2.Walls);
    }
}
