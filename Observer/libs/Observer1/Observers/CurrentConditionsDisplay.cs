using Observer1.Interfaces;
using Observer1.Models;

namespace Observer1.Observers;

public class CurrentConditionsDisplay : Interfaces.IObserver<WeatherDataModel>, IDisplayElement, IDisposable
{
    private readonly ISubject<WeatherDataModel> _subject;
    private readonly TextWriter _output;
    private float _temperature;
    private float _humidity;

    public CurrentConditionsDisplay(ISubject<WeatherDataModel> subject, TextWriter? output = null)
    {
        _subject = subject;
        _output = output ?? Console.Out;
        _subject.RegisterObserver(this);
    }

    public void Update(WeatherDataModel data)
    {
        this._temperature = data.Temp;
        this._humidity = data.Humidity;
        Display();
    }

    public void Display()
    {
        _output.WriteLine($"Current conditions : {_temperature}°C and {_humidity}% humidity");
    }

    public void Dispose()
    {
        _subject.RemoveObserver(this);
    }
}
