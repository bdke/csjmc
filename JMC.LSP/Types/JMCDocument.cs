using EmmyLua.LanguageServer.Framework.Protocol.Model;
using JMC.LSP.Helpers;
using JMC.Parser;
using sly.lexer;
using System.Collections.Immutable;

namespace JMC.LSP.Types;
internal struct JMCDocument : IServerDocument
{
    public DocumentUri Uri { get; set; }
    public string Text { get; set; }
    public TokenChannels<TokenType>? TokenChannels { get; set; }

    public readonly (Token<TokenType>, DocumentRange)? GetToken(Parser.Position position)
    {
        if (TokenChannels == null)
        {
            return null;
        }

        var tokens = TokenChannels
            .MainTokens()
            .ToImmutableArray()
            .AsSpan();
        for (int i = 0; i < tokens.Length - 1; i++)
        {
            var token = tokens[i];
            var nextToken = tokens[i + 1];
            Parser.Position pos = token.Position;
            Parser.Position nextPos = nextToken.Position;
            var range = pos.Join(nextPos);
            if (range.Contains(position))
            {
                return (token, range);
            }
        }
        var lastValidToken = tokens[^2];
        var lastTokenPos = (Parser.Position)lastValidToken.Position;
        return (lastValidToken, new(lastTokenPos, new(-1, -1)));
    }
}
