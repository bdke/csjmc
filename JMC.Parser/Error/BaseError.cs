namespace JMC.Parser.Error;
public abstract class BaseError(string message)
{
    public string Message { get; set; } = message;
}
