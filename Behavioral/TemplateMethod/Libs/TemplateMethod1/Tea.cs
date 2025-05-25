namespace TemplateMethod1;

public class Tea(
    TeaCondiments condiments = TeaCondiments.None, TextWriter? output = null
    ) : CaffeineBeverage(output)
{
    protected override void Brew()
    {
        _output.WriteLine("Steeping the tea");
    }

    protected override void AddCondiments()
    {
        if (condiments != TeaCondiments.None)
        {
            _output.WriteLine($"Adding {condiments}");
        }
        else
        {
            base.AddCondiments();
        }
    }
}
