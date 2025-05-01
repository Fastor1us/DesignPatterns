using FactoryMethod1.Transports;

namespace FactoryMethod1.Logistics;

public class SeaLogistics : Logistics
{
    protected override Transport CreateTransport(string destination, int capacity)
    {
        return new Ship(destination, capacity);
    }
}
