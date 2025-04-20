using Strategy1.Behaviors;

namespace Strategy1.Ducks;

public class ModelDuck() : Duck(new FlyNoWay(), new BaseQuack())
{
    public override string Display()
    {
        return "I'm a model duck";
    }
}
