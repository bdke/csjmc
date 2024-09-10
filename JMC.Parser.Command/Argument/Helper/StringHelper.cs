namespace JMC.Parser.Command.Argument.Helper;

internal static class StringHelper
{
    public static bool IsValidString(this string str)
    {
        return str.StartsWith('"') && str.EndsWith('"');


    }

    public static bool IsValidPosition(this string str, bool tildeOnly = false)
    {
        return str.IsNumeric() ||
        ((str.StartsWith('~') || (str.StartsWith('^') && !tildeOnly)) &&
        (str[1..].IsNumeric() || str[1..].Length == 0));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="tildeOnly"></param>
    /// <returns>
    /// <para>true if all valid</para>
    /// <para>individual <seealso cref="IsValidPosition(string, bool)"/> Result</para>
    /// </returns>
    public static (bool, bool[]) IsValidPositions(this string[] pos, bool tildeOnly = false)
    {
        bool[] posResult = pos.Select(v => v.IsValidPosition(tildeOnly)).ToArray();
        if (posResult.Any(v => !v))
        {
            return new(false, posResult);
        }
        bool isAllCaret = pos.All(v => v.StartsWith('~'));
        bool isAllTilde = pos.All(v => v.StartsWith('^')) && !tildeOnly;
        bool isAllNumber = pos.All(v => float.TryParse(v, out _));
        return new(isAllCaret || isAllTilde || isAllNumber, posResult);
    }

    public static bool IsNumeric(this string str)
    {
        return float.TryParse(str, out _);
    }

    public static bool IsValidResourceLocation(this string str, bool isTag = false)
    {
        string[] args = str.Split(':');

        switch (args.Length)
        {
            case 1 when args[0].Any(v => (v != '#' && !char.IsLetterOrDigit(v)) || v is '_' or '-' or '.' or '/'):
            case 2 when args[1].Any(v => (v != '#' && !char.IsLetterOrDigit(v)) || v is '_' or '-' or '.' or '/'):
            case 2 when args[0].Any(v => (v != '#' && !char.IsLetterOrDigit(v)) || v is '_' or '-' or '.'):
            case 1 or 2 when !isTag && args[0].StartsWith('#'):
                return false;
        }

        return true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="str">must start with <c>'{'</c></param>
    /// <returns>Length of nbt, value</returns>
    public static (int, string) ParseNBT(this string str)
    {
        int bracketCounter = 0;
        int i = 0;
        for (; i < str.Length; i++)
        {
            char currentValue = str[i];
            bracketCounter += currentValue switch
            {
                '{' => 1,
                '}' => -1,
                _ => 0
            };
            if (bracketCounter == 0)
            {
                break;
            }
        }
        return (i + 1, str[..(i + 1)]);
    }

    public static bool IsBracketValid(this string str)
    {
        int startCount = 0;
        int endCount = 0;
        bool inQuote = false;
        foreach (char c in str)
        {
            if (c == '"')
            {
                inQuote = !inQuote;
            }

            if (inQuote)
            {
                continue;
            }

            if (c == '[')
            {
                startCount++;
            }
            else if (c == ']')
            {
                endCount++;
            }
        }
        if (startCount != endCount)
        {
            return false;
        }

        startCount = endCount = 0;
        foreach (char c in str)
        {
            if (c == '"')
            {
                inQuote = !inQuote;
            }

            if (inQuote)
            {
                continue;
            }

            if (c == '{')
            {
                startCount++;
            }
            else if (c == '}')
            {
                endCount++;
            }
        }
        return startCount == endCount;
    }
}