namespace Command1.Receivers;

public enum CeilingFanLevel
{
    Off,
    Low,
    Medium,
    High
}

public class CeilingFan(TextWriter? output, string location, CeilingFanLevel level = CeilingFanLevel.Off) : ReceiverBase(output)
{
    public CeilingFanLevel Level { get; set; } = level;

    public void Run()
    {
        _output.WriteLine($"CeilingFan in {location} {(Level == CeilingFanLevel.Off ? "doesn't work" : $"works on {Level} level")}");
    }
}
