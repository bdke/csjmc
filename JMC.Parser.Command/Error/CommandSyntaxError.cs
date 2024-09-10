namespace JMC.Parser.Command.Error;

public class CommandSyntaxError : BaseError
{
    public CommandSyntaxError(string message = "") : base(message)
    {
    }
}