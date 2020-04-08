using System;
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

            logger.LogMessage("TRACE", LogLevels.Trace);
            logger.LogMessage("EXCEPTION", LogLevels.Exception);
            logger.LogMessage("ERROR", LogLevels.Error);
            logger.LogMessage("CRITICAL", LogLevels.Critical);
            logger.LogMessage("ALERT", LogLevels.Alert);
            logger.LogMessage("TRACE");
        }
    }
}
