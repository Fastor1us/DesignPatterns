namespace ChainOfResponsibility1;

public interface IHandler<T> where T : class
{
    public IHandler<T> SetNext(IHandler<T> handler);
    public void Handle(T request);
}
