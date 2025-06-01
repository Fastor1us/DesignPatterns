namespace Iterator1;

public class CafeMenuIterator(IEnumerable<MenuItem> menuItems) : Iterator<MenuItem>
{
    private readonly IEnumerable<MenuItem> _menuItems = menuItems;
    private int _position = -1;

    public override MenuItem Current => _menuItems.ElementAt(_position);

    public override bool MoveNext()
    {
        _position++;
        return _position < _menuItems.Count();
    }

    public override void Reset()
    {
        _position = -1;
    }
}
