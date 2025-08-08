namespace Builder1;

public class HouseDirector(IHouseBuilder builder)
{
    public House BuildStandardHouse()
    {
        return builder
            .BuildWalls(4)
            .BuildDoors(2)
            .BuildWindows(6)
            .BuildRoof()
            .GetResult();
    }

    public House BuildLuxuryHouse()
    {
        return builder
            .BuildWalls(6)
            .BuildDoors(4)
            .BuildWindows(12)
            .BuildRoof()
            .BuildGarage()
            .BuildSwimmingPool()
            .BuildGarden("landscaping")
            .GetResult();
    }
}
