namespace Composite1;

/// <summary>
/// Composite Component
/// </summary>
/// <param name="name"></param>
public class MenuGroup(string name) : IMenuComponent
{
    private readonly List<IMenuComponent> _children = [];

    public string Name { get; } = name;

    public double Price => _children.Sum(c => c.Price);

    public void Print()
    {
        Console.WriteLine($"\n{Name} (Total: {Price} coins)");
        Console.WriteLine(new string('-', 20));

        foreach (var child in _children) child.Print();
    }

    public void Add(IMenuComponent component) => _children.Add(component);

    public void Remove(IMenuComponent component) => _children.Remove(component);

    public IMenuComponent? GetChild(int index) =>
        _children.ElementAtOrDefault(index);
}
