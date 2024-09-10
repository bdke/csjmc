using System.Collections;

using JMC.Parser.Command.Argument;

using static JMC.Parser.Test.Commands.ArgumentTests;

namespace JMC.Parser.Test.Commands
{
    public class ArgumentTestData(BaseArgument arg, IEnumerable<string> valid, IEnumerable<string> invalid) : IEnumerable<object[]>
    {
        private BaseArgument Argument => arg;
        public IEnumerable<string> ValidDatas => valid;
        public IEnumerable<string> InvalidDatas => invalid;

        public IEnumerator<object[]> GetEnumerator()
        {
            foreach (string data in ValidDatas)
            {
                yield return [new ArgumentTestCaseData(Argument, data, true)];
            }

            foreach (string data in InvalidDatas)
            {
                yield return [new ArgumentTestCaseData(Argument, data, false)];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
