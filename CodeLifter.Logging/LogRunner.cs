using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using CodeLifter.Logging.Loggers;

namespace CodeLifter.Logging
{
    public class Logger : ILogRunner
    {
        public List<ILogger> Loggers { get; private set; }

        public Logger()
        {
            Loggers = new List<ILogger>();
        }

        public void AddLogger(ILogger logger)
        {
            if(!Loggers.Contains(logger))
            {
                Loggers.Add(logger);
            }
        }

        public void LogMessage(string infoMessage, LogLevels level = LogLevels.Info)
        {
            PrintToAllEnabledLogs(infoMessage, level);
        }

        private void PrintToAllEnabledLogs(string infoMessage, LogLevels level = LogLevels.Info)
        {
            infoMessage = $"*** {ConvertLevelForLog(level)} *** {DateTime.Now} - {infoMessage}";
            foreach(ILogger log in Loggers)
            {
                log.LogEntry(infoMessage, level);
            }
        }

        private string ConvertLevelForLog(LogLevels level)
        {
            return level.ToString().ToUpper().PadRight(7, ' ');
        }
    }
}