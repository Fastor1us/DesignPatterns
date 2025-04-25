using Observer2.Interfaces;
using Observer2.Models;

namespace Observer2.Observers;

public class CurrentConditionsDisplay(TextWriter? output = null) : IObserver<WeatherDataModel>, IDisplayElement
{
    private readonly TextWriter _output = output ?? Console.Out;
    private WeatherDataModel? _weatherData;

    public void OnNext(WeatherDataModel value)
    {
        _weatherData = value;
        Display();
    }

    public void OnError(Exception error)
    {
        _output.WriteLine($"Error occured while {this.GetType().Name} was obreving: {error.Message}");
    }

    public void Display()
    {
        _output.WriteLine($"Current conditions: {_weatherData!.Temp}°C and {_weatherData.Humidity}% humidity");
    }

    public void OnCompleted()
    {
        //
    }
}
