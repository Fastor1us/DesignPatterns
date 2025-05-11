using Adapter2;

namespace AdapterTests;

public class Adapter2Tests
{
    [Fact]
    public void SquarePegAdapterCalculatesCorrectRadius()
    {
        // Arrange
        double width = 14f;
        var squarePeg = new SquarePeg(width);
        var adapter = new SquarePegAdapter(squarePeg);

        // Act
        double actualRadius = adapter.GetRadius();
        double expectedRadius = width * Math.Sqrt(2) / 2; // ≈ 9.899

        // Assert
        Assert.Equal(expectedRadius, actualRadius, precision: 2);
    }

    [Fact]
    public void RoundHoleFitsSquarePegWithAdapter()
    {
        // Arrange
        var squarePeg = new SquarePeg(14f);
        var adapter = new SquarePegAdapter(squarePeg);
        var roundHole = new RoundHole(10f);

        // Act
        bool isFits = roundHole.Fits(adapter);

        // Assert
        Assert.True(isFits);
    }

    [Fact]
    public void RoundHoleDoesNotFitTooLargeSquarePeg()
    {
        var largeSquarePeg = new SquarePeg(20f);
        var adapter = new SquarePegAdapter(largeSquarePeg);
        var roundHole = new RoundHole(10f);

        bool fits = roundHole.Fits(adapter);

        Assert.False(fits);
    }
}
