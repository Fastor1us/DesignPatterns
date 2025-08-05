namespace ChainOfResponsibility1.Handlers;

public class CheckUserBalanceHandler : HandlerBase<IOrder>
{
    private static readonly Dictionary<string, (int, int)> _availableItems = new()
    {
        ["mobile-phone"] = (10_000, 5),
        ["laptop"] = (35_000, 2),
        ["usb-flash-drive"] = (0_500, 7),
        ["smart-watch"] = (5_000, 3)
    };

    public override void Handle(IOrder order)
    {
        var total = order.Basket.Sum(item => _availableItems[item.Key].Item1 * item.Value);

        if (order.User.cash < total)
            throw new Exception($"User \"{order.User.id}\" has not enough cash");

        Console.WriteLine("CheckUserBalanceHandler: Done");
        base.Handle(order);
    }
}
