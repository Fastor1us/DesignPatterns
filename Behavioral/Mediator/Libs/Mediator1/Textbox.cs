namespace Mediator1;

public class Textbox(IMediator mediator) : IComponent
{
    private IMediator _mediator = mediator;

    public string Text { get; set; } = string.Empty;

    public void SetMediator(IMediator mediator)
    {
        _mediator = mediator;
    }

    public void Show() => Console.WriteLine("Textbox shown");
    public void Hide() => Console.WriteLine("Textbox hidden");
}
