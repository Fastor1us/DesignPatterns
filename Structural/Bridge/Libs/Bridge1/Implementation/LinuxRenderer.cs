namespace Bridge1.Implementation;

public class LinuxRenderer : IPlatformRenderer
{
    public void RenderButton(string text)
    {
        Console.WriteLine($"Linux button: \u29BF {text} \u29C0 (LinuxAPI)");
    }

    public void RenderCheckbox(bool isChecked)
    {
        Console.WriteLine($"Linux checkbox: {(isChecked ? "☑️" : "⬜")} (LinuxAPI)");
    }
}
