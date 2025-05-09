namespace Command1.Receivers;

public class Light(TextWriter? output) : ReceiverBase(output)
{
    public void On()
    {
        _output.WriteLine("Light is On");
    }

    public void Off()
    {
        _output.WriteLine("Light is Off");
    }
}
