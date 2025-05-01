using Strategy1.Interfaces;

namespace Strategy1.Behaviors;

public class MuteQuack : IQuackBehavior
{
    public string Quack()
    {
        return "<< Silence >>";
    }
}

public class BaseQuack : IQuackBehavior
{
    public string Quack()
    {
        return "Quack!";
    }
}

public class Squeak : IQuackBehavior
{
    public string Quack()
    {
        return "Squeak!";
    }
}
