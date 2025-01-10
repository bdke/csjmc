using EmmyLua.LanguageServer.Framework.Protocol.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMC.LSP.Types;
internal interface IServerDocument
{
    public DocumentUri Uri { get; set; }
    public string Text { get; set; }
}
