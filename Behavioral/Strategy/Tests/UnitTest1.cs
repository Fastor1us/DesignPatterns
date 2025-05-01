using Strategy1.Ducks;
using Strategy1.Behaviors;

namespace StrategyTests;

public class DuckTests
{
    [Fact]
    public void MallardDuck_PerformFly()
    {
        var mallard = new MallardDuck();
        var result = mallard.PerformFly();
        Assert.Equal("I'm flying!", result);
    }

    [Fact]
    public void ModelDuck_PerformFly()
    {
        var model = new ModelDuck();
        var result = model.PerformFly();
        Assert.Equal("I can't fly!", result);
    }

    [Fact]
    public void ModelDuck_SetFlyBehavior()
    {
        var model = new ModelDuck();
        model.FlyBehavior = new FlyRocketPowered();
        var result = model.PerformFly();
        Assert.Equal("I'm flying with a rocket!", result);
    }

    [Fact]
    public void MallardDuck_PerformQuack()
    {
        var mallard = new MallardDuck();
        var result = mallard.PerformQuack();
        Assert.Equal("Quack!", result);
    }
}
