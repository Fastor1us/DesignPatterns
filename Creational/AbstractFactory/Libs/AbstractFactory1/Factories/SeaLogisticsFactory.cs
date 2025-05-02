using AbstractFactory1.Cargo;
using AbstractFactory1.Transports;

namespace AbstractFactory1.Factories;

public class SeaLogisticsFactory : ILogisticFactory
{
    public ITransport CreateTransport() => new Ship();
    public ICargo CreateCargo() => new Container();
}
