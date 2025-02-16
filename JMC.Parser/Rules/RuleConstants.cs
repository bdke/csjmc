namespace JMC.Parser.Rules;
internal static class RuleConstants
{
    internal const string END = $"[{nameof(TokenType.End)}][d]";
    internal const string IDENTIFIER = nameof(TokenType.Identifier);
    internal const string DOT = $"{nameof(TokenType.Dot)}[d]";
    internal const string LPAREN = $"{nameof(TokenType.ParenStart)}[d]";
    internal const string RPAREN = $"{nameof(TokenType.ParenEnd)}[d]";
    internal const string LBLOCK = $"{nameof(TokenType.BlockStart)}[d]";
    internal const string LBLOCK_KEEP = $"{nameof(TokenType.BlockStart)}";
    internal const string LLIST = $"{LLIST_KEEP}[d]";
    internal const string LLIST_KEEP = nameof(TokenType.ListStart);
    internal const string RLIST = $"{nameof(TokenType.ListEnd)}[d]";
    internal const string RBLOCK = $"{nameof(TokenType.BlockEnd)}[d]";
    internal const string COMMA = $"{nameof(TokenType.Comma)}[d]";

    internal const string STRING_VALUE = $"{nameof(TokenType.StringValue)}";
    internal const string STRING_START = $"{STRING_START_KEEP}[d]";
    internal const string STRING_START_KEEP = $"{nameof(TokenType.StartQuote)}";
    internal const string STRING_END = $"{nameof(TokenType.EndQuote)}[d]";

    internal const string COLON = $"{nameof(TokenType.Colon)}[d]";

    internal const string COMPARATORS = $"[{nameof(TokenType.Equal)}|{nameof(TokenType.NotEqual)}|{nameof(TokenType.LessThan)}|{nameof(TokenType.LessThanOrEqual)}|{nameof(TokenType.GreaterThan)}|{nameof(TokenType.GreaterThanOrEqual)}]";
    internal const string CONDITION_OPERATORS = $"[{nameof(TokenType.And)}|{nameof(TokenType.Or)}]";

    internal const string NORMAL_ARG = "NormalArg";
    internal const string NAMED_ARG = "NamedArg";
    internal const string ROOT_ARG = "RootArg";

    internal const string BLOCK = "Block";
    internal const string IMPORT_PATH = "ImportPath";

    internal const string LAMBDA_FUNCTION = "LambdaFunction";
    internal const string FUNC_PARAMS = "FuncParams";

    internal const string AL_ROOT = "AL";

    internal const string VEC2_COLLECTION = "Vec2";
    internal const string VEC3_COLLECTION = "Vec3";
    internal const string COMMAND_PROPERTIES = "Properties";

    internal const string COMMAND_JSON_OBJECT = "JsonObject";
    internal const string COMMAND_JSON_LIST = "JsonList";

    internal const string VALUE_STRING = "String";
    internal const string F_STRING_EXPRESSION = "FStringExpression";
    internal const string F_STRING = "FString";
    internal const string COLOR_STRING = "ColorString";
    internal const string COLOR_TAG = "ColorTag";

    internal const string ARRAY_ELEMS = "ArrayElems";
    internal const string ARRAY = "Array";
}
