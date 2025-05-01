namespace FactoryMethod1.Transports;

internal class Truck(string destination, int capacity) : Transport(destination, capacity)
{
    public override string PlanDeliveryRoute()
    {
        return $"Delivery by Truck to {Destination} with {Capacity} tons";
    }
}
