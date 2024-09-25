namespace JMC.Parser;
public sealed class JMCTokenizer(string rawText)
{
    private int currentOffset = 0;
    private char CurrentChar => rawText[currentOffset];
    private char NextChar => rawText[currentOffset + 1];
    public IEnumerable<TokenData> Tokenize()
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

            l.Add(new(currentOffset - v.Length, v));
        } while (v != null);
        return l;
    }

    private string? ReadStatement()
    {
        SkipWhiteSpace();
        if (currentOffset >= rawText.Length)
        {
            return null;
        }
        else
        {
            return CurrentChar switch
            {
                '"' => ReadString(),
                '{' => ReadPair('{', '}'),
                '[' => ReadPair('[', ']'),
                '(' => ReadPair('(', ')'),
                '/' when rawText[currentOffset + 1] == '/' => ReadComment(),
                '#' => ReadMCComment(),
                ';' or '=' or '+' or '-' or '*' or '/' or '%' or '<' or '>' or '?' or '|' or '&' or '$' => ReadSingle(),
                _ => ReadWord(),
            };
        }
    }

    private string ReadMCComment()
    {
        var value = string.Empty;
        
        while (currentOffset < rawText.Length && !IsCurrentOffsetNewLine())
        {
            value += CurrentChar;
            currentOffset++;
        }
        return value;
    }

    private string ReadComment()
    {
        var value = "/";
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
        var value = CurrentChar.ToString();
        currentOffset++;
        return value;
    }

    private string ReadPair(char start, char end)
    {
        string value = start.ToString();
        var bracketCount = 1;
        while (currentOffset < rawText.Length && bracketCount != 0)
        {
            currentOffset++;
            if (CurrentChar == start)
                bracketCount++;
            else if (CurrentChar == end)
                bracketCount--;
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
        while (currentOffset < rawText.Length && !char.IsWhiteSpace(CurrentChar) && (char.IsLetterOrDigit(CurrentChar) || CurrentChar is '_' or '.'))
        {
            value += CurrentChar;
            currentOffset++;
        }
        if (currentOffset < rawText.Length - 1 && CurrentChar is not '(' && !char.IsLetter(CurrentChar))
        {
            currentOffset++;
        }

        return value;
    }

    private bool IsCurrentOffsetNewLine()
    {
        var newLine = Environment.NewLine;
        if (currentOffset + 1 >= rawText.Length)
            return false;
        if (newLine.Length == 2)
            return $"{CurrentChar}{NextChar}" == newLine;
        else
            return CurrentChar.ToString() == newLine;
    }

    private void SkipWhiteSpace()
    {
        while (currentOffset < rawText.Length && char.IsWhiteSpace(CurrentChar))
        {
            currentOffset++;
        }
    }
}