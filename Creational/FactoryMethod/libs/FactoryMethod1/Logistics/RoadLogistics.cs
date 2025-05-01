using FactoryMethod1.Transports;

namespace FactoryMethod1.Logistics;

public class RoadLogistics : Logistics
{
    protected override Transport CreateTransport(string destination, int capacity)
    {
        return new Truck(destination, capacity);
    }
}
