using Bridge1.Implementation;

namespace Bridge1.Abstraction;

// The abstraction establishes an interface for the "control" part of the two class hierarchies
// It contains a reference to an object from the Implementation hierarchy and delegates all the real work to it
public abstract class UIComponent(IPlatformRenderer renderer)
{
    protected readonly IPlatformRenderer _renderer = renderer;
    public abstract void Render();
}
