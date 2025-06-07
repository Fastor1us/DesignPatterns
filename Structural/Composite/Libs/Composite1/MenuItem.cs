namespace Composite1;

/// <summary>
/// Leaf Component
/// </summary>
/// <param name="name"></param>
/// <param name="price"></param>
public class MenuItem(string name, double price) : IMenuComponent
{
    public string Name { get; } = name;
    public double Price { get; } = price;

    public void Print() => Console.WriteLine($"{Name} - {Price}");

    public void Add(IMenuComponent component) =>
        throw new NotSupportedException("Cannot add to a leaf");

    public void Remove(IMenuComponent component) =>
        throw new NotSupportedException("Cannot remove from a leaf");

    public IMenuComponent? GetChild(int index) => null;
}
