namespace JMC.Parser.Models;
internal interface IExpandableSyntax
{
    public abstract SyntaxTree GetTree(TokenData data);
}
