namespace Mediator1;

public class Checkbox(IMediator mediator) : IComponent
{
    private IMediator _mediator = mediator;
    public bool Checked { get; private set; }

    public void SetMediator(IMediator mediator)
    {
        _mediator = mediator;
    }

    public void Toggle()
    {
        Checked = !Checked;
        Console.WriteLine($"Checkbox toggled to: {Checked}");
        _mediator.Notify(this, "check");
    }
}
