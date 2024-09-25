using CommunityToolkit.HighPerformance;
using JMC.Parser.Helpers;

namespace JMC.Parser;
public sealed class JMCParser : IDisposable
{
    private readonly List2D<BaseSyntaxType> registeredSyntaxes = [];
    public JMCParser(SyntaxBuilder syntaxBuilder)
    {
        registeredSyntaxes.AddRange(syntaxBuilder.BuiltSyntaxes);
    }

    public JMCParser(List2D<BaseSyntaxType> syntaxes)
    {
        registeredSyntaxes.AddRange(syntaxes);
    }

    public SyntaxTree Parse(IEnumerable<TokenData> tokenDatas)
    {
        SyntaxTree tree = [];

        Span<TokenData> dataSpan = tokenDatas.ToArray().AsSpan();

        for (int i = 0; i < dataSpan.Length; i++)
        {
            ref TokenData data = ref dataSpan[i];
            string value = data.Value;
            Span2D<BaseSyntaxType> searchResult = registeredSyntaxes
                .Where(v => v[0].Validate(value))
                .ToList()
                .AsSpan2D();

            int currentIndex = i;
            bool match = true;
            for (int y = 0; y < searchResult.Height; y++)
            {
                var valids = new List<TokenData>();
                for (int x = 0; x < searchResult.Width; x++)
                {
                    ref BaseSyntaxType syntax = ref searchResult[y, x];
                    ref TokenData currentData = ref dataSpan[i];
                    i++;
                    if (!syntax.Validate(currentData.Value))
                    {
                        //TODO: Syntax error
                        match = false;
                        break;
                    }
                    valids.Add(currentData);
                }
                var nodes = valids.Select(v => new SyntaxNode(v));
                var root = nodes.ElementAt(0);
                var children = nodes.Skip(1);
                root.AddRange(children);
                tree.Add(root);
                i--;
                valids.Clear();
                i = currentIndex;
            }
            if (!match)
            {
                i++;
            }
        }

        return tree;
    }

    void IDisposable.Dispose()
    {
        registeredSyntaxes.Clear();
    }
}
