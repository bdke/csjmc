namespace JMC.Parser.Command.Argument;

[AttributeUsage(AttributeTargets.Class)]
internal class ArgumentIdentifierAttribute(string identifier) : Attribute
{
    public string Identifier { get; set; } = identifier;
}