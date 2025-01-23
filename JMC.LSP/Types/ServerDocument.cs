using EmmyLua.LanguageServer.Framework.Protocol.Model;
using JMC.Parser;
using Microsoft.Extensions.Caching.Memory;
using sly.lexer;
using sly.parser;

namespace JMC.LSP.Types;
internal static class ServerDocument
{
    public const string JMC = "jmc";
    public const string HJMC = "hjmc";
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
            DocumentType.Code => await AddCodeDocumentAsync(uri, text, true),
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

    public static async Task<T> UpdateDocumentAsync<T>(T document) where T : IServerDocument
    {
        await RemoveDocumentAsync(document.Uri);
        return await _cache.GetOrCreateAsync(document.Uri, (e) => Task.FromResult(document)) ?? throw new NullReferenceException();
    }

    public static async Task<JMCDocument> AddCodeDocumentAsync(
        DocumentUri uri, 
        string text, 
        bool generateSymbols = true)
    {
        return await _cache.GetOrCreateAsync(uri, (e) =>
        {
            TokenChannels<TokenType>? tokenChannels = null;
            JMCParser.ParseResult? parseResult = generateSymbols 
                ? GenerateJMCSymbols(text, out tokenChannels)
                : null;

            JMCDocument doc = new()
            {
                Uri = uri,
                Text = text,
                TokenChannels = tokenChannels,
                ParseResult = parseResult,
            };
            return Task.FromResult(doc);
        });
    }

    public static JMCParser.ParseResult GenerateJMCSymbols(string text, out TokenChannels<TokenType>? tokenChannels)
    {
        var error = JMCParser.TryGenerateTokens(text, out tokenChannels);
        if (error != null)
        {
            throw new NotImplementedException();
        }

        var result = JMCParser.TryParse(text);
        return result;
    }

    public static Task<JMCDocument> AddHeaderDocumentAsync(DocumentUri uri, string text)
    {
        throw new NotImplementedException();
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
