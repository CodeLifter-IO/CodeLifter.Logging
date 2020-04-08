using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using CodeLifter.Logging.Loggers;

namespace CodeLifter.Logging
{
    public class Logger : ILogRunner
    {
        private List<ILogger> Loggers;

        public Logger()
        {
            Loggers = new List<ILogger>();
        }

        public void AddLogger(ILogger logger)
        {
            Loggers.Add(logger);
        }

        public void LogMessage(string infoMessage, LogLevels level = LogLevels.Trace)
        {
            PrintToAllEnabledLogs(infoMessage, level);
        }

        public void PrintToAllEnabledLogs(string infoMessage, LogLevels level = LogLevels.Trace)
        {
            infoMessage = $"*** {level} {DateTime.Now} *** {infoMessage}";
            foreach(ILogger log in Loggers)
            {
                log.LogEntry(infoMessage, level);
            }
        }

    }
}