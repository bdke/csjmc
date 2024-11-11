namespace JMC.Parser;

public readonly struct JMCFileDetail()
{
    public readonly HashSet<string> ScoreboardVariables { get; } = [];

    public void Reset()
    {
        ScoreboardVariables.Clear();
    }
}