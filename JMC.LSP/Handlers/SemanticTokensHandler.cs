using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Client.ClientCapabilities;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Common;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Server;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Server.Options;
using EmmyLua.LanguageServer.Framework.Protocol.Message.SemanticToken;
using EmmyLua.LanguageServer.Framework.Server.Handler;
using JMC.Parser;
using System.Collections.Immutable;

namespace JMC.LSP.Handlers;
internal class SemanticTokensHandler : SemanticTokensHandlerBase
{
    private static readonly ImmutableArray<string> Types = 
    [
        SemanticTokenTypes.Keyword, SemanticTokenTypes.Property, SemanticTokenTypes.Variable, SemanticTokenTypes.Method,
    ];
    private static readonly ImmutableArray<string> Modifiers =
    [
    ];

    private static string GetSemanticType(TokenType type) => type switch
    {
        TokenType.Identifier => SemanticTokenTypes.Property,
        _ => SemanticTokenTypes.Method
    };

    public override void RegisterCapability(ServerCapabilities serverCapabilities, ClientCapabilities clientCapabilities)
    {
        serverCapabilities.SemanticTokensProvider = new SemanticTokensOptions()
        {
            Legend = new SemanticTokensLegend()
            {
                TokenTypes = [.. Types],
                TokenModifiers = [.. Modifiers],
            },
            Full = true,
            //Range = true,
        };
    }

    protected override async Task<SemanticTokens?> Handle(
        SemanticTokensParams semanticTokensParams, 
        CancellationToken cancellationToken)
    {
        var builder = new SemanticTokensBuilder([..Types], [..Modifiers]);
        var tokens = new SemanticTokens();

        var doc = await ServerDocument.GetDocumentAsync(semanticTokensParams.TextDocument.Uri) ?? throw new NullReferenceException();
        var text = doc.Text;
        var error = JMCParser.TryGenerateTokens(text, out var parsedTokens);
        if (error != null || parsedTokens == null)
        {
            return null;
        }
        foreach (var parsedToken in parsedTokens)
        {
            var semanticType = GetSemanticType(parsedToken.TokenID);
            Position pos = parsedToken.Position;
            builder.Push(pos, parsedToken.Value.Length, semanticType);
        }

        tokens.Data = builder.Build();
        return tokens;
    }

    protected override async Task<SemanticTokensDeltaResponse?> Handle(
        SemanticTokensDeltaParams semanticTokensDeltaParams,
        CancellationToken cancellationToken)
    {
        var builder = new SemanticTokensBuilder([.. Types], [.. Modifiers]);
        var tokens = new SemanticTokens();

        var doc = await ServerDocument.GetDocumentAsync(semanticTokensDeltaParams.TextDocument.Uri);

        tokens.Data = builder.Build();
        return tokens;
    }

    protected override async Task<SemanticTokens?> Handle(
        SemanticTokensRangeParams semanticTokensRangeParams, 
        CancellationToken cancellationToken)
    {
        var builder = new SemanticTokensBuilder([.. Types], [.. Modifiers]);
        var tokens = new SemanticTokens();

        var doc = await ServerDocument.GetDocumentAsync(semanticTokensRangeParams.TextDocument.Uri);

        tokens.Data = builder.Build();
        return tokens;
    }
}
