namespace Builder1;

public class House
{
    public int Walls { get; set; }
    public int Doors { get; set; }
    public int Windows { get; set; }
    public bool HasRoof { get; set; }
    public bool HasGarage { get; set; }
    public bool HasSwimmingPool { get; set; }
    public string? GardenType { get; set; }

    public override string ToString()
        => $"The House with: {Walls} walls, {Doors} doors, {Windows} windows, " +
           $"{(HasRoof ? "with" : "without")} roof, " +
           $"{(HasGarage ? "with" : "without")} garage, " +
           $"{(HasSwimmingPool ? "with" : "without")} swimming pool, " +
           $"{(GardenType != null ? $"with {GardenType} garden" : "without garden")}";
}
