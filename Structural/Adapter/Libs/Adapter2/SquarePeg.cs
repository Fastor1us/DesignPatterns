namespace Adapter2;

public class SquarePeg(double width) : ISquarePeg
{
    public double GetWidth() => width;
}
