using System;
namespace CodeLifter.Logging.Loggers
{
    public interface ILogger
    {
        void LogEntry(string message, LogLevels level = LogLevels.Trace);
    }
}
