using ChainOfResponsibility1;
using ChainOfResponsibility1.Handlers;
using ChainOfResponsibility1.Helpers;

namespace ChainOfResponsibilityTests;

public class UnitTest1
{
    private readonly IHandler<IOrder> _chain;

    public UnitTest1()
    {
        var builder = new ChainBuilder<IOrder>()
            .Add<CheckItemsAvailabilityHandler>()
            .Add<CheckUserBalanceHandler>()
            .Add<UsePromoCodeHandler>()
            .Add<AddOrderHandler>();
        _chain = builder.Build();
    }

    private static (StringWriter stringWriter, IOrder order) SetupTest(
        Dictionary<string, int> basket,
        (string, int) user,
        string? promoCode = null,
        string orderId = "1")
    {
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        var order = new Order()
        {
            Id = orderId,
            User = user,
            Basket = basket,
            PromoCode = promoCode ?? string.Empty
        };

        return (stringWriter, order);
    }

    [Fact]
    public void MakeOrderPassingThroughAllHandlers()
    {
        // Arrange
        var (stringWriter, order) = SetupTest(
            basket: new Dictionary<string, int>
            {
                ["mobile-phone"] = 1,
                ["usb-flash-drive"] = 2,
                ["smart-watch"] = 1
            },
            user: ("SomeUser", 25_000),
            promoCode: "SALE_20");

        // Act
        _chain.Handle(order);
        var output = stringWriter.ToString();

        // Assert
        Assert.Contains("CheckItemsAvailabilityHandler: Done", output);
        Assert.Contains("CheckUserBalanceHandler: Done", output);
        Assert.Contains("Used promo-code: \"SALE_20\". Discount: 80 %", output);
        Assert.Contains("UsePromoCodeHandler: Done", output);
        Assert.Contains("Order \"1\" created..", output);
    }

    [Fact]
    public void GetErrorIfBuyUnavailableItems()
    {
        // Arrange
        var (_, order) = SetupTest(
            basket: new Dictionary<string, int> { ["fairy item"] = 100 },
            user: ("SomeUser", 0));

        // Act & Assert
        var ex = Assert.Throws<Exception>(() => _chain.Handle(order));
        Assert.Equal("Item \"fairy item\" is out of stock", ex.Message);
    }

    [Fact]
    public void GetErrorIfNotEnoughCash()
    {
        // Arrange
        var (_, order) = SetupTest(
            basket: new Dictionary<string, int> { ["laptop"] = 1 },
            user: ("SomeUser", 10_000));

        // Act & Assert
        var ex = Assert.Throws<Exception>(() => _chain.Handle(order));
        Assert.Contains("User \"SomeUser\" has not enough cash", ex.Message);
    }

    [Fact]
    public void ManualChainWithoutBuilder()
    {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        var order = new Order()
        {
            Id = "1",
            User = ("SomeUser", 25_000),
            Basket = new Dictionary<string, int>
            {
                ["mobile-phone"] = 1,
                ["usb-flash-drive"] = 2,
                ["smart-watch"] = 1
            },
            PromoCode = "SALE_20"
        };

        var chain = new CheckItemsAvailabilityHandler()
            .SetNext(new CheckUserBalanceHandler())
            .SetNext(new UsePromoCodeHandler())
            .SetNext(new AddOrderHandler());

        // Act
        chain.Handle(order);
        var output = stringWriter.ToString();

        // Assert
        Assert.Contains("Order \"1\" created..", output);
    }
}
