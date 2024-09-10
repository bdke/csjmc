namespace JMC.Parser.Command.Argument;

public class ArgumentTreeParseResult()
{
    public required Tuple<ArgumentNode?, ArgumentTreeParseResult?>? Previous { get; set; }
    public required IParseResult Result { get; set; }
    public required Tuple<ArgumentNode?, ArgumentTreeParseResult?>? Next { get; set; }
}

public class ArgumentNode
{
    public List<ArgumentNode> Children { get; private set; } = [];
    public required ArgumentPropties Properties { get; set; }
    public bool Executable { get; set; } = false;

    public ArgumentTreeParseResult Parse(string[] args, ArgumentTreeParseResult? previousResult = null)
    {
        BaseArgument argument = ArgumentTree.ParserToArgument(Properties);
        string[] parameters = args[..argument.ArgumentsLength] ?? args;
        string[] nextParameters = args[argument.ArgumentsLength..];
        IParseResult result = previousResult?.Result ?? argument.Parse(parameters);

        Tuple<ArgumentNode, ArgumentTreeParseResult>? parseResult = Children
            .Select(child => new Tuple<ArgumentNode, ArgumentTreeParseResult>(child, child.Parse(nextParameters, previousResult)))
            .FirstOrDefault(v => v.Item2.Result.Succeed);

        Tuple<ArgumentNode?, ArgumentTreeParseResult?>? previousParseResult = previousResult == null ? null : new Tuple<ArgumentNode?, ArgumentTreeParseResult?>(this, previousResult);
        if (Executable && nextParameters.Length == 0 && result.Succeed)
        {
            return new()
            {
                Previous = previousParseResult,
                Result = result,
                Next = null
            };
        }
        else if (parseResult != null)
        {
            ArgumentTreeParseResult currentResult = new()
            {
                Previous = previousParseResult,
                Result = result,
                Next = new(parseResult?.Item1, null)
            };
            currentResult.Next = new(parseResult?.Item1, parseResult?.Item2);
            return currentResult;
        }
        else
        {
            return new()
            {
                Previous = previousParseResult,
                Result = new ParseError(new CommandSyntaxError("invalid")),
                Next = null
            };
        }
    }
}