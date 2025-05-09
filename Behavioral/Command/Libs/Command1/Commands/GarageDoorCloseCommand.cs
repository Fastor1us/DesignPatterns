using Command1.Receivers;

namespace Command1.Commands;

public class GarageDoorCloseCommand(GarageDoor garageDoor) : ICommand
{
    public void Execute()
    {
        garageDoor.Down();
    }

    public void Undo()
    {
        garageDoor.Up();
    }
}
