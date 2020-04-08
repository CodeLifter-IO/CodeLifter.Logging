using System;
namespace CodeLifter.Logging.Loggers
{
    public class ConsoleLogger : ILogger
    {
        public void LogEntry(string message, LogLevels level = LogLevels.Trace)
        {
            switch (level)
            {
                case LogLevels.Trace:
                    Console.ResetColor();
                    break;
                case LogLevels.Alert:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case LogLevels.Exception:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case LogLevels.Error:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case LogLevels.Critical:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                default:
                    Console.ResetColor();
                    break;
            }

            Console.WriteLine(message);
        }
    }
}
