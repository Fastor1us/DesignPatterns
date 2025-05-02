namespace AbstractFactory1.Transports;

internal class Ship : ITransport
{
    public string Deliver(string destination)
        => $"Delivery by Ship to {destination}";
}
