using JMC.Parser.Command.Datas;

namespace JMC.Parser.Test.Commands
{
    public class DatabaseFixture : IDisposable
    {
        public DatabaseFixture()
        {
            MinecraftDbContext.Init();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
