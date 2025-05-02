using AbstractFactory1.Factories;

namespace AbstractFactoryTests;

public class UnitTest1
{
    [Theory]
    [InlineData("Tver")]
    [InlineData("Tambov")]
    public void GetCargoTypeAndTransportRouteByRoad(string destination)
    {
        // Arrange
        var factory = new RoadLogisticsFactory();

        // Act
        var cargo = factory.CreateCargo();
        var transport = factory.CreateTransport();

        // Assert
        Assert.Equal("Land container (truck)", cargo.GetCargoType());
        Assert.Equal($"Delivery by Truck to {destination}", transport.Deliver(destination));
    }

    [Theory]
    [InlineData("Tver")]
    [InlineData("Tambov")]
    public void GetCargoTypeAndTransportRouteBySea(string destination)
    {
        // Arrange
        var factory = new SeaLogisticsFactory();

        // Act
        var cargo = factory.CreateCargo();
        var transport = factory.CreateTransport();

        // Assert
        Assert.Equal("Marine 20-foot container", cargo.GetCargoType());
        Assert.Equal($"Delivery by Ship to {destination}", transport.Deliver(destination));
    }
}