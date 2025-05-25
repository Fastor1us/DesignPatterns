namespace TemplateMethod1;

public class Coffee(
    CoffeeCondiments condiments = CoffeeCondiments.None, TextWriter? output = null
    ) : CaffeineBeverage(output)
{
    protected override void Brew()
    {
        _output.WriteLine("Dripping Coffee through filter");
    }

    protected override void AddCondiments()
    {
        if (condiments != CoffeeCondiments.None)
        {
            _output.WriteLine($"Adding {condiments}");
        }
        else
        {
            base.AddCondiments();
        }
    }
}
