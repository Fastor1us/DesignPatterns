using System.Collections;

namespace Iterator1;

public class CafeMenu(IEnumerable<MenuItem> menuItems) : IMenuCollection, IEnumerable<MenuItem>
{
    private readonly IEnumerable<MenuItem> _menuItems = menuItems;

    public Iterator<MenuItem> CreateIterator()
    {
        return new CafeMenuIterator(_menuItems);
    }

    public IEnumerator<MenuItem> GetEnumerator() => CreateIterator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
