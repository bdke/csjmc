using EmmyLua.LanguageServer.Framework.Protocol.Model;

namespace JMC.LSP.Types;
internal struct JMCDocument : IServerDocument
{
    public DocumentUri Uri { get; set; }
    public string Text { get; set; }
}
