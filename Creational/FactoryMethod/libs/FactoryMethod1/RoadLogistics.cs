namespace FactoryMethod1;

public class RoadLogistics : Logistics
{
    protected override ITransport CreateTransport()
    {
        return new Truck();
    }
}
