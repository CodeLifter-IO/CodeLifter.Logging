using System;
using CodeLifter.Logging.Loggers;
using Xunit;

namespace CodeLifter.Logging.Test
{
    public class LogRunnerLevelsTest
    {
        [Fact]
        public void DebugStatusPrintsCorrectlyEvenWhenNoStatusGiven()
        {
            ILogRunner logger = new LogRunner();
            logger.AddLogger(new InMemoryLogger());
            logger.LogMessage("TEST");

            Assert.StartsWith("*** DEBUG", GetEntryFromLog(logger, 0, 0));
        }


        [Fact]
        public void TraceStatusPrintsCorrectly()
        {
            ILogRunner logger = new LogRunner();
            logger.AddLogger(new InMemoryLogger());
            logger.LogMessage("TEST", LogLevels.Trace);

            Assert.StartsWith("*** TRACE", GetEntryFromLog(logger, 0, 0));
        }

        [Fact]
        public void DebugStatusPrintsCorrectly()
        {
            ILogRunner logger = new LogRunner();
            logger.AddLogger(new InMemoryLogger());
            logger.LogMessage("TEST", LogLevels.Debug);

            Assert.StartsWith("*** DEBUG", GetEntryFromLog(logger, 0, 0));
        }

        [Fact]
        public void InfoStatusPrintsCorrectly()
        {
            ILogRunner logger = new LogRunner();
            logger.AddLogger(new InMemoryLogger());
            logger.LogMessage("TEST", LogLevels.Info);

            Assert.StartsWith("*** INFO", GetEntryFromLog(logger, 0, 0));
        }

        [Fact]
        public void WarningStatusPrintsCorrectly()
        {
            ILogRunner logger = new LogRunner();
            logger.AddLogger(new InMemoryLogger());
            logger.LogMessage("TEST", LogLevels.Warning);

            Assert.StartsWith("*** WARNING", GetEntryFromLog(logger, 0, 0));
        }

        [Fact]
        public void ErrortatusPrintsCorrectly()
        {
            ILogRunner logger = new LogRunner();
            logger.AddLogger(new InMemoryLogger());
            logger.LogMessage("TEST", LogLevels.Error);

            Assert.StartsWith("*** ERROR", GetEntryFromLog(logger, 0, 0));
        }

        [Fact]
        public void FataltatusPrintsCorrectly()
        {
            ILogRunner logger = new LogRunner();
            logger.AddLogger(new InMemoryLogger());
            logger.LogMessage("TEST", LogLevels.Fatal);

            Assert.StartsWith("*** FATAL", GetEntryFromLog(logger, 0, 0));
        }

        [Fact]
        public void EachLogOnlyLogsAnEntryOnce()
        {
            ILogRunner logger = new LogRunner();
            logger.AddLogger(new InMemoryLogger());
            logger.AddLogger(new InMemoryLogger());
            logger.AddLogger(new InMemoryLogger());
            logger.LogMessage("entry one", LogLevels.Fatal);

            Assert.Equal(3, CountLogs(logger));
            Assert.Equal(1, countLogEntries(logger, 0));
            Assert.Equal(1, countLogEntries(logger, 1));
            Assert.Equal(1, countLogEntries(logger, 2));
        }

        [Fact]
        public void MultipleLogTypesCanBeAdded()
        {
            ILogRunner logger = new LogRunner();
            logger.AddLogger(new InMemoryLogger());
            logger.AddLogger(new ConsoleLogger());

            Assert.Equal(2, CountLogs(logger));
        }

        [Fact]
        public void ASingleLogCannotBeAddedMultipleTimes()
        {
            ILogRunner logger = new LogRunner();
            InMemoryLogger inMemLog = new InMemoryLogger();
            ConsoleLogger consoleLogger = new ConsoleLogger();
            logger.AddLogger(inMemLog);
            logger.AddLogger(consoleLogger);
            logger.AddLogger(inMemLog);
            logger.AddLogger(consoleLogger);
            logger.AddLogger(inMemLog);
            logger.LogMessage("entry one", LogLevels.Fatal);

            Assert.NotEqual(5, CountLogs(logger));
            Assert.Equal(2, CountLogs(logger));
        }


        #region Helpers
        private string GetEntryFromLog(ILogRunner logger, int logIndex, int entryIndex)
        {
            return ((InMemoryLogger)logger.Loggers[logIndex]).Log[entryIndex];
        }

        private int CountLogs(ILogRunner logger)
        {
            return logger.Loggers.Count;
        }

        private int countLogEntries(ILogRunner logger, int logIndex)
        {
            return ((InMemoryLogger)logger.Loggers[logIndex]).Log.Count;
        }
        #endregion
    }
}
