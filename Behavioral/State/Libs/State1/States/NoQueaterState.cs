namespace State1.States;

public class NoQueaterState(GumballMachine context) : State
{
    public override void InsertQuarter()
    {
        Console.WriteLine("Querter accepted..");

        // Act...

        context.SetState(context.HasQuarterState);
    }
}
