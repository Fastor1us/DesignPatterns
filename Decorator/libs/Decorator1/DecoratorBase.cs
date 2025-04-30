namespace Decorator1;

using System.Text;

public abstract class CaseConverterTextWriter(TextWriter tw) : TextWriter
{
    public override Encoding Encoding => tw.Encoding;

    public override void Write(char value)
        => tw.Write(ProcessChar(value));

    public override void Write(string? value)
        => tw.Write(ProcessString(value ?? string.Empty));

    public override void Flush() => tw.Flush();

    protected abstract char ProcessChar(char c);
    protected abstract string ProcessString(string s);
}
