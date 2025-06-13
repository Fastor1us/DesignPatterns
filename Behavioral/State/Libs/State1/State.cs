namespace State1;

public abstract class State : IState
{
    public virtual void InsertQuarter() { }
    public virtual void EjectQuarter() { }
    public virtual void TurnCrank() { }
    public virtual void Dispense() { }
}
