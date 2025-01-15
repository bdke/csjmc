using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Client.ClientCapabilities;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Common;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Server;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Server.Options;
using EmmyLua.LanguageServer.Framework.Protocol.Message.SemanticToken;
using EmmyLua.LanguageServer.Framework.Server.Handler;
using JMC.LSP.Types;
using JMC.Parser;
using JMC.Shared.Helpers;
using sly.lexer;
using System.Collections.Immutable;

namespace JMC.LSP.Handlers;
internal class SemanticTokensHandler : SemanticTokensHandlerBase
{
    private static readonly ImmutableArray<string> TYPES =
    [
        SemanticTokenTypes.Keyword, SemanticTokenTypes.Variable, SemanticTokenTypes.Method, SemanticTokenTypes.Comment,
        SemanticTokenTypes.Number, SemanticTokenTypes.Operator
    ];
    private static readonly ImmutableArray<string> MODIFIERS =
    [
        SemanticTokenModifiers.Readonly
    ];
    private static readonly ImmutableArray<TokenType> OPERATORS = 
    [
        TokenType.Assign, TokenType.BooleanAssign, TokenType.CompareAssign, TokenType.DivideAssign, 
        TokenType.MinusAssign, TokenType.MultiplyAssign, TokenType.NullColesleAssign, TokenType.PlusAssign,
        TokenType.RemainderAssign
    ];

    private static (string, string[]) GetSemanticType(TokenType type)
    {
        (string, string[]) tResult = type switch
        {
            TokenType.DollarSign => (SemanticTokenTypes.Variable, []),
            TokenType.Identifier => (SemanticTokenTypes.Variable, [SemanticTokenModifiers.Readonly]),
            TokenType.Int or TokenType.Double => (SemanticTokenTypes.Number, []),
            _ => (string.Empty, [])
        };
        if (string.IsNullOrEmpty(tResult.Item1) && OPERATORS.Contains(type))
        {
            return (SemanticTokenTypes.Operator, []);
        }
        return tResult;
    }

    public override void RegisterCapability(ServerCapabilities serverCapabilities, ClientCapabilities clientCapabilities)
    {
        serverCapabilities.SemanticTokensProvider = new SemanticTokensOptions()
        {
            Legend = new SemanticTokensLegend()
            {
                TokenTypes = [.. TYPES],
                TokenModifiers = [.. MODIFIERS],
            },
            Full = true,
            //Range = true,
        };
    }

    protected override async Task<SemanticTokens?> Handle(
        SemanticTokensParams semanticTokensParams,
        CancellationToken cancellationToken)
    {
        SemanticTokensBuilder builder = new([.. TYPES], [.. MODIFIERS]);
        SemanticTokens tokens = new();

        Types.IServerDocument doc = await ServerDocument.GetDocumentAsync(semanticTokensParams.TextDocument.Uri)
            ?? throw new NullReferenceException();
        string text = doc.Text;
        LexicalError? error = JMCParser.TryGenerateTokens(text, out TokenChannels<TokenType>? tokenChannels);
        if (error != null || tokenChannels == null)
        {
            return null;
        }
        ImmutableArray<Token<TokenType>> mainChannelTokens = tokenChannels
            .MainTokens().FilterNullValues()
            .ToImmutableArray();
        for (int i = 0; i < mainChannelTokens.Length; i++)
        {
            Token<TokenType> parsedToken = mainChannelTokens[i];
            if (i - 1 < 0)
            {
                goto defaultHandle;
            }

            if (parsedToken.TokenID == TokenType.Identifier &&
                mainChannelTokens[i - 1].TokenID == TokenType.DollarSign)
            {
                builder.Push((Position)parsedToken.Position, parsedToken.Value.Length, SemanticTokenTypes.Variable);
                continue;
            }
            goto defaultHandle;

        defaultHandle:
            (string, string[]) semanticType = GetSemanticType(parsedToken.TokenID);
            Position pos = parsedToken.Position;
            if (!string.IsNullOrEmpty(semanticType.Item1))
            {
                builder.Push(pos, parsedToken.Value.Length, semanticType.Item1, [.. semanticType.Item2]);
            }
        }

        tokens.Data = builder.Build();
        return tokens;
    }

    protected override Task<SemanticTokensDeltaResponse?> Handle(
        SemanticTokensDeltaParams semanticTokensDeltaParams,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    protected override Task<SemanticTokens?> Handle(
        SemanticTokensRangeParams semanticTokensRangeParams,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
