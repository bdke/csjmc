using System.Collections.Immutable;

using JMC.Shared;

namespace JMC.Parser.JMC;

public sealed class JMCParser
{
    public static List<BaseError> Errors { get; private set; } = [];
    public static ImmutableArray<string> RawLineString { get; private set; } = [];
    private static int pointer { get; set; } = 0;
    public static int Line { get; private set; }
    public static int Column { get; private set; }
    public JMCParser(string rawString)
    {
        StringReader reader = new(rawString);
        List<string> lines = [];

        string? line = reader.ReadLine();
        while (line != null)
        {
            lines.Add(line);
            line = reader.ReadLine();
        }

        RawLineString = [.. lines];
    }
    /// <summary>
    /// Split the command into recognizable pattern
    /// </summary>
    /// <param name="commandString"></param>
    /// <returns>offset of the string that ends and the string</returns>
    public static IEnumerable<KeyValuePair<int, string>> SplitArguments(string commandString)
    {
        string tempArgString = string.Empty;
        int middleBracketCount = 0;
        int curlyBracketCount = 0;
        bool inQuote = false;
        for (int i = 0; i < commandString.Length; i++)
        {
            char currentChar = commandString[i];

            //parse brackets
            switch (currentChar)
            {
                case '[':
                    middleBracketCount++;
                    break;
                case ']':
                    middleBracketCount--;
                    break;
                case '{':
                    curlyBracketCount++;
                    break;
                case '}':
                    curlyBracketCount--;
                    break;
            }

            if (currentChar == '"')
            {
                inQuote = !inQuote;
            }

            bool isInBracket = middleBracketCount > 0 || curlyBracketCount > 0;
            if ((currentChar == ' ' || currentChar == '\0') && tempArgString != string.Empty && !inQuote && !isInBracket)
            {
                yield return new(i, tempArgString);
                tempArgString = string.Empty;
                continue;
            }

            tempArgString += currentChar;

            //quotes
            if (inQuote)
            {
                continue;
            }

            //brackets
            bool isEndOfBracket = (currentChar == ']' && middleBracketCount == 0) ||
                (currentChar == '}' && curlyBracketCount == 0);
            bool isNextCharBracket = i + 1 < commandString.Length && commandString[i + 1] is '[' or '{';
            if (isEndOfBracket && !isNextCharBracket && i + 1 < commandString.Length && commandString[i + 1] is ' ' or '\0')
            {
                yield return new(i, tempArgString);
                tempArgString = string.Empty;
                middleBracketCount = 0;
                curlyBracketCount = 0;
            }
            else if (isEndOfBracket && isNextCharBracket)
            {
                middleBracketCount = 0;
                curlyBracketCount = 0;
            }
        }

        if (tempArgString != string.Empty)
        {
            yield return new(commandString.Length, tempArgString);
        }
    }
}