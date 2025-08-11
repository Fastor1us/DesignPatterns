namespace Bridge1.Implementation;

public class WindowsRenderer : IPlatformRenderer
{
    public void RenderButton(string text)
    {
        Console.WriteLine($"Windows button: [{text}] (WinAPI)");
    }

    public void RenderCheckbox(bool isChecked)
    {
        Console.WriteLine($"Windows checkbox: {(isChecked ? "[✓]" : "[ ]")} (WinAPI)");
    }
}
