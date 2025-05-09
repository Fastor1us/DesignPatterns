using Command1.Receivers;

namespace Command1.Commands;

public class LightOnCommand(Light light) : ICommand
{
    public void Execute()
    {
        light.On();
    }

    public void Undo()
    {
        light.Off();
    }
}
