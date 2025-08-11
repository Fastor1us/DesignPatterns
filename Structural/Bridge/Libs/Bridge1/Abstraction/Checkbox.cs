using Bridge1.Implementation;

namespace Bridge1.Abstraction;

// It is possible to extend the Abstract without changing the Implementation classes
public class Checkbox(IPlatformRenderer renderer, bool isChecked) : UIComponent(renderer)
{
    private readonly bool _isChecked = isChecked;

    public override void Render()
    {
        _renderer.RenderCheckbox(_isChecked);
    }
}
