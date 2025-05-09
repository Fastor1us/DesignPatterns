namespace Command1.Commands;

public class MacroCommand : ICommand
{
    public List<ICommand> Commands { get; set; } = [];

    public void Execute()
    {
        Commands.ForEach(c => c.Execute());
    }

    public void Undo()
    {
        for (int i = Commands.Count - 1; i >= 0; i--)
        {
            Commands[i].Undo();
        }
    }
}
