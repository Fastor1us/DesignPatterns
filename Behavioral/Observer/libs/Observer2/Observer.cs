namespace Observer2;

public class Observer(TextWriter? output = null) : IObserver<WeatherDataModel>
{
    private readonly TextWriter _output = output ?? Console.Out;

    public void OnNext(WeatherDataModel value)
    {
        _output.WriteLine($"Current conditions: {value!.Temp}°C and {value.Humidity}% humidity");
    }

    public void OnError(Exception error)
    {
        _output.WriteLine($"Error occured while {GetType().Name} was obreving: {error.Message}");
    }

    public void OnCompleted()
    {
        //
    }
}
