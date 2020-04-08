A nice easy to use Logging option.

You can create multiple logs and log a single time but it will log to all Loggers that you add.

See the demo code below (includes working project in repo.)

```
using CodeLifter.Logging.Loggers;

namespace CodeLifter.Logging.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogRunner logger = new Logger();
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


```
