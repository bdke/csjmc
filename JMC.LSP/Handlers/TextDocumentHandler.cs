using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Client.ClientCapabilities;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Server;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Server.Options;
using EmmyLua.LanguageServer.Framework.Protocol.Message.TextDocument;
using EmmyLua.LanguageServer.Framework.Protocol.Model.TextEdit;
using EmmyLua.LanguageServer.Framework.Server;
using EmmyLua.LanguageServer.Framework.Server.Handler;
using Microsoft.Extensions.Caching.Memory;

namespace JMC.LSP.Handlers;
internal sealed class TextDocumentHandler(LanguageServer server) : TextDocumentHandlerBase
{
    private readonly LanguageServer _server = server;
    public override void RegisterCapability(ServerCapabilities serverCapabilities, ClientCapabilities clientCapabilities)
    {
        serverCapabilities.TextDocumentSync = new TextDocumentSyncOptions
        {
            Change = TextDocumentSyncKind.Full,
            OpenClose = true,
            WillSave = true,
            WillSaveWaitUntil = true,
            Save = true
        };
    }

    protected override async Task Handle(DidOpenTextDocumentParams request, CancellationToken token)
    {
        var textDoc = request.TextDocument;
        if (ServerDocument.IsCreated(textDoc.Uri))
        {
            return;
        }
        var doc = await ServerDocument.AddDocumentAsync(textDoc.Uri, textDoc.Text, textDoc.LanguageId);
        Log.Debug($"TextDocumentHandler: DidOpenTextDocument {doc.Uri}");
    }

    protected override Task Handle(DidChangeTextDocumentParams request, CancellationToken token)
    {
        Log.Debug($"TextDocumentHandler: DidChangeTextDocument {request.TextDocument.Uri}");
        return Task.CompletedTask;
    }

    protected override Task Handle(DidCloseTextDocumentParams request, CancellationToken token)
    {
        Log.Debug($"TextDocumentHandler: DidCloseTextDocument {request.TextDocument.Uri}");
        return Task.CompletedTask;
    }

    protected override Task Handle(WillSaveTextDocumentParams request, CancellationToken token)
    {
        Log.Debug($"TextDocumentHandler: WillSaveTextDocument {request.TextDocument.Uri}");
        return Task.CompletedTask;
    }

    protected override Task<List<TextEdit>?> HandleRequest(WillSaveTextDocumentParams request, CancellationToken token)
    {
        Log.Debug($"TextDocumentHandler: WillSaveTextDocumentRequest {request.TextDocument.Uri}");
        return Task.FromResult<List<TextEdit>?>(null);
    }
}
