using FactoryMethod1.Logistics;

namespace Tests;

public class LogisticsTests
{

    [Theory]
    [InlineData("Tver", 10)]
    [InlineData("Tambov", 25)]
    public void GetDeliveryRouteByRoad(string destination, int capacity)
    {
        // Arrange
        var logistics = new RoadLogistics();

        // Act
        var result = logistics.GetDeliveryRoute(destination, capacity);

        // Assert
        Assert.Equal($"Delivery by Truck to {destination} with {capacity} tons", result);
    }

    [Theory]
    [InlineData("Tver", 10)]
    [InlineData("Tambov", 25)]
    public void GetDeliveryRouteBySea(string destination, int capacity)
    {
        // Arrange
        var logistics = new SeaLogistics();

        // Act
        var result = logistics.GetDeliveryRoute(destination, capacity);

        // Assert
        Assert.Equal($"Delivery by Ship to {destination} with {capacity} containers", result);
    }
}
