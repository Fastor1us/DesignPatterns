namespace Singleton1;

public class LogisticsCompany
{
    private LogisticsCompany()
    {
        CompanyName = "Global Logistics Incorporated";
        ShippingRate = 10.0f;
    }
    private static readonly Lazy<LogisticsCompany>? _instance = new(() => new());
    public static LogisticsCompany Instance => _instance!.Value;

    public string CompanyName { get; }
    public double ShippingRate { get; private set; }

    public void UpdateShippingRate(double newRate)
    {
        ShippingRate = newRate > 0 ? newRate : ShippingRate;
    }

    public double CalculateShippingCost(double distance)
    {
        return ShippingRate * distance;
    }
}
