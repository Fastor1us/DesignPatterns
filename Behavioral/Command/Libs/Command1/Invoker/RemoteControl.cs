using Command1.Commands;
using System.Text;

namespace Command1.Invoker;

public class RemoteControl
{
    public const int SlotCapacity = 5;
    readonly ICommand[] onCommands = new ICommand[SlotCapacity];
    readonly ICommand[] offCommands = new ICommand[SlotCapacity];
    readonly Stack<ICommand> undoCommands = [];
    protected readonly TextWriter _output;

    public RemoteControl(TextWriter? output = null)
    {
        _output = output ?? Console.Out;

        ICommand noCommand = new NoCommand();
        for (int i = 0; i < SlotCapacity; i++)
        {
            onCommands[i] = noCommand;
            offCommands[i] = noCommand;
        }
    }

    public void SetCommand(int slot, ICommand onCommand, ICommand offCommand)
    {
        ValidateSlot(slot);
        onCommands[slot] = onCommand;
        offCommands[slot] = offCommand;
    }

    public void OnButtonWasPressed(int slot)
    {
        ValidateSlot(slot);
        onCommands[slot].Execute();
        undoCommands.Push(onCommands[slot]);
    }

    public void OffButtonWasPressed(int slot)
    {
        ValidateSlot(slot);
        offCommands[slot].Execute();
        undoCommands.Push(offCommands[slot]);
    }

    public void OnUndoWasPressed()
    {
        if (undoCommands.Count > 0)
        {
            undoCommands
                .Pop()
                .Undo();
        }
    }

    private static void ValidateSlot(int slot)
    {
        if (slot < 0 || slot >= SlotCapacity)
        {
            var message = $"Slot must be between 0 and {SlotCapacity - 1}";
            throw new ArgumentOutOfRangeException(nameof(slot), message);
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine("----- Remote Control -----");
        for (int i = 0; i < SlotCapacity; i++)
        {
            string onName = onCommands[i].GetType().Name;
            string offName = offCommands[i].GetType().Name;
            sb.AppendLine($"[slot {i}]: {onName} {offName}");
        }
        return sb.ToString();
    }

    public void DumpCommands()
    {
        _output.Write(ToString());
    }
}
