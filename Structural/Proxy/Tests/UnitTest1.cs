using Proxy1;
using System.Diagnostics;

namespace ProxyTests;

public class UnitTest1
{
    [Fact]
    public void CachingProxyReturnsCachedValue()
    {
        // Arrange
        var proxy = new CachingWeatherProxy();

        // Act
        var stopwatch = Stopwatch.StartNew();
        proxy.GetWeather("SomeTown");
        stopwatch.Stop();
        var firstCallTime = stopwatch.ElapsedMilliseconds;
        stopwatch.Restart();
        proxy.GetWeather("SomeTown");
        stopwatch.Stop();
        var secondCallTime = stopwatch.ElapsedMilliseconds;

        // Assert
        Assert.True(secondCallTime < 0_100);
        Assert.True(firstCallTime >= 1_000);
    }

    [Fact]
    public void SecurityProxyBlocksUnauthorizedAccess()
    {
        // Arrange
        var proxy = new SecurityWeatherProxy(new UserContext(false));

        // Assert
        Assert.Throws<UnauthorizedAccessException>(() =>
            proxy.GetWeather("SomeTown"));
    }
}
