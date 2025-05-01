namespace FactoryMethod1;

public abstract class Logistics
{
    public string GetDeliveryRoute()
    {
        ITransport transport = CreateTransport();
        // any other actions
        return transport.PlanDeliveryRoute();
    }

    protected abstract ITransport CreateTransport();
}
