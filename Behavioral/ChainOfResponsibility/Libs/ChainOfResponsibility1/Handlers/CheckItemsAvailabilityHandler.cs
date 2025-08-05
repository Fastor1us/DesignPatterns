namespace ChainOfResponsibility1.Handlers;

public class CheckItemsAvailabilityHandler : HandlerBase<IOrder>
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
        foreach (var item in order.Basket)
        {
            if (!_availableItems.TryGetValue(item.Key, out var availableItem))
                throw new Exception($"Item \"{item.Key}\" is out of stock");

            if (availableItem.Item2 < item.Value)
                throw new Exception($"Not enough items \"{item.Key}\" in stock! Stock:basket -{availableItem.Item2}:{item.Value}");
        }

        Console.WriteLine("CheckItemsAvailabilityHandler: Done");
        base.Handle(order);
    }
}
