namespace Facade1;

public abstract class ServiceBase(TextWriter? output = null)
{
    protected readonly TextWriter _output = output ?? Console.Out;
}
