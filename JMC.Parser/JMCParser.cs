using CommunityToolkit.HighPerformance;
using JMC.Parser.Errors;
using JMC.Parser.Helpers;
using JMC.Parser.Models;

namespace JMC.Parser;
public class JMCParser : IDisposable
{
    protected readonly List2D<BaseSyntaxType> registeredStatements = [];
    protected readonly JMCTokenizer tokenizer;

    public JMCParser(JMCTokenizer tokenizer, SyntaxBuilder syntaxBuilder)
    {
        this.tokenizer = tokenizer;
        registeredStatements.AddRange(syntaxBuilder.Statements);
    }

    public JMCParser(JMCTokenizer tokenizer, List2D<BaseSyntaxType> syntaxes)
    {
        this.tokenizer = tokenizer;
        registeredStatements.AddRange(syntaxes);
    }

    void IDisposable.Dispose()
    {
        registeredStatements.Clear();
    }

    /// <summary>
    /// Parse the text with the highest <see cref="StatementParseResult.Accuracy"/>
    /// </summary>
    /// <param name="errors"></param>
    /// <returns></returns>
    public virtual SyntaxTree Parse(out List<SyntaxError> errors)
    {
        IEnumerable<TokenData> tokenDatas = tokenizer.Tokenize();
        errors = [];
        SyntaxTree tree = [];
        tokenDatas = tokenDatas.Where(v => !v.Value.StartsWith("//") && !v.Value.StartsWith('#'));
        Span<TokenData> tokenDataSpan = tokenDatas.ToArray().AsSpan();

        for (int offset = 0; offset < tokenDataSpan.Length; offset++)
        {
            ref TokenData data = ref tokenDataSpan[offset];
            string value = data.Value;
            Span2D<BaseSyntaxType> firstSyntaxMatchedStatements = registeredStatements
                .Where(v => v[0].Validate(value))
                .ToList()
                .AsSpan2D();
            if (firstSyntaxMatchedStatements.IsEmpty)
            {
                errors.Add(new(tokenizer.ToPosition(data), "Unknown OpCode"));
                continue;
            }

            StatementParseResult[] statementParseResults = ParseSearchedResults(offset, firstSyntaxMatchedStatements, tokenDataSpan);

            if (statementParseResults.Any(v => v.IsAllMatch))
            {
                StatementParseResult firstMatchedStatement = Array.Find(statementParseResults, v => v.IsAllMatch);
                offset += firstMatchedStatement.IndividualResults.Length - 1;
                SyntaxNode unused = tree.AddFromStatement(firstMatchedStatement);
                continue;
            }
            //add most accurate syntax instead
            StatementParseResult mostAccurateStatement = statementParseResults.MaxBy(v => v.Accuracy);
            Span<SyntaxParseResult> results = mostAccurateStatement.IndividualResults.AsSpan();
            int accurateSyntaxes = 0;
            for (; accurateSyntaxes < results.Length; accurateSyntaxes++)
            {
                ref SyntaxParseResult result = ref results[accurateSyntaxes];
                if (!result.IsMatch && result.SyntaxType != null)
                {
                    errors.Add(new(tokenizer.ToPosition(result.TokenData), $"Expect {result.SyntaxType.GetType().Name}"));
                    break;
                }
                else if (!result.IsMatch)
                {
                    break;
                }
            }
            offset += accurateSyntaxes - 1;
            var unused1 = tree.AddFromStatement(mostAccurateStatement);
        }

        return tree;
    }

    private static StatementParseResult[] ParseSearchedResults(int pOffset, Span2D<BaseSyntaxType> searchResult, Span<TokenData> dataSpan)
    {
        int offset = pOffset;
        StatementParseResult[] statementParseResults = new StatementParseResult[searchResult.Height];

        for (int h = 0; h < searchResult.Height; h++)
        {
            StatementParseResult currentStatement = new()
            {
                IndividualResults = new SyntaxParseResult[searchResult.Width],
            };
            for (int w = 0; w < searchResult.Width; w++)
            {
                ref BaseSyntaxType syntax = ref searchResult[h, w];
                if (syntax == null)
                {
                    currentStatement.IndividualResults[w] = SyntaxParseResult.VALID_EXCCEED;
                    continue;
                }
                else if (offset >= dataSpan.Length)
                {
                    currentStatement.IndividualResults[w] = SyntaxParseResult.INVALID;
                    continue;
                }
                ref TokenData currentData = ref dataSpan[offset];
                offset++;
                if (!syntax.Validate(currentData.Value))
                {
                    currentStatement.IndividualResults[w] = new()
                    {
                        IsMatch = false,
                        TokenData = currentData,
                        SyntaxType = syntax,
                    };
                    continue;
                }
                currentStatement.IndividualResults[w] = new()
                {
                    IsMatch = true,
                    TokenData = currentData,
                    SyntaxType = syntax,
                };
            }
            statementParseResults[h] = currentStatement;
            offset = pOffset;
        }
        return statementParseResults;
    }
}
