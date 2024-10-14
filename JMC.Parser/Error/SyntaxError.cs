namespace JMC.Parser.Error;
public sealed class SyntaxError(bool isMissing, string tokenName, int line, int column) : BaseError(GenerateMessage(isMissing, tokenName, line, column))
{
    private static string GenerateMessage(bool isMissing, string tokenName, int line, int column)
    {
        string position = $"{line};{column}";
        string missingMessage = isMissing ? "Missing" : "Mismatched";
        string message = $"{position}: {missingMessage} {tokenName}";
        return message;
    }
}
