using Strategy1.Interfaces;

namespace Strategy1.Behaviors;

public class FlyNoWay : IFlyBehavior
{
    public string Fly()
    {
        return "I can't fly!";
    }
}

public class FlyRocketPowered : IFlyBehavior
{
    public string Fly()
    {
        return "I'm flying with a rocket!";
    }
}
public class FlyWithWings : IFlyBehavior
{
    public string Fly()
    {
        return "I'm flying!";
    }
}
