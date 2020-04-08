using System;
using System.Diagnostics;

namespace CodeLifter.Logging.Loggers
{
    public class DebugLogger : ILogger
    {
        public void LogEntry(string message, LogLevels level = LogLevels.Trace)
        {
            Debug.WriteLine(message);
        }
    }
}
