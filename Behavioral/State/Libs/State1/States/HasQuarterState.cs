namespace State1.States;

public class HasQuarterState(GumballMachine context) : State
{
    public override void EjectQuarter()
    {
        Console.WriteLine("Querter returned..");

        // Act...

        context.SetState(context.NoQueaterState);
    }

    public override void TurnCrank()
    {
        Console.WriteLine("Crank turned..");

        // Act...

        context.SetState(context.SoldState);
    }
}
