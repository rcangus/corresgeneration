using Shared.Logging.Common;
using Shared.Logging.Interfaces;
using Hangfire.Server;
using Microsoft.Extensions.Logging;
using System;

namespace DCS.Service.Logging.CustomLogger.Common
{
    public class Logger : ICustomLogger
    {

        readonly ILogger<Logger> _logger;

        public Logger(ILogger<Logger> log)
        {
            _logger = log;
        }

        /// <summary>
        /// Methdo to call the currently configured logging system to log the message
        /// </summary>
        /// <param name="msg">The populated DcsLogMsg to log</param>
        /// <param name="context">The Hang</param>
        /// <returns></returns>
        public bool LogMessage(LogMsg msg, PerformContext context)
        {
            //This is the method that actually does the logging and is called from Hangfire.
            //We are jsut going to write to a database

            //_log.LogInformation("{msg.LogDatetime} - {msg.LogLevel} - {msg.Server} - {msg.Application} - {msg.GSScheduleId} - {msg.JGScheduleId} - {msg.JSScheduleId} - {msg.BatchId} - {msg.Message}", msg.LogDatetime, msg.LogLevel, msg.Server, msg.Application, msg.GSScheduleId, msg.JGScheduleId, msg.JSScheduleId, msg.BatchId, msg.Message);
            
            switch (msg.LogLevel)
            {
                case LogLevel.Trace:
                    _logger.LogTrace(msg.ToString());
                    break; ;

                case LogLevel.Debug:
                    _logger.LogDebug(msg.ToString());
                    break; ;

                case LogLevel.Information:
                    _logger.LogInformation(msg.ToString());
                    break;

                case LogLevel.Warning:
                    _logger.LogWarning(msg.ToString());
                    break;

                case LogLevel.Error:
                    _logger.LogError(new Exception(msg.ExceptionMessage + ";" + msg.ExceptionStackTracce), msg.ToString());
                    break;

                case LogLevel.None:
                    break;
            }
            return true;
        }
    }
}
