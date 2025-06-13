namespace State1.States;

public class SoldState(GumballMachine context) : State
{
    public override void Dispense()
    {
        Console.WriteLine("Giving a gumball..");

        context.ReleaseBall();

        context.SetState(
                context.Gumballs > 0
                    ? context.HasQuarterState
                    : context.SoldOutState
            );
    }
}
