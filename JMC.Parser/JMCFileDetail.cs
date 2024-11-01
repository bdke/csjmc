namespace JMC.Parser;

public readonly struct JMCFileDetail()
{
    public readonly HashSet<string> Variables { get; } = [];

    public void Reset()
    {
        Variables.Clear();
    }
}