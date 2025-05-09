namespace Command1.Receivers;

public class GarageDoor(TextWriter? output) : ReceiverBase(output)
{
    public void Up()
    {
        _output.WriteLine("Garage Door is Open");
    }

    public void Down()
    {
        _output.WriteLine("Garage Door is Closed");
    }
}
