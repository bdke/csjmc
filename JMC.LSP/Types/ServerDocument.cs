using EmmyLua.LanguageServer.Framework.Protocol.Model;
using Microsoft.Extensions.Caching.Memory;
using sly.lexer;

namespace JMC.LSP.Types;
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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="uri"></param>
    /// <param name="text"></param>
    /// <param name="documentType"></param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException"></exception>
    /// <exception cref="InvalidDataException"></exception>
    public static async Task<IServerDocument> AddDocumentAsync(DocumentUri uri, string text, string documentType)
    {
        DocumentType type = ToDocumentType(documentType);
        return type switch
        {
            DocumentType.Code => await AddCodeDocumentAsync(uri, text),
            _ => throw new NotSupportedException(),
        };
    }

    public static Task RemoveDocumentAsync(DocumentUri uri)
    {
        return Task.Run(() => _cache.Remove(uri));
    }

    public static Task<IServerDocument?> GetDocumentAsync(DocumentUri uri)
    {
        return Task.FromResult(_cache.Get<IServerDocument>(uri));
    }

    public static async Task<T> UpdateDocumentAsync<T>(DocumentUri uri, T document) where T : IServerDocument
    {
        await RemoveDocumentAsync(uri);
        return await _cache.GetOrCreateAsync(uri, (e) => Task.FromResult(document)) ?? throw new NullReferenceException();
    }

    public static async Task<JMCDocument> AddCodeDocumentAsync(
        DocumentUri uri, 
        string text, 
        TokenChannels<Parser.TokenType>? channels = null)
    {
        return await _cache.GetOrCreateAsync(uri, (e) =>
        {
            JMCDocument doc = new()
            {
                Uri = uri,
                Text = text,
                TokenChannels = channels
            };
            return Task.FromResult(doc);
        });
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="documentType"></param>
    /// <returns></returns>
    /// <exception cref="InvalidDataException"></exception>
    private static DocumentType ToDocumentType(string documentType)
    {
        return documentType switch
        {
            "jmc" => DocumentType.Code,
            _ => throw new InvalidDataException($"Invalid document type '{documentType}'")
        };
    }
}
