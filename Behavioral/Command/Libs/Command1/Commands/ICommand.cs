namespace Command1.Commands;

public interface ICommand
{
    void Execute();
    void Undo();
}
