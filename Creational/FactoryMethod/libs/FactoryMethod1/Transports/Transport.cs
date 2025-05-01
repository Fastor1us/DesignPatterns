namespace FactoryMethod1.Transports;

public abstract class Transport(string destination, int capacity)
{
    public string Destination { get; } = destination;
    public int Capacity { get; } = capacity;
    public abstract string PlanDeliveryRoute();
}
