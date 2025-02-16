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

    public static async Task<JsonDocument?> GetCommandRegions(RequestMessage? msg, CancellationToken token)
    {
        var jsonMsg = JsonSerializer.Serialize(msg?.Params);
        var query = msg?.Params?.Deserialize<FileQueryData>() ?? null;
        if (query == null)
        {
            Log.Error($"Invalid Request: {jsonMsg}");
            return null;
        }
        var doc = await ServerDocument.GetDocumentAsync(query.Uri);
        if (doc == null)
        {
            Log.Error($"Document does not exist: {query.Uri}");
            return null;
        }
        if (doc is not JMCDocument jmcDoc)
        {
            Log.Error($"Invalid Document Type: {doc.GetType().Name}");
            return null;
        }
        if (!jmcDoc.ParseResult.HasValue || jmcDoc.ParseResult.Value.Instance == null)
        {
            Log.Error($"Document is not parsed: {query.Uri}");
            return null;
        }
        var result = jmcDoc.ParseResult.Value;
        var instance = result.Instance;
        return JsonSerializer.SerializeToDocument(instance.FileDetail.CommandRanges);
    }
}
