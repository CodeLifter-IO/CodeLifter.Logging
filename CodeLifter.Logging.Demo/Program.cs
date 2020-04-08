using CodeLifter.Logging.Loggers;

namespace CodeLifter.Logging.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogRunner logger = new LogRunner();
            logger.AddLogger(new ConsoleLogger());
            logger.AddLogger(new DebugLogger());
            logger.AddLogger(new InMemoryLogger());

            logger.LogMessage("DEBUG", LogLevels.Debug);
            logger.LogMessage("INFO", LogLevels.Info);
            logger.LogMessage("WARNING", LogLevels.Warning);
            logger.LogMessage("ERROR", LogLevels.Error);
            logger.LogMessage("FATAL", LogLevels.Fatal);
            logger.LogMessage("TRACE");
        }
    }
}
