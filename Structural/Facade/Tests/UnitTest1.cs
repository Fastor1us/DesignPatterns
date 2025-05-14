using Facade1;

namespace FacadeTests;

public class UnitTest1
{
    [Fact]
    public void MorningRoutineActivatesAllNeededServices()
    {
        // Arrange
        var output = new StringWriter();
        var facade = new SmartHomeFacade(output);

        // Act
        facade.StartMorningRoutine();
        var result = output.ToString();

        // Assert
        Assert.Contains("Lights on", result);
        Assert.Contains("Brightness set to 70%", result);
        Assert.Contains("Temperature set to 21°C", result);
        Assert.Contains("Filling water tank", result);
        Assert.Contains("Making coffee...", result);
        Assert.Contains("Playing 'Morning Jazz'", result);
        Assert.Contains("Volume set to 30%", result);
    }

    [Fact]
    public void AwayModeDeactivatesAllServices()
    {
        // Arrange
        var output = new StringWriter();
        var facade = new SmartHomeFacade(output);

        // Act
        facade.ActivateAwayMode();
        var result = output.ToString();

        // Assert
        Assert.Contains("Lights off", result);
        Assert.Contains("Energy saving mode activated", result);
        Assert.Contains("Music stopped", result);
        Assert.Contains("Coffee machine in sleep mode", result);
    }
}
