namespace AbstractFactory1.Cargo;

internal class BoxTruck : ICargo
{
    public string GetCargoType() => "Land container (truck)";
}
