using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Client.ClientCapabilities;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Server;
using EmmyLua.LanguageServer.Framework.Protocol.Message.WorkspaceDiagnostic;
using EmmyLua.LanguageServer.Framework.Server.Handler;

namespace JMC.LSP.Handlers;
internal sealed class WorkspaceDiagnosticHandler : WorkspaceDiagnosticHandlerBase
{
    public override void RegisterCapability(ServerCapabilities serverCapabilities, ClientCapabilities clientCapabilities)
    {
    }

    protected override async Task<WorkspaceDiagnosticReport> Handle(WorkspaceDiagnosticParams request, CancellationToken token)
    {
        return new()
        {
            Items = []
        };
    }
}
