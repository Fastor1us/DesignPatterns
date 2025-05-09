using Command1.Receivers;

namespace Command1.Commands;

public class GarageDoorOpenCommand(GarageDoor garageDoor) : ICommand
{
    public void Execute()
    {
        garageDoor.Up();
    }

    public void Undo()
    {
        garageDoor.Down();
    }
}
