namespace FluentCommand.Arguments;
public sealed class Keyword(string value) : BaseArgument
{
    public override string Value => value;

    internal override bool IsValidValue => !value.Any(char.IsWhiteSpace);
}
