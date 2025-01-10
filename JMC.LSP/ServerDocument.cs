using EmmyLua.LanguageServer.Framework.Protocol.Model;
using JMC.LSP.Types;
using Microsoft.Extensions.Caching.Memory;

namespace JMC.LSP;
internal static class ServerDocument
{
    private enum DocumentType
    {
        Code, Header
    }

    private static readonly IMemoryCache _cache = LSPServices.MemoryCache;

    public static bool IsCreated(DocumentUri uri)
    {
        return _cache.TryGetValue(uri, out _);
    }

    public static async Task<IServerDocument> AddDocumentAsync(DocumentUri uri, string text, string documentType)
    {
        var type = ToDocumentType(documentType);
        return type switch
        {
            DocumentType.Code => await AddCodeDocumentAsync(uri, text),
            _ => throw new NotSupportedException(),
        };
    }

    private static async Task<JMCDocument> AddCodeDocumentAsync(DocumentUri uri, string text)
    {
        return await _cache.GetOrCreateAsync(uri, (e) =>
        {
            var doc = new JMCDocument()
            {
                Uri = uri,
                Text = text,
            };
            return Task.FromResult(doc);
        });
    }

    private static DocumentType ToDocumentType(string documentType) => documentType switch
    {
        "jmc" => DocumentType.Code,
        _ => throw new InvalidDataException($"Invalid document type '{documentType}'")
    };
}
