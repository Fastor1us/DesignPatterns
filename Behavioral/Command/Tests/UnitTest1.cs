using Command1.Commands;
using Command1.Invoker;
using Command1.Receivers;

namespace CommandTests;

public class UnitTest1
{
    [Fact]
    public void SetCommandShouldAssignCommandsToSlots()
    {
        // Arrange
        var output = new StringWriter();
        var control = new RemoteControl(output);
        var light = new Light(null);
        var lightOn = new LightOnCommand(light);
        var lightOff = new LightOffCommand(light);
        control.SetCommand(1, lightOn, lightOff);

        // Act
        control.DumpCommands();
        var dump = output.ToString();

        // Assert
        Assert.Contains("[slot 0]: NoCommand NoCommand", dump);
        Assert.Contains("[slot 1]: LightOnCommand LightOffCommand", dump);
    }

    [Fact]
    public void OnButtonWasPressedShouldExecuteOnCommand()
    {
        // Arrange
        var output = new StringWriter();
        var control = CreateRemoteWithLight(output);

        // Act
        control.OnButtonWasPressed(0);
        var result = output.ToString();

        // Assert
        Assert.Contains("Light is On", result);
    }

    [Fact]
    public void OffButtonWasPressedShouldExecuteOffCommand()
    {
        // Arrange
        var output = new StringWriter();
        var control = CreateRemoteWithLight(output);

        // Act
        control.OffButtonWasPressed(0);
        var result = output.ToString();

        // Assert
        Assert.Contains("Light is Off", result);
    }

    [Fact]
    public void OnUndoWasPressedShouldUndoLastCommand()
    {
        // Arrange
        var output = new StringWriter();
        var control = CreateRemoteWithLight(output);

        // Act
        control.OnButtonWasPressed(0);
        control.OnUndoWasPressed();
        var result = output.ToString();

        // Assert
        Assert.Equal("Light is On\r\nLight is Off\r\n", result);
    }

    [Fact]
    public void CeilingFanCommandExecuteShouldSetLevel()
    {
        // Arrange
        var output = new StringWriter();
        var control = new RemoteControl(output);
        var fan = new CeilingFan(output, "Living Room");
        var fanCommandOff = new CeilingFanCommand(fan, CeilingFanLevel.Off);
        var fanCommandLow = new CeilingFanCommand(fan, CeilingFanLevel.Low);
        control.SetCommand(0, fanCommandLow, fanCommandOff);

        // Act
        control.OnButtonWasPressed(0);
        var result = output.ToString();

        // Assert
        Assert.Equal(CeilingFanLevel.Low, fan.Level);
        Assert.Contains("CeilingFan in Living Room works on Low level", result);
    }

    [Fact]
    public void CeilingFanCommandUndoShouldRestorePreviousLevel()
    {
        // Arrange
        var output = new StringWriter();
        var control = new RemoteControl(output);
        var fan = new CeilingFan(output, "Living Room");
        var fanCommandOff = new CeilingFanCommand(fan, CeilingFanLevel.Off);
        var fanCommandLow = new CeilingFanCommand(fan, CeilingFanLevel.Low);
        var fanCommandHigh = new CeilingFanCommand(fan, CeilingFanLevel.High);
        control.SetCommand(0, fanCommandLow, fanCommandOff);
        control.SetCommand(1, fanCommandHigh, fanCommandOff);

        // Act
        control.OnButtonWasPressed(0);
        control.OnButtonWasPressed(1);
        output.GetStringBuilder().Clear();
        control.OnUndoWasPressed();
        var result = output.ToString();

        // Assert
        Assert.Equal(CeilingFanLevel.Low, fan.Level);
        Assert.Contains("CeilingFan in Living Room works on Low level", result);
    }

    [Fact]
    public void MacroCommandExecuteAndUndoShouldCallAllCommands()
    {
        // Arrange
        var output = new StringWriter();

        var light = new Light(output);
        var lightOn = new LightOnCommand(light);
        var lightOff = new LightOffCommand(light);

        var garageDoor = new GarageDoor(output);
        var garageOpen = new GarageDoorOpenCommand(garageDoor);
        var garageClose = new GarageDoorCloseCommand(garageDoor);

        var macroOn = new MacroCommand();
        var macroOff = new MacroCommand();
        var remote = new RemoteControl(output);

        macroOn.Commands.Add(lightOn);
        macroOn.Commands.Add(garageOpen);

        macroOff.Commands.Add(lightOff);
        macroOff.Commands.Add(garageClose);

        remote.SetCommand(0, macroOn, macroOff);

        // Act
        remote.OnButtonWasPressed(0);
        remote.OnUndoWasPressed();

        var result = output.ToString();

        // Assert
        Assert.Contains("Light is On", result);
        Assert.Contains("Garage Door is Open", result);
        Assert.Contains("Light is Off", result);
        Assert.Contains("Garage Door is Closed", result);
    }

    #region
    private static RemoteControl CreateRemoteWithLight(StringWriter output)
    {
        var control = new RemoteControl(output);
        var light = new Light(output);
        var lightOn = new LightOnCommand(light);
        var lightOff = new LightOffCommand(light);
        control.SetCommand(0, lightOn, lightOff);
        return control;
    }
    #endregion
}
