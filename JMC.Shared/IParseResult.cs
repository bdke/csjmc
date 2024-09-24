namespace JMC.Shared;

public interface IParseResult
{
    public bool Succeed { get; protected set; }
}

public class ParseError(params BaseError[] errors) : IParseResult
{
    public BaseError[] Errors { get; set; } = errors;
    bool IParseResult.Succeed { get; set; } = false;
}