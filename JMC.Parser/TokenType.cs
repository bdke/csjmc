using sly.lexer;

namespace JMC.Parser;

public enum TokenType
{
    EOF = 0,

    #region Sugar
    [Comment("//", "/*", "*/")]
    Comment,
    [Sugar("++")]
    [Mode(ModeAttribute.DefaultLexerMode, "fstringExpression")]
    Increment,
    [Sugar("--")]
    [Mode(ModeAttribute.DefaultLexerMode, "fstringExpression")]
    Decrement,
    [Sugar("+")]
    [Mode(ModeAttribute.DefaultLexerMode, "fstringExpression")]
    Plus,
    [Sugar("-")]
    [Mode(ModeAttribute.DefaultLexerMode, "fstringExpression")]
    Minus,
    [Sugar("*")]
    [Mode(ModeAttribute.DefaultLexerMode, "fstringExpression")]
    Multiply,
    [Sugar("/")]
    [Mode(ModeAttribute.DefaultLexerMode, "fstringExpression")]
    Divide,
    [Sugar("%")]
    [Mode(ModeAttribute.DefaultLexerMode, "fstringExpression")]
    Remainder,
    [Sugar(">")]
    GreaterThan,
    [Sugar("<")]
    LessThan,
    [Sugar("==")]
    Equal,
    [Sugar("!=")]
    NotEqual,
    [Sugar(">=")]
    GreaterThanOrEqual,
    [Sugar("<=")]
    LessThanOrEqual,
    [Sugar("=")]
    Assign,
    [Sugar("?=")]
    BooleanAssign,
    [Sugar("%=")]
    RemainderAssign,
    [Sugar("+=")]
    PlusAssign,
    [Sugar("-=")]
    MinusAssign,
    [Sugar("*=")]
    MultiplyAssign,
    [Sugar("/=")]
    DivideAssign,
    [Sugar("><")]
    CompareAssign,
    [Sugar("??=")]
    NullColesleAssign,
    [Sugar("=>")]
    Arrow,
    [Sugar("{")]
    BlockStart,
    [Sugar("}")]
    BlockEnd,
    [Sugar("[")]
    ListStart,
    [Sugar("]")]
    ListEnd,
    [Sugar("(")]
    ParenStart,
    [Sugar(")")]
    ParenEnd,
    [Sugar(":")]
    Colon,
    [Sugar("::")]
    Imply,
    [Sugar(",")]
    Comma,
    [Sugar(";")]
    End,
    [Sugar("!")]
    Not,
    [Sugar("$")]
    [Mode(ModeAttribute.DefaultLexerMode, "fstringExpression")]
    DollarSign,
    [Sugar(".")]
    Dot,
    [Sugar("&")]
    Deref,
    [Sugar("||")]
    Or,
    [Sugar("&&")]
    And,
    [Sugar("\\")]
    Escape,
    #endregion

    #region Keywords
    [Keyword("true")]
    True,
    [Keyword("false")]
    False,
    [Keyword("run")]
    RunKeyword,
    [Keyword("import")]
    ImportKeyword,
    [Keyword("function")]
    FunctionKeyword,
    [Keyword("while")]
    WhileKeyword,
    [Keyword("if")]
    IfKeyword,
    [Keyword("else")]
    ElseKeyword,
    [Keyword("do")]
    DoKeyword,
    [Keyword("class")]
    ClassKeyword,
    [Keyword("new")]
    NewKeyword,
    [Keyword("null")]
    NullKeyword,
    [Keyword("command")]
    CommandKeyword,
    [Sugar("@s")]
    SelectorSelf,
    [Sugar("@p")]
    SelectorNearest,
    [Sugar("@a")]
    SelectorAllPlayers,
    [Sugar("@r")]
    SelectorRandomPlayer,
    [Sugar("@e")]
    SelectorAllEntities,
    #endregion

    [Int]
    [Mode(ModeAttribute.DefaultLexerMode, "fstringExpression")]
    Int,
    [Double]
    [Mode(ModeAttribute.DefaultLexerMode, "fstringExpression")]
    Double,
    [AlphaNumDashId]
    [Mode(ModeAttribute.DefaultLexerMode, "fstringExpression")]
    Identifier,

    #region String
    //normal string
    [Sugar("\"")]
    [Push("string")]
    StartQuote,
    [Sugar("\"")]
    [Mode("string")]
    [Pop]
    EndQuote,
    [UpTo("\"")]
    [Mode("string")]
    StringValue,

    //fstring
    [Sugar("$\"")]
    [Push("fstring")]
    StartFString,
    [Sugar("\"")]
    [Mode("fstring")]
    [Pop]
    EndFString,

    [Sugar("{")]
    [Mode("fstring")]
    [Push("fstringExpression")]
    FStringBracketStart,
    [Sugar("}")]
    [Mode("fstringExpression")]
    [Pop]
    FStringBracketEnd,

    [UpTo("{", "\"")]
    [Mode("fstring")]
    FStringContent,

    //color string
    [Sugar("&\"")]
    [Push("colorString")]
    StartColorString,
    [Sugar("\"")]
    [Mode("colorString")]
    [Pop]
    EndColorString,

    [Sugar("<")]
    [Mode("colorString")]
    [Push("colorStringTag")]
    ColoStringTagStart,
    [Sugar(">")]
    [Mode("colorStringTag")]
    [Pop]
    ColoStringTagEnd,

    [Sugar("/")]
    [Mode("colorStringTag")]
    ColorStringTagEndValue,
    [AlphaId]
    [Mode("colorStringTag")]
    ColorStringTagValue,
    [UpTo("<", "\"")]
    [Mode("colorString")]
    ColorStringContent,

    #endregion
}
