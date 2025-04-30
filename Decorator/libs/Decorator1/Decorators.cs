namespace Decorator1;

public class UpperCaseTextWriter(TextWriter tw) : CaseConverterTextWriter(tw)
{
    protected override char ProcessChar(char c) => char.ToUpper(c);
    protected override string ProcessString(string s) => s.ToUpper();
}

public class LowerCaseTextWriter(TextWriter tw) : CaseConverterTextWriter(tw)
{
    protected override char ProcessChar(char c) => char.ToLower(c);
    protected override string ProcessString(string s) => s.ToLower();
}
