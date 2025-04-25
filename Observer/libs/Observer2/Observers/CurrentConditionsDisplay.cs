using Observer2.Subjects;
using Observer2.Interfaces;
using Observer2.Models;

namespace Observer2.Observers;

public class CurrentConditionsDisplay : IObserver<WeatherDataModel>, IDisplayElement, IDisposable
{
    private readonly Subject<WeatherDataModel> _subject;
    private readonly TextWriter _output;
    private WeatherDataModel? _weatherData;

    public CurrentConditionsDisplay(Subject<WeatherDataModel> subject, TextWriter? output = null)
    {
        subject.Subscribe(this);
        _subject = subject;
        _output = output ?? Console.Out;
    }

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
        Dispose();
    }

    public void Dispose()
    {
        _subject.Unsubscribe(this);
        _output.WriteLine($"{this.GetType().Name} is Disposed");
    }
}
