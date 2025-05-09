using Command1.Receivers;

namespace Command1.Commands;

public class LightOffCommand(Light light) : ICommand
{
    public void Execute()
    {
        light.Off();
    }

    public void Undo()
    {
        light.On();
    }
}
