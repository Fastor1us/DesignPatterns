namespace Facade1;

public class SmartHomeFacade(TextWriter? output = null)
{
    private readonly SmartLight _light = new(output);
    private readonly SmartThermostat _thermostat = new(output);
    private readonly AudioSystem _audio = new(output);
    private readonly CoffeeMachine _coffeeMachine = new(output);

    public void StartMorningRoutine()
    {
        _light.TurnOn();
        _light.SetBrightness(70);
        _thermostat.SetTemperature(21);
        _coffeeMachine.FillWater();
        _coffeeMachine.MakeCoffee();
        _audio.PlayMusic("Morning Jazz");
        _audio.SetVolume(30);
    }

    public void StartEveningRelaxation()
    {
        _light.SetBrightness(40);
        _light.SetColor("Warm White");
        _thermostat.SetTemperature(22);
        _audio.PlayMusic("Chill Vibes");
        _audio.SetVolume(25);
        _coffeeMachine.Clean();
    }

    public void ActivateAwayMode()
    {
        _light.TurnOff();
        _thermostat.EnergySavingMode();
        _audio.StopMusic();
        _coffeeMachine.SleepMode();
    }

    public void StartEntertainmentMode()
    {
        _light.SetColor("Multicolor");
        _thermostat.SetTemperature(20);
        _audio.PlayMusic("Party Mix");
        _audio.SetVolume(60);
        _coffeeMachine.MakeCoffee();
    }
}
