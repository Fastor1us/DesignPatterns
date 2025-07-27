using Singleton2;

namespace SingletonTests;

public class Singleton2Tests
{
    [Fact]
    public async Task GetTheSameInstanceWhenCalledFromMultipleThreads()
    {
        // Arrange
        const int threadCount = 5;
        var tasks = new Task<Singleton>[threadCount];

        // Act
        for (int i = 0; i < threadCount; i++)
        {
            tasks[i] = Task.Run(() => Singleton.Instance);
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
        var instance1 = Singleton.Instance;
        var instance2 = Singleton.Instance;

        // Assert
        Assert.Same(instance1, instance2);
    }

    [Fact]
    public void IncrementShouldBeThreadSafe()
    {
        // Arrange
        var singleton = Singleton.Instance;
        singleton.Reset();

        // Act
        Parallel.For(0, 1000, _ => singleton.Increment());

        // Assert
        Assert.Equal(1000, singleton.GetCounterValue());
    }

    [Fact]
    public void AddShouldBeThreadSafe()
    {
        // Arrange
        var singleton = Singleton.Instance;
        singleton.Reset();

        // Act
        Parallel.For(0, 100, (i) => singleton.Add(i));

        // Assert
        // 0+1+2+...+99 = 4950
        Assert.Equal(4950, singleton.GetCounterValue());
    }
}
