namespace Mediator1;

public class Button(IMediator mediator) : IComponent
{
    private IMediator _mediator = mediator;

    public void SetMediator(IMediator mediator)
    {
        _mediator = mediator;
    }

    public void Click()
    {
        Console.WriteLine("Button clicked");
        _mediator.Notify(this, "click");
    }
}
