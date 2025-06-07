using Composite1;

namespace CompositeTests;

public class UnitTest1
{
    [Fact]
    public void MenuItemPrintShowNameAndPrice()
    {
        // Arrange
        var item = new MenuItem("Porridge", 100);
        var output = new StringWriter();
        Console.SetOut(output);

        // Act
        item.Print();

        // Assert
        Assert.Contains("Porridge - 100 coins", output.ToString());
    }

    [Fact]
    public void MenuGroupCalculatesTotalPrice()
    {
        // Arrange
        var menu = new MenuGroup("Dinner menu");
        List<MenuItem> items = [new("Porridge", 100), new("Burger", 250)];
        foreach (var item in items) menu.Add(item);

        // Act & Assert
        Assert.Equal(350, menu.Price);
    }

    [Fact]
    public void CompositeMenuPrintsHierarchy()
    {
        // Arrange
        var menu = new MenuGroup("Main menu");

        var drinks = new MenuGroup("Beverage menu");
        drinks.Add(new MenuItem("Coffee", 150));
        drinks.Add(new MenuItem("Tea", 100));

        var desserts = new MenuGroup("Desserts");
        desserts.Add(new MenuItem("Cheesecake", 200));

        menu.Add(drinks);
        menu.Add(desserts);

        var output = new StringWriter();
        Console.SetOut(output);

        // Act
        menu.Print();
        var result = output.ToString();

        // Assert
        Assert.Contains("Main menu (Total: 450 coins)", result);
        Assert.Contains("--------------------", result);
        Assert.Contains("Beverage menu (Total: 250 coins)", result);
        Assert.Contains("--------------------", result);
        Assert.Contains("Coffee - 150 coins", result);
        Assert.Contains("Tea - 100 coins", result);
        Assert.Contains("Desserts (Total: 200 coins)", result);
        Assert.Contains("--------------------", result);
        Assert.Contains("Cheesecake - 200 coins", result);
    }
}
