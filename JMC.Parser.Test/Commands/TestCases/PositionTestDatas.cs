using JMC.Parser.Command.Argument;

namespace JMC.Parser.Test.Commands.TestCases
{
    public class PositionTestDatas(BaseArgument argument, bool tildeOnly = false) :
        ArgumentTestData(argument, GetValidDatas(argument.ArgumentsLength - 1, tildeOnly), GetInvalidDatas(argument.ArgumentsLength - 1, tildeOnly))
    {
        public static IEnumerable<string> GetValidDatas(int positionCount, bool tildeOnly)
        {
            yield return $"~{string.Concat(Enumerable.Repeat(" ~", positionCount))}";
            if (!tildeOnly)
            {
                yield return $"^{string.Concat(Enumerable.Repeat(" ^", positionCount))}";
            }

            yield return $"3{string.Concat(Enumerable.Repeat(" 3", positionCount))}";
            yield return $"~3{string.Concat(Enumerable.Repeat(" ~3", positionCount))}";
            yield return $".5{string.Concat(Enumerable.Repeat(" .5", positionCount))}";
            yield return $"~.5{string.Concat(Enumerable.Repeat(" ~.5", positionCount))}";
            yield return $"0.5{string.Concat(Enumerable.Repeat(" 0.5", positionCount))}";
        }

        public static IEnumerable<string> GetInvalidDatas(int positionCount, bool tildeOnly)
        {
            if (positionCount <= 0)
            {
                yield break;
            }
            if (!tildeOnly)
            {
                yield return $"~{string.Concat(Enumerable.Repeat(" ^", positionCount))}";
            }
            yield return $".3{string.Concat(Enumerable.Repeat(" ~", positionCount))}";
        }
    }
}
