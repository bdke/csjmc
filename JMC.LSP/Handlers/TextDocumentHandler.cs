using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Client.ClientCapabilities;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Server;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Server.Options;
using EmmyLua.LanguageServer.Framework.Protocol.Message.TextDocument;
using EmmyLua.LanguageServer.Framework.Protocol.Model.TextEdit;
using EmmyLua.LanguageServer.Framework.Server;
using EmmyLua.LanguageServer.Framework.Server.Handler;
using JMC.LSP.Types;
using System.Diagnostics;

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
            Save = true,
        };
    }

    protected override async Task Handle(DidOpenTextDocumentParams request, CancellationToken token)
    {
        var textDoc = request.TextDocument;
        if (ServerDocument.IsCreated(textDoc.Uri))
        {
            return;
        }

        try
        {
            if (textDoc.LanguageId is not (ServerDocument.JMC or ServerDocument.HJMC))
            {
                throw new NotSupportedException("Unsupport file types");
            }

            var doc = textDoc.LanguageId == ServerDocument.JMC
                ? await ServerDocument.AddCodeDocumentAsync(textDoc.Uri, textDoc.Text, true)
                : await ServerDocument.AddHeaderDocumentAsync(textDoc.Uri, textDoc.Text);
            Log.Debug($"TextDocumentHandler: DidOpenTextDocument {doc.Uri}");
        }
        catch (NotSupportedException ex)
        {
            Log.Error(ex, "File NotSupported");
#if DEBUG
            Debugger.BreakForUserUnhandledException(ex); 
#endif
        }
        catch (InvalidDataException ex)
        {
            Log.Fatal(ex, "Invalid Data");
#if DEBUG 
            Debugger.BreakForUserUnhandledException(ex);
#endif
        }
    }

    protected override async Task Handle(DidChangeTextDocumentParams request, CancellationToken token)
    {
        var textDoc = request.TextDocument;
        var doc = await ServerDocument.GetDocumentAsync(textDoc.Uri) ?? throw new NullReferenceException();
        doc.Text = request.ContentChanges.First().Text;
        if (doc is JMCDocument jmcDoc)
        {
            jmcDoc.ParseResult = ServerDocument.GenerateJMCSymbols(doc.Text, out var tokenChannels);
            jmcDoc.TokenChannels = tokenChannels;
            await ServerDocument.UpdateDocumentAsync(jmcDoc);
        }
        Log.Debug($"TextDocumentHandler: DidChangeTextDocument {textDoc.Uri}");
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
