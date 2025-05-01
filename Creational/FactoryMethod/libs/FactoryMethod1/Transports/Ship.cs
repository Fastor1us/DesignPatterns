namespace FactoryMethod1.Transports;

internal class Ship(string destination, int capacity) : Transport(destination, capacity)
{
    public override string PlanDeliveryRoute()
    {
        return $"Delivery by Ship to {Destination} with {Capacity} containers";
    }
}
