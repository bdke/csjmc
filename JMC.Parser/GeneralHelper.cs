using sly.lexer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMC.Parser;
internal static class GeneralHelper
{
    public static Position ToPosition(this LexerPosition lexerPosition) => new(lexerPosition.Line, lexerPosition.Column);
}
