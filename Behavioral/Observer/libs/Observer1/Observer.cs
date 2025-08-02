namespace Observer1;

public class Observer : IObserver<WeatherDataModel>, IDisposable
{
    private readonly ISubject<WeatherDataModel> _subject;
    private readonly TextWriter _output;

    public Observer(ISubject<WeatherDataModel> subject, TextWriter? output = null)
    {
        _subject = subject;
        _output = output ?? Console.Out;
        _subject.RegisterObserver(this);
    }

    public void Update(WeatherDataModel data)
    {
        _output.WriteLine($"Current conditions : {data.Temp}°C and {data.Humidity}% humidity");
    }

    public void Dispose()
    {
        _subject.RemoveObserver(this);
    }
}
