using EmmyLua.LanguageServer.Framework.Protocol.JsonRpc;
using EmmyLua.LanguageServer.Framework.Server;
using JMC.LSP.Types;
using System.Text.Json;

namespace JMC.LSP.Handlers;
internal static class RequestHandler
{
    public static void RegisterAllRequestMethods(this LanguageServer server) 
    {
        server.AddRequestHandler("jmc/getCommandRegions", GetCommandRegions);
    }

    public static Task<JsonDocument?> GetCommandRegions(RequestMessage? msg, CancellationToken token)
    {
        return Task.FromResult<JsonDocument?>(null);
    }
}
