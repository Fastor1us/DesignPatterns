namespace ChainOfResponsibility1;

public abstract class HandlerBase<T> : IHandler<T> where T : class
{
    private IHandler<T>? _next;

    public IHandler<T> SetNext(IHandler<T> handler)
    {
        _next = handler;
        return handler;
    }

    public virtual void Handle(T request)
    {
        _next?.Handle(request);
    }

    protected void ThrowIfNull(object? obj, string message)
    {
        if (obj is null) throw new ArgumentNullException(message);
    }
}
