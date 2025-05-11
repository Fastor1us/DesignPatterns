namespace Adapter2;

public class RoundHole(double radius)
{
    public bool Fits(IRoundPeg peg) => peg.GetRadius() <= radius;
}
