using Strategy1.Interfaces;

namespace Strategy1;

public abstract class Duck(IFlyBehavior flyBehavior, IQuackBehavior quackBehavior)
{
    public IFlyBehavior FlyBehavior { get; set; } = flyBehavior;
    public IQuackBehavior QuackBehavior { get; set; }  = quackBehavior;

    public abstract string Display();

    public string PerformFly() => FlyBehavior.Fly();

    public string PerformQuack() => QuackBehavior.Quack();
}
