namespace TemplateMethod1;

public abstract class CaffeineBeverage(TextWriter? output = null)
{
    protected readonly TextWriter _output = output ?? Console.Out;

    public void PrepareRecipe()
    {
        BoildWater();
        Brew();
        PourInCup();
        AddCondiments();
    }

    private void BoildWater()
    {
        _output.WriteLine("Boiling water");
    }

    protected abstract void Brew();

    private void PourInCup()
    {
        _output.WriteLine("Pouring into cup");
    }

    protected virtual void AddCondiments() { }
}
