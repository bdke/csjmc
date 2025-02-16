using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Client.ClientCapabilities;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Server;
using EmmyLua.LanguageServer.Framework.Protocol.Message.Completion;
using EmmyLua.LanguageServer.Framework.Server.Handler;
using JMC.LSP.Types;
using System.Collections.Immutable;

namespace JMC.LSP.Handlers;
internal sealed class CompletionHandler : CompletionHandlerBase
{
    private static readonly ImmutableArray<string> KEYWORDS = ["command", "function", "import", "new", "null", "code", "class", "using", "if", "else", "while", "do", "switch", "true", "false"];
    private static readonly ImmutableArray<string> COMPLETETION_TRIGGERS = [" ", ",", "$"];

    public override void RegisterCapability(ServerCapabilities serverCapabilities, ClientCapabilities clientCapabilities)
    {
        serverCapabilities.CompletionProvider = new()
        {
            TriggerCharacters = [.. COMPLETETION_TRIGGERS],
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
            // do not provide keywords for trigger characters
            Items = COMPLETETION_TRIGGERS.Contains(request.Context.TriggerCharacter ?? string.Empty) 
            ? KEYWORDS.Select(static v => new CompletionItem()
            {
                Label = v,
                InsertText = v,
                Kind = CompletionItemKind.Keyword,
            }).ToList()
            : []
        };
        if (doc is JMCDocument jmcDoc)
        {
            var jmcHandleResult = HandleJMCDocumentCompletion(jmcDoc, request);
            foreach (var item in jmcHandleResult)
            {
                completionList.Items.Add(item);
            }
            var target = jmcDoc.GetToken(request.Position);
            return new(completionList);
        }
        throw new NotSupportedException();
    }

    public IEnumerable<CompletionItem> HandleJMCDocumentCompletion(JMCDocument doc, CompletionParams request)
    {
        var triggerChar = request.Context.TriggerCharacter;
        var triggerKind = request.Context.TriggerKind;
        if (triggerChar == "$")
        {
            //TODO
        }
        yield break;
    }

    protected override Task<CompletionItem> Resolve(CompletionItem item, CancellationToken token)
    {
        return Task.FromResult(item);
    }
}
