namespace ChainOfResponsibility1.Handlers;

public class AddOrderHandler : HandlerBase<IOrder>
{
    public override void Handle(IOrder order)
    {
        Console.WriteLine($"Order \"{order.Id}\" created..");
        base.Handle(order);
    }
}
