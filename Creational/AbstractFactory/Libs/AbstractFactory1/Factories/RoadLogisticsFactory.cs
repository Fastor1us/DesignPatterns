using AbstractFactory1.Cargo;
using AbstractFactory1.Transports;

namespace AbstractFactory1.Factories;

public class RoadLogisticsFactory : ILogisticFactory
{
    public ITransport CreateTransport() => new Truck();
    public ICargo CreateCargo() => new BoxTruck();
}
