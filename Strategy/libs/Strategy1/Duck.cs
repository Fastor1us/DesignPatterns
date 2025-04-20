using Strategy1.Interfaces;

namespace Strategy1;

public abstract class Duck(IFlyBehavior flyBehavior, IQuackBehavior quackBehavior)
{
    protected IFlyBehavior flyBehavior = flyBehavior;
    protected IQuackBehavior quackBehavior = quackBehavior;

    public abstract string Display();

    public string PerformFly() => flyBehavior.Fly();

    public string PerformQuack() => quackBehavior.Quack();
    
    public static string Swim()
    {
        return "All ducks float, even decoys!";
    }

    public void SetFlyBehavior(IFlyBehavior flyBehavior)
    {
        this.flyBehavior = flyBehavior;
    }

    public void SetQuackBehavior(IQuackBehavior quackBehavior)
    {
        this.quackBehavior = quackBehavior;
    }
}
