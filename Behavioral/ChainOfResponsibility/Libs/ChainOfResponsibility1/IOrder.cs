namespace ChainOfResponsibility1;

public interface IOrder
{
    public string Id { get; set; }
    public (string id, int cash) User { get; set; }
    public Dictionary<string, int> Basket { get; set; }
    public string PromoCode { get; set; }
}
