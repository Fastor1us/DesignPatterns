using Command1.Receivers;

namespace Command1.Commands;

public class CeilingFanCommand(CeilingFan ceilingFan, CeilingFanLevel newLevel) : ICommand
{
    private CeilingFanLevel _prevLevel = ceilingFan.Level;

    public void Execute()
    {
        _prevLevel = ceilingFan.Level;
        ceilingFan.Level = newLevel;
        ceilingFan.Run();
    }

    public void Undo()
    {
        ceilingFan.Level = _prevLevel;
        ceilingFan.Run();
    }
}
