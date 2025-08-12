namespace Flyweight1;

// A specific Flyweight contains an internal state (shared)
public class CharacterFlyweight(char symbol) : IFlyweight
{
    private readonly char _symbol = symbol; // inner state

    public void Display(int x, int y) // outer state
    {
        Console.WriteLine($"Symbol: {_symbol}, Position: ({x}, {y})");
    }
}
