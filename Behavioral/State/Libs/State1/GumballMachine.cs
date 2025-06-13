using State1.States;

namespace State1;

public class GumballMachine : IState
{
    public SoldOutState SoldOutState { get; private set; }
    public NoQueaterState NoQueaterState { get; private set; }
    public HasQuarterState HasQuarterState { get; private set; }
    public SoldState SoldState { get; private set; }

    public IState State { get; private set; }
    public int Gumballs { get; private set; }

    public GumballMachine(int initAmountOfGumballs = 0)
    {
        SoldOutState = new SoldOutState(this);
        NoQueaterState = new NoQueaterState(this);
        HasQuarterState = new HasQuarterState(this);
        SoldState = new SoldState(this);

        Gumballs = initAmountOfGumballs;

        State = Gumballs > 0 ? NoQueaterState : SoldOutState;
    }

    public void SetState(State state) => State = state;

    public void InsertQuarter() => State.InsertQuarter();
    public void EjectQuarter() => State.EjectQuarter();
    public void TurnCrank()
    {
        State.TurnCrank();
        State.Dispense();
    }
    public void Dispense() { }

    public void ReleaseBall()
    {
        if (Gumballs > 0) Gumballs--;
    }

    public void Refill(int gumballAmount)
    {
        Gumballs += gumballAmount;

        if (Gumballs > 0 && State == SoldOutState)
        {
            State = NoQueaterState;
        }
    }
}
