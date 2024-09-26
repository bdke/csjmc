using JMC.Parser.Types;

namespace JMC.Parser;
public static class JMCSyntax
{
    private readonly static SyntaxBuilder builder = new();
    public static SyntaxBuilder GetCoreBuilder()
    {
        _ = builder
            .Next(new Keyword("import"))
            .Next(new Types.String())
            .End()
            .Create();

        _ = builder
            .Next(new Keyword("if"))
            .Next(new Condition())
            .Block()
            .Create();

        _ = builder
            .Next(new Keyword("function"))
            .Next(new Word())
            .Next(new Parameters())
            .Block()
            .Create();

        _ = builder
            .Next(new Keyword("class"))
            .Next(new Word())
            .Block()
            .Create();

        _ = builder
            .Next(new Variable())
            .Next(new Operator())
            .Next(new ValueOperation())
            .End()
            .Create();

        _ = builder
            .Next(new Variable())
            .Next(new Operator())
            .Next(new Operator())
            .Next(new ValueOperation())
            .End()
            .Create();

        _ = builder
            .Next(new Word())
            .Next(new Parameters())
            .End()
            .Create();

        _ = builder
            .Next(new End())
            .Create();

        //TODO: commands

        _ = builder.Build();
        return builder;
    }
}
