using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Client.ClientCapabilities;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Server;
using EmmyLua.LanguageServer.Framework.Protocol.Message.Completion;
using EmmyLua.LanguageServer.Framework.Server.Handler;
using JMC.LSP.Types;
using System.Collections.Immutable;

namespace JMC.LSP.Handlers;
internal sealed class CompletionHandler : CompletionHandlerBase
{
    private static readonly ImmutableArray<string> _keywords = ["command", "function", "import", "new", "null", "code", "class", "using", "if", "else", "while", "do", "switch", "true", "false"];

    public override void RegisterCapability(ServerCapabilities serverCapabilities, ClientCapabilities clientCapabilities)
    {
        serverCapabilities.CompletionProvider = new()
        {
            TriggerCharacters = [" ", ",", "$"],
            ResolveProvider = true,
            CompletionItem = new()
            {
                LabelDetailsSupport = true,
            },
        };
    }

    protected override async Task<CompletionResponse?> Handle(CompletionParams request, CancellationToken token)
    {
        var textDoc = request.TextDocument;
        var doc = await ServerDocument.GetDocumentAsync(textDoc.Uri);

        var completionList = new CompletionList
        {
            Items = _keywords.Select(v => new CompletionItem()
            {
                Label = v,
                InsertText = v,
                Kind = CompletionItemKind.Keyword,
            }).ToList()
        };
        if (doc is JMCDocument jmcDoc)
        {
            var jmcHandleResult = HandleJMCDocument(jmcDoc, request);
            await foreach (var item in jmcHandleResult)
            {
                completionList.Items.Add(item);
            }
            var target = jmcDoc.GetToken(request.Position);
            return new(completionList);
        }
        throw new NotSupportedException();
    }

    public async IAsyncEnumerable<CompletionItem> HandleJMCDocument(JMCDocument doc, CompletionParams request)
    {
        var triggerChar = request.Context.TriggerCharacter;
        var triggerKind = request.Context.TriggerKind;
        if (triggerChar == "$")
        {

        }
        yield break;
    }

    protected override Task<CompletionItem> Resolve(CompletionItem item, CancellationToken token)
    {
        return Task.FromResult(item);
    }
}
