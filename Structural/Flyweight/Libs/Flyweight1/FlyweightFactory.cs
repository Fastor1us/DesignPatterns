namespace Flyweight1;

public class FlyweightFactory
{
    private readonly Dictionary<char, IFlyweight> _flyweights = [];

    public IFlyweight GetFlyweight(char key)
    {
        if (_flyweights.TryGetValue(key, out var flyweight))
        {
            return flyweight;
        }

        var newFlyweight = new CharacterFlyweight(key);
        _flyweights.Add(key, newFlyweight);
        return newFlyweight;
    }

    public int GetFlyweightsCount() => _flyweights.Count;
}
