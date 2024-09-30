using Antlr4.Runtime;
using Antlr4.Runtime.Misc;

namespace JMC.Parser;
public sealed class JMCErrorListener : BaseErrorListener
{
    public override void SyntaxError(
        [NotNull] IRecognizer recognizer, 
        [Nullable] IToken offendingSymbol, 
        int line, 
        int charPositionInLine, 
        [NotNull] string msg, 
        [Nullable] RecognitionException e)
    {
        Console.WriteLine($"{line}:{charPositionInLine} {msg}");
        base.SyntaxError(recognizer, offendingSymbol, line, charPositionInLine, msg, e);
    }
}
