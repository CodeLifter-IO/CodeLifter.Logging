using System;
using System.Collections.Generic;
using CodeLifter.Logging.Loggers;

namespace CodeLifter.Logging
{
    public interface ILogRunner
    {
        List<ILogger> Loggers { get; }

        void AddLogger(ILogger logger);

        void LogMessage(string infoMessage, LogLevels level = LogLevels.Debug);
    }
}


