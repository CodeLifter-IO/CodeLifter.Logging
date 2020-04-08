using System;
using System.Collections.Generic;
using CodeLifter.Logging.Loggers;

namespace CodeLifter.Logging
{
    public interface ILogRunner
    {
        void AddLogger(ILogger logger);

        void LogMessage(string infoMessage, LogLevels level = LogLevels.Trace);

        void PrintToAllEnabledLogs(string infoMessage, LogLevels level = LogLevels.Trace);
    }
}


