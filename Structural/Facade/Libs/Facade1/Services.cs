namespace Facade1;

public class AudioSystem(TextWriter? output = null) : ServiceBase(output)
{
    public void PlayMusic(string song) => _output.WriteLine($"Playing '{song}'");
    public void StopMusic() => _output.WriteLine("Music stopped");
    public void SetVolume(int level) => _output.WriteLine($"Volume set to {level}%");
}

public class CoffeeMachine(TextWriter? output = null) : ServiceBase(output)
{
    public void MakeCoffee() => _output.WriteLine("Making coffee...");
    public void Clean() => _output.WriteLine("Cleaning coffee machine");
    public void FillWater() => _output.WriteLine("Filling water tank");
    public void SleepMode() => _output.WriteLine("Coffee machine in sleep mode");
}

public class SmartLight(TextWriter? output = null) : ServiceBase(output)
{
    public void TurnOn() => _output.WriteLine("Lights on");
    public void TurnOff() => _output.WriteLine("Lights off");
    public void SetBrightness(int percent) => _output.WriteLine($"Brightness set to {percent}%");
    public void SetColor(string color) => _output.WriteLine($"Light color set to {color}");
}

public class SmartThermostat(TextWriter? output = null) : ServiceBase(output)
{
    public void SetTemperature(int temp) => _output.WriteLine($"Temperature set to {temp}°C");
    public void TurnOff() => _output.WriteLine("Thermostat off");
    public void EnergySavingMode() => _output.WriteLine("Energy saving mode activated");
}
