namespace Builder1;

public interface IHouseBuilder
{
    IHouseBuilder BuildWalls(int count);
    IHouseBuilder BuildDoors(int count);
    IHouseBuilder BuildWindows(int count);
    IHouseBuilder BuildRoof();
    IHouseBuilder BuildGarage();
    IHouseBuilder BuildSwimmingPool();
    IHouseBuilder BuildGarden(string type);
    House GetResult();
    void Reset();
}
