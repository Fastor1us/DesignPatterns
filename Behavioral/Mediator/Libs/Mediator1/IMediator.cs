namespace Mediator1;

public interface IMediator
{
    void Notify(object sender, string eventCode);
}
