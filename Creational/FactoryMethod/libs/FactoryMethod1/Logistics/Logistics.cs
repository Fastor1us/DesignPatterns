using FactoryMethod1.Transports;

namespace FactoryMethod1.Logistics;

public abstract class Logistics
{
    public string GetDeliveryRoute(string destination, int capacity)
    {
        Transport transport = CreateTransport(destination, capacity);
        // any other actions
        return transport.PlanDeliveryRoute();
    }

    protected abstract Transport CreateTransport(string destination, int capacity);
}
