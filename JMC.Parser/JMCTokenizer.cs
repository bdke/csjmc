using JMC.Parser.Helpers;
using JMC.Parser.Models;
using JMC.Parser.Types;
using OmniSharp.Extensions.LanguageServer.Protocol.Models;

namespace JMC.Parser;
public class JMCTokenizer(string rawText, int startOffset = 0)
{
    public int StartOffset => startOffset;
    public string RawText => rawText;
    protected int currentOffset = 0;
    protected char CurrentChar => rawText[currentOffset];
    protected char NextChar => rawText[currentOffset + 1];
    private bool isValueOperation = false;
    public virtual IEnumerable<TokenData> Tokenize()
    {
        List<TokenData> l = [];
        string? v;
        do
        {
            v = ReadStatement();
            if (v == null)
            {
                break;
            }
            else if (v == string.Empty)
            {
                currentOffset++;
                continue;
            }

            l.Add(new(currentOffset - v.Length + startOffset, v));
        } while (v != null);
        return l;
    }

    public Position ToPosition(TokenData token)
    {
        return rawText.ToPosition(token.Offset - startOffset);
    }

    private string? ReadStatement()
    {
        SkipWhiteSpace();
        if (currentOffset >= rawText.Length)
        {
            return null;
        }
        else if (isValueOperation && !Operator.VALID_OPERATORS.Contains(CurrentChar))
        {
            return ReadUntil(';');
        }
        else if (CurrentChar == '/' && NextChar == '/')
        {
            return ReadComment();
        }
        else if (Operator.VALID_OPERATORS.Contains(CurrentChar))
        {
            return ReadOperator();
        }
        return CurrentChar switch
        {
            '"' => ReadString(),
            '{' => ReadPair('{', '}'),
            '[' => ReadPair('[', ']'),
            '(' => ReadPair('(', ')'),
            '#' => ReadMCComment(),
            ';' or '|' or '&' => ReadSingle(),
            _ => ReadWord(),
        };
    }

    private string ReadMCComment()
    {
        string value = string.Empty;

        while (currentOffset < rawText.Length && !IsCurrentOffsetNewLine())
        {
            value += CurrentChar;
            currentOffset++;
        }
        return value;
    }

    private string ReadComment()
    {
        string value = "/";
        currentOffset++;

        while (currentOffset < rawText.Length && !IsCurrentOffsetNewLine())
        {
            value += CurrentChar;
            currentOffset++;
        }
        return value;
    }

    private string ReadSingle()
    {
        string value = CurrentChar.ToString();
        currentOffset++;
        return value;
    }

    private string ReadOperator()
    {
        isValueOperation = true;
        string value = CurrentChar.ToString();
        currentOffset++;
        return value;
    }

    private string ReadPair(char start, char end)
    {
        string value = start.ToString();
        int bracketCount = 1;
        while (currentOffset < rawText.Length && bracketCount != 0)
        {
            currentOffset++;
            if (CurrentChar == start)
            {
                bracketCount++;
            }
            else if (CurrentChar == end)
            {
                bracketCount--;
            }

            value += CurrentChar;
        }
        currentOffset++;
        return value;
    }

    private string ReadString()
    {
        string value = "\"";
        currentOffset++;
        while (currentOffset < rawText.Length && CurrentChar != '"')
        {
            value += CurrentChar;
            currentOffset++;

            if (currentOffset < rawText.Length && CurrentChar == '\\')
            {
                currentOffset += 2;
            }
        }
        value += "\"";
        currentOffset++;
        return value;
    }

    private string ReadWord()
    {
        string value = string.Empty;
        if (CurrentChar == '$')
        {
            value += '$';
            currentOffset++;
        }

        while (currentOffset < rawText.Length
            && !char.IsWhiteSpace(CurrentChar)
            && (char.IsLetterOrDigit(CurrentChar) || CurrentChar is '_' or '.'))
        {
            value += CurrentChar;
            currentOffset++;
        }

        return value;
    }

    private string ReadUntil(char c)
    {
        string value = string.Empty;
        while (currentOffset < rawText.Length && CurrentChar != c)
        {
            value += CurrentChar;
            currentOffset++;
        }
        isValueOperation = false;
        return value;
    }

    private bool IsCurrentOffsetNewLine()
    {
        string newLine = Environment.NewLine;
        return currentOffset + 1 < rawText.Length
&& (newLine.Length == 2 ? $"{CurrentChar}{NextChar}" == newLine : CurrentChar.ToString() == newLine);
    }

    private void SkipWhiteSpace()
    {
        while (currentOffset < rawText.Length && char.IsWhiteSpace(CurrentChar))
        {
            currentOffset++;
        }
    }
}