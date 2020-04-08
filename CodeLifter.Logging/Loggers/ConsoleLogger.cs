using System;
namespace CodeLifter.Logging.Loggers
{
    public class ConsoleLogger : ILogger
    {
        public void LogEntry(string message, LogLevels level = LogLevels.Debug)
        {
            switch (level)
            {
                case LogLevels.Debug:
                    Console.ResetColor();
                    break;
                case LogLevels.Info:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case LogLevels.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case LogLevels.Error:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case LogLevels.Fatal:
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
