namespace FactoryMethod1;

internal class Truck : ITransport
{
    public string PlanDeliveryRoute()
    {
        return "Delivery is going by transporting by Truck";
    }
}
