using FactoryMethod1;

namespace Tests;

public class UnitTest1
{
    [Fact]
    public void GetRoadRoute()
    {
        // Arrange
        Logistics logistics = new RoadLogistics();

        // Act
        string deliveryPlan = logistics.GetDeliveryRoute();

        // Assert
        Assert.Equal("Delivery is going by transporting by Truck", deliveryPlan);
    }

    [Fact]
    public void GetSeaRoute()
    {
        // Arrange
        Logistics logistics = new SeaLogistics();

        // Act
        string deliveryPlan = logistics.GetDeliveryRoute();

        // Assert
        Assert.Equal("Delivery is going by transporting by Ship", deliveryPlan);
    }
}
