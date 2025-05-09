namespace Command1.Receivers;

public abstract class ReceiverBase(TextWriter? output = null)
{
    protected readonly TextWriter _output = output ?? Console.Out;
}
