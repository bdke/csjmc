using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Client.ClientCapabilities;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Server;
using EmmyLua.LanguageServer.Framework.Protocol.Message.DocumentDiagnostic;
using EmmyLua.LanguageServer.Framework.Protocol.Model.Diagnostic;
using EmmyLua.LanguageServer.Framework.Server;
using EmmyLua.LanguageServer.Framework.Server.Handler;
using JMC.LSP.Types;
using JMC.Parser;
using Spectre.Console;
using System.Text.Json;

namespace JMC.LSP.Handlers;
internal sealed class DocumentDiagnosticHandler(LanguageServer server) : DocumentDiagnosticHandlerBase
{
    private readonly LanguageServer _server = server;
    public override void RegisterCapability(ServerCapabilities serverCapabilities, ClientCapabilities clientCapabilities)
    {
        serverCapabilities.TextDocument = new()
        {
            Diagnostic = new()
            {
                MarkupMessageSupport = clientCapabilities.TextDocument?.Diagnostic?.MarkupMessageSupport ?? false
            }
        };
        serverCapabilities.DiagnosticProvider = new()
        {
            Identifier = ServerDocument.JMC,
            WorkspaceDiagnostics = true,
            InterFileDependencies = true,
        };
    }

    protected override async Task<DocumentDiagnosticReport> Handle(DocumentDiagnosticParams request, CancellationToken token)
    {
        var textDoc = request.TextDocument;
        var doc = await ServerDocument.GetDocumentAsync(textDoc.Uri);
        var unixTimeId = DateTime.Now.ToBinary().ToString();
        var docDiag = new RelatedFullDocumentDiagnosticReport()
        {
            Diagnostics = [],
            ResultId = unixTimeId,
            RelatedDocuments = []
        };
        if (doc is JMCDocument jmcDoc && jmcDoc.ParseResult.HasValue)
        {
            var parseResult = jmcDoc.ParseResult.Value;

            if (parseResult.Errors.IsEmpty)
            {
                return docDiag;
            }

            foreach (var error in parseResult.Errors)
            {
                var pos = new Position(error.Line, error.Column);
                var jmcToken = jmcDoc.GetToken(pos) ?? throw new NullReferenceException();
                var diag = new Diagnostic()
                {
                    Range = jmcToken.Item2,
                    Severity = DiagnosticSeverity.Error,
                    Message = error.ErrorMessage,
                    Source = ServerDocument.JMC,
                    
                };
                docDiag.Diagnostics.Add(diag);
            }
        }
        return docDiag;
    }
}
