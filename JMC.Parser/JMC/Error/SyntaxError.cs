using JMC.Shared;

namespace JMC.Parser.JMC.Error;

public class SyntaxError(string message = "") : BaseError(message)
{
}