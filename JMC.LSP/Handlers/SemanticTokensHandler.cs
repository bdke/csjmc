using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Client.ClientCapabilities;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Common;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Server;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Server.Options;
using EmmyLua.LanguageServer.Framework.Protocol.Message.SemanticToken;
using EmmyLua.LanguageServer.Framework.Server.Handler;
using System.Collections.Immutable;

namespace JMC.LSP.Handlers;
internal class SemanticTokensHandler : SemanticTokensHandlerBase
{
    private static readonly ImmutableArray<string> Types = 
    [
        SemanticTokenTypes.Keyword
    ];
    private static readonly ImmutableArray<string> Modifiers =
    [
    ];

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
            Range = true,
        };
    }

    protected override async Task<SemanticTokens?> Handle(
        SemanticTokensParams semanticTokensParams, 
        CancellationToken cancellationToken)
    {
        var builder = new SemanticTokensBuilder([..Types], [..Modifiers]);
        var tokens = new SemanticTokens();

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
