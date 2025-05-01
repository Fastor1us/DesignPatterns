namespace FactoryMethod1;

internal class Ship : ITransport
{
    public string PlanDeliveryRoute()
    {
        return "Delivery is going by transporting by Ship";
    }
}
