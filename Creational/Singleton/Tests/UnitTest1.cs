using Singleton1;

namespace SingletonTests;

public class UnitTest1
{
    [Fact]
    public async Task GetTheSameInstanceWhenCalledFromMultipleThreads()
    {
        // Arrange
        const int threadCount = 5;
        var tasks = new Task<LogisticsCompany>[threadCount];

        // Act
        for (int i = 0; i < threadCount; i++)
        {
            tasks[i] = Task.Run(() => LogisticsCompany.Instance);
        }
        var instances = await Task.WhenAll(tasks);

        // Assert
        var firstInstance = instances[0];
        for (int i = 1; i < threadCount; i++)
        {
            Assert.Same(firstInstance, instances[i]);
        }
    }

    [Fact]
    public void GetTheSameInstanceOnMultipleCalls()
    {
        // Arrange
        var instance1 = LogisticsCompany.Instance;
        var instance2 = LogisticsCompany.Instance;

        // Assert
        Assert.Same(instance1, instance2);
    }

    [Fact]
    public void ConstructorIsPrivate()
    {
        // Arrange & Act
        var constructor = typeof(LogisticsCompany)
            .GetConstructor(
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic,
                null, Type.EmptyTypes, null);

        // Assert
        Assert.NotNull(constructor);
        Assert.True(constructor!.IsPrivate);
    }

    [Fact]
    public void CompanyNameIsInitializedCorrectly()
    {
        // Arrange
        var company = LogisticsCompany.Instance;

        // Assert
        Assert.Equal("Global Logistics Incorporated", company.CompanyName);
    }

    [Theory]
    [InlineData(5.0)]
    [InlineData(10.75)]
    [InlineData(0.01)]
    public void SetsNewRateShippingRateWhenValueIsPositive(double newRate)
    {
        // Arrange
        var company = LogisticsCompany.Instance;
        var originalRate = company.ShippingRate;

        // Act
        company.UpdateShippingRate(newRate);

        // Assert
        Assert.Equal(newRate, company.ShippingRate);
        Assert.NotEqual(originalRate, company.ShippingRate);
    }

    [Theory]
    [InlineData(-5.0)]
    [InlineData(0.0)]
    [InlineData(-0.01)]
    public void KeepsOldShippingRateWhenValueNonPositive(double invalidRate)
    {
        // Arrange
        var company = LogisticsCompany.Instance;
        var originalRate = company.ShippingRate;

        // Act
        company.UpdateShippingRate(invalidRate);

        // Assert
        Assert.Equal(originalRate, company.ShippingRate);
    }

    [Theory]
    [InlineData(100, 3.5, 350.0)]
    [InlineData(50, 2.0, 100.0)]
    [InlineData(0, 10.0, 0.0)]
    public void CalculateShippingCostReturnsCorrectValue(
        double distance,
        double testRate,
        double expected)
    {
        // Arrange
        var company = LogisticsCompany.Instance;
        company.UpdateShippingRate(testRate);

        // Act
        var result = company.CalculateShippingCost(distance);

        // Assert
        Assert.Equal(expected, result);
    }
}
