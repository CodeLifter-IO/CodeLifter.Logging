using System;
using System.Collections.Generic;

namespace CodeLifter.Logging.Loggers
{
    public class InMemoryLogger : ILogger
    {
        public List<string> Log { get; set; }

        public InMemoryLogger()
        {
            Log = new List<string>();
        }

        public void LogEntry(string message, LogLevels level = LogLevels.Trace)
        {
            Log.Add(message);
        }
    }
}
