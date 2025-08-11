using Bridge1.Implementation;

namespace Bridge1.Abstraction;

// It is possible to extend the Abstract without changing the Implementation classes
public class Button(IPlatformRenderer renderer, string text) : UIComponent(renderer)
{
    private readonly string _text = text;

    public override void Render()
    {
        _renderer.RenderButton(_text);
    }
}
