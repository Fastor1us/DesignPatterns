namespace Composite1;

public interface IMenuComponent
{
    string Name { get; }
    double Price { get; }
    void Print();
    void Add(IMenuComponent component);
    void Remove(IMenuComponent component);
    IMenuComponent? GetChild(int index);
}
