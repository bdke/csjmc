using Antlr4.Runtime.Misc;
using JMC.Parser.grammars;

namespace JMC.Parser;
public sealed class JMCVisitor : JMCParserBaseVisitor<object?>
{
    public List<string> Variables { get; } = [];

    public override object? VisitAssignment([NotNull] JMCParser.AssignmentContext context)
    {
        if (context.VARIABLE_IDENTIFIER() is { } variableIdentifier)
        {
            var name = variableIdentifier.GetText();
            Variables.Add(name);
        }
        return null;
    }

    public override object? VisitConstant([NotNull] JMCParser.ConstantContext context)
    {
        if (context.INTEGER() is { })
            return int.Parse(context.INTEGER().GetText());
        if (context.FLOAT() is { })
            return float.Parse(context.FLOAT().GetText());
        if (context.STRING() is { })
            return context.STRING().GetText()[1..^1];
        if (context.BOOL() is { })
            return context.BOOL().GetText() == "true";
        if (context.NULL() is { })
            return null;
        throw new NotImplementedException();
    }
}
