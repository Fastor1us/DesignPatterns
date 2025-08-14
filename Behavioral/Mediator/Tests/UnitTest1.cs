using Mediator1;

namespace MediatorTests;

public class UnitTest1
{
    [Fact]
    public void ButtonClick_NotifiesMediator()
    {
        // Arrange
        var mediator = new AuthenticationDialog();
        var output = new StringWriter();
        Console.SetOut(output);

        // Act
        mediator.OkButton.Click();

        // Assert
        Assert.Contains("Login button clicked", output.ToString());
    }

    [Fact]
    public void CheckboxToggle_SwitchesMode()
    {
        // Arrange
        var mediator = new AuthenticationDialog();
        var output = new StringWriter();
        Console.SetOut(output);

        // Act
        mediator.LoginOrRegisterCheckbox.Toggle();

        // Assert
        Assert.Contains("Switching to Register mode", output.ToString());
    }
}
