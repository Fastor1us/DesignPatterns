namespace Builder1;

public class HouseBuilder : IHouseBuilder
{
    private House _house = new();

    public IHouseBuilder BuildWalls(int count)
    {
        _house.Walls = count;
        return this;
    }

    public IHouseBuilder BuildDoors(int count)
    {
        _house.Doors = count;
        return this;
    }

    public IHouseBuilder BuildWindows(int count)
    {
        _house.Windows = count;
        return this;
    }

    public IHouseBuilder BuildRoof()
    {
        _house.HasRoof = true;
        return this;
    }

    public IHouseBuilder BuildGarage()
    {
        _house.HasGarage = true;
        return this;
    }

    public IHouseBuilder BuildSwimmingPool()
    {
        _house.HasSwimmingPool = true;
        return this;
    }

    public IHouseBuilder BuildGarden(string type)
    {
        _house.GardenType = type;
        return this;
    }

    public House GetResult()
    {
        var result = _house;
        Reset();
        return result;
    }

    public void Reset() => _house = new House();
}
