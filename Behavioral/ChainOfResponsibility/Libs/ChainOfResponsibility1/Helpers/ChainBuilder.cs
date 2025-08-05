namespace ChainOfResponsibility1.Helpers;

public class ChainBuilder<T> where T : class
{
    private readonly List<Type> _handlerTypes = [];

    public ChainBuilder<T> Add<THandler>() where THandler : IHandler<T>, new()
    {
        _handlerTypes.Add(typeof(THandler));
        return this;
    }

    public IHandler<T> Build()
    {
        if (_handlerTypes.Count == 0)
            throw new InvalidOperationException("No handlers added");

        IHandler<T>? first = null;
        IHandler<T>? current = null;

        foreach (var type in _handlerTypes)
        {
            var handler = (IHandler<T>)Activator.CreateInstance(type)!;

            if (first is null)
            {
                first = handler;
            }
            else
            {
                current!.SetNext(handler);
            }
            current = handler;
        }

        return first!;
    }
}
