using CommunityToolkit.HighPerformance;

namespace JMC.Parser.Models;

public struct StatementParseResult
{
    public readonly bool IsAllMatch => Accuracy == 1;
    public SyntaxParseResult[] IndividualResults { get; set; }
    public readonly double Accuracy => IndividualResults.Count(v => v.IsMatch) / (double)IndividualResults.Length;
}
