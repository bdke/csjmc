using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Client.ClientCapabilities;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Server;
using EmmyLua.LanguageServer.Framework.Protocol.Message.DocumentDiagnostic;
using EmmyLua.LanguageServer.Framework.Protocol.Model.Diagnostic;
using EmmyLua.LanguageServer.Framework.Server;
using EmmyLua.LanguageServer.Framework.Server.Handler;
using EmmyLua.LanguageServer.Framework.Protocol.Model;
using EmmyLua.LanguageServer.Framework.Protocol.Model.TextDocument;
using JMC.LSP.Types;
using JMC.Parser;
using sly.lexer;
using sly.parser;
using Position = JMC.Parser.Position;
using System.Collections.Immutable;
using System.Collections;

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
        TextDocumentIdentifier textDoc = request.TextDocument;
        IServerDocument? doc = await ServerDocument.GetDocumentAsync(textDoc.Uri);
        string unixTimeId = DateTime.Now.ToBinary().ToString();
        RelatedFullDocumentDiagnosticReport docDiag = new()
        {
            Diagnostics = [],
            ResultId = unixTimeId,
            RelatedDocuments = []
        };
        if (doc is JMCDocument jmcDoc)
        {
            docDiag.Diagnostics.AddRange(HandleJMCDiagnostic(jmcDoc));
        }
        return docDiag;
    }

    private static IEnumerable<Diagnostic> HandleJMCDiagnostic(JMCDocument jmcDoc)
    {
        if (!jmcDoc.ParseResult.HasValue)
        {
            yield break;
        }
        JMCParser.ParseResult parseResult = jmcDoc.ParseResult.Value;
        if (parseResult.Errors.IsEmpty)
        {
            yield break;
        }
        ImmutableArray<ParseError> errors = parseResult.Errors;

        // not doing this would cause whole file throw errors, probably things on the lib
        if (errors.Last().ErrorType == ErrorType.UnexpectedEOS)
        {
            ParseError eosErr = errors.Last();
            Position pos = new(eosErr.Line, eosErr.Column);
            var jmcToken = jmcDoc.GetToken(pos) ?? throw new NullReferenceException();
            yield return new()
            {
                Range = jmcToken.Value,
                Severity = DiagnosticSeverity.Error,
                Message = eosErr.ErrorMessage,
                Source = ServerDocument.JMC
            };
            yield break;
        }

        foreach (ParseError error in errors)
        {
            Position pos = new(error.Line, error.Column);
            var jmcToken = jmcDoc.GetToken(pos) ?? throw new NullReferenceException();
            Diagnostic diag = new()
            {
                Range = jmcToken.Value,
                Severity = DiagnosticSeverity.Error,
                Message = error.ErrorMessage,
                Source = ServerDocument.JMC,

            };
            yield return diag;
        }
    }
}
