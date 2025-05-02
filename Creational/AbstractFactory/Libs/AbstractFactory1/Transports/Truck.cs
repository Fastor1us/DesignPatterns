namespace AbstractFactory1.Transports;

internal class Truck : ITransport
{
    public string Deliver(string destination)
        => $"Delivery by Truck to {destination}";
}
