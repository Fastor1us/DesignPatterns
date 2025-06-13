using Microsoft.VisualStudio.TestPlatform.Utilities;
using State1;
using State1.States;

namespace StateTests;

public class UnitTest1
{
    [Fact]
    public void InsertQuarterFromNoQuarterStateChangesToHasQuarterState()
    {
        // Arrange
        var output = new StringWriter();
        Console.SetOut(output);
        var machine = new GumballMachine(1);

        // Act
        machine.InsertQuarter();

        // Assert
        Assert.Contains("Querter accepted..", output.ToString());
        Assert.IsType<HasQuarterState>(machine.State);
    }

    [Fact]
    public void TurnCrankFromHasQuarterStateDispensesAndChangesState()
    {
        var output = new StringWriter();
        Console.SetOut(output);
        var machine = new GumballMachine(1);

        // Act
        machine.InsertQuarter();
        machine.TurnCrank();

        // Assert
        Assert.Contains("Crank turned..", output.ToString());
        Assert.Contains("Giving a gumball..", output.ToString());
        Assert.Equal(0, machine.Gumballs);
    }

    [Fact]
    public void EjectQuarterFromHasQuarterStateReturnsQuarter()
    {
        var output = new StringWriter();
        Console.SetOut(output);
        var machine = new GumballMachine(1);

        // Act
        machine.InsertQuarter();
        machine.EjectQuarter();

        // Assert
        Assert.Contains("Querter returned..", output.ToString());
        Assert.IsType<NoQueaterState>(machine.State);
    }
}
