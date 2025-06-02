using Iterator1;

namespace IteratorTests;

public class UnitTest1
{
    [Fact]
    public void IteratorWithEmptyCollectionHasNoItems()
    {
        // Arrange
        CafeMenu emptyMenu = new([]);
        var iterator = emptyMenu.CreateIterator();

        // Act & Assert
        Assert.False(iterator.MoveNext());
        Assert.Throws<ArgumentOutOfRangeException>(() => iterator.Current);
    }

    [Fact]
    public void IteratorIteratesThroughAllMenuItemsInOrder()
    {
        // Arrange
        var menuItems = new List<MenuItem>
        {
            new("Cappuccino", 1),
            new("Latte", 2),
            new("Cheesecake", 3)
        };

        CafeMenu cafeMenu = new(menuItems);
        var iterator = cafeMenu.CreateIterator();
        List<MenuItem> result = [];

        // Act
        while (iterator.MoveNext())
        {
            result.Add((MenuItem)iterator.Current);
        }

        // Assert
        Assert.Equal(3, result.Count);
        Assert.Equal("Cappuccino", result[0].Name);
        Assert.Equal(2, result[1].Price);
        Assert.Equal("Cheesecake", result[2].Name);
    }

    [Fact]
    public void IteratorResetStartsFromBeginning()
    {
        // Arrange
        List<MenuItem> menuItems = [new("Espresso", 1)];
        CafeMenu cafeMenu = new(menuItems);
        var iterator = cafeMenu.CreateIterator();

        // Act
        iterator.MoveNext();
        var firstPass = (MenuItem)iterator.Current;
        iterator.Reset();
        iterator.MoveNext();
        var secondPass = (MenuItem)iterator.Current;

        // Assert
        Assert.Equal(firstPass, secondPass);
    }

    [Fact]
    public void CurrentBeforeFirstMoveNextThrowsException()
    {
        // Arrange
        List<MenuItem> menuItems = [new("Espresso", 1)];
        CafeMenu cafeMenu = new(menuItems);
        var iterator = cafeMenu.CreateIterator();

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => iterator.Current);
    }

    [Fact]
    public void CurrentAfterLastItemThrowsException()
    {
        // Arrange
        List<MenuItem> menuItems = [new("Espresso", 1)];
        CafeMenu cafeMenu = new(menuItems);
        var iterator = cafeMenu.CreateIterator();

        // Act
        iterator.MoveNext();
        iterator.MoveNext();

        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => iterator.Current);
    }

    [Fact]
    public void CanIterateWithForeach()
    {
        // Arrange
        CafeMenu cafeMenu = new(
        [
            new("Americano", 1.5),
            new("Croissant", 2.0)
        ]);
        List<MenuItem> result = [];

        // Act
        foreach (var item in cafeMenu)
        {
            result.Add(item);
        }

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Equal("Americano", result[0].Name);
    }

    [Fact]
    public void CanIterateWithForEachMethod()
    {
        // Arrange
        CafeMenu cafeMenu = new([new MenuItem("Tea", 1.0)]);

        // Act & Assert
        cafeMenu.ToList().ForEach(item => Assert.Equal("Tea", item.Name));
    }

    [Fact]
    public void WhileLoopWorksWithIterator()
    {
        // Arrange
        var menu = new CafeMenu(
        [
            new MenuItem("A", 1),
            new MenuItem("B", 2)
        ]);

        // Act
        var iterator = menu.CreateIterator();
        List<string> result = [];

        while (iterator.MoveNext())
        {
            result.Add(iterator.Current.Name);
        }

        // Assert
        Assert.Equal(["A", "B"], result);
    }
}
