using TemplateMethod1;

namespace TemplateMethodTests;

public class UnitTest1
{
    [Fact]
    public void CoffeeWithSugarAndMilkContainsAllPreparationStages()
    {
        // Arrange
        var output = new StringWriter();
        var condiments = CoffeeCondiments.Sugar | CoffeeCondiments.Milk;
        var coffee = new Coffee(condiments, output);

        // Act
        coffee.PrepareRecipe();
        var result = output.ToString();

        // Assert
        Assert.Contains("Boiling water", result);
        Assert.Contains("Dripping Coffee through filter", result);
        Assert.Contains("Pouring into cup", result);
        Assert.Contains("Adding Sugar, Milk", result);
    }

    [Fact]
    public void TeaWithSugarAndLemonContainsAllPreparationStages()
    {
        // Arrange
        var output = new StringWriter();
        var condiments = TeaCondiments.Sugar | TeaCondiments.Lemon;
        var coffee = new Tea(condiments, output);

        // Act
        coffee.PrepareRecipe();
        var result = output.ToString();

        // Assert
        Assert.Contains("Boiling water", result);
        Assert.Contains("Steeping the tea", result);
        Assert.Contains("Pouring into cup", result);
        Assert.Contains("Adding Sugar, Lemon", result);
    }

    [Fact]
    public void CoffeeWithoutCondimentsDoesNotAddAnything()
    {
        // Arrange
        var output = new StringWriter();
        var coffee = new Coffee(CoffeeCondiments.None, output);

        // Act
        coffee.PrepareRecipe();
        var result = output.ToString();

        // Assert
        Assert.DoesNotContain("Adding", result);
    }
}
