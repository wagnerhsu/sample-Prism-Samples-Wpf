using NLog;
using Prism.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prism01
{
    public class CustomLogger : ILoggerFacade
    {
        ILogger Logger;
        public void CreateLogger(ILogger logger)
        {
            Logger = logger;
        }
        public void Log(string message, Category category, Priority priority)
        {
            Logger.Log(LogLevel.Info, message);
        }
    }
}
