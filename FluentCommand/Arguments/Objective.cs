namespace FluentCommand.Arguments;
public sealed class Objective(string obj) : BaseArgument
{
    public override string Value => obj;
    internal override bool IsValidValue => !obj.Any(char.IsWhiteSpace) || (obj.StartsWith('"') && obj.EndsWith('"'));
}
