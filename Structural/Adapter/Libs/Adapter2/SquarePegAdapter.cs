namespace Adapter2;

public class SquarePegAdapter(ISquarePeg squarePeg) : IRoundPeg
{
    public double GetRadius() => squarePeg.GetWidth() * Math.Sqrt(2) / 2;
}
