using AbstractFactory1.Cargo;
using AbstractFactory1.Transports;

namespace AbstractFactory1.Factories;

public interface ILogisticFactory
{
    ITransport CreateTransport();
    ICargo CreateCargo();
}
