using Strategy1.Behaviors;

namespace Strategy1.Ducks;

public class MallardDuck() : Duck(new FlyWithWings(), new BaseQuack())
{
    public override string Display()
    {
        return "I'm a real Mallard duck";
    }
}
