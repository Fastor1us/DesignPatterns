namespace ChainOfResponsibility1.Handlers;

public class UsePromoCodeHandler : HandlerBase<IOrder>
{
    private static readonly Dictionary<string, double> _promoCodes = new()
    {
        ["SALE_10"] = 0.9d,
        ["SALE_20"] = 0.8d
    };

    public override void Handle(IOrder order)
    {
        if (!string.IsNullOrEmpty(order.PromoCode) &&
            _promoCodes.TryGetValue(order.PromoCode, out var discount))
        {
            Console.WriteLine($"Used promo-code: \"{order.PromoCode}\". Discount: {discount:P0}");
        }

        Console.WriteLine("UsePromoCodeHandler: Done");
        base.Handle(order);
    }
}
