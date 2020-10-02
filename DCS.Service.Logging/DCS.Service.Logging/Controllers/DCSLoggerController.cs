using DCS.Service.Logging.Common;
using DCS.Shared.Logging.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;

namespace DCS.Service.Logging.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DCSLoggerController : ControllerBase
    {
        IConfiguration _config;
        ILogger<DCSLoggerController> _logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        public DCSLoggerController(ILogger<DCSLoggerController> log)
        {
            _logger = log;
        }

        /// <summary>
        /// Method to log the entry to the configured log end point
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("LogMessage")]
        public JsonResult LogMessage(DCSLogMsg msg)
        {
            switch (msg.LogLevel)
            {
                case LogLevel.Trace:
                    _logger.LogTrace("{LogDatetime} - {LogLevel} - {Server} - {Application} - {ApplicationVersion} - {GSScheduleId} - {JGScheduleId} - {JSScheduleId} - {DeliveryChannel} - {NatDins} - {BatchId} - {Message} - {ExceptionMessage} - {ExceptionStackTracce}", msg.LogDatetime, msg.LogLevel, msg.Server, msg.Application, msg.ApplicationVersion, msg.GSScheduleId, msg.JGScheduleId, msg.JSScheduleId, msg.DeliveryChannel, msg.NatDins, msg.BatchId, msg.Message, msg.ExceptionMessage, msg.ExceptionStackTracce);
                    break; ;

                case LogLevel.Debug:
                    _logger.LogDebug("{LogDatetime} - {LogLevel} - {Server} - {Application} - {ApplicationVersion} - {GSScheduleId} - {JGScheduleId} - {JSScheduleId} - {DeliveryChannel} - {NatDins} - {BatchId} - {Message} - {ExceptionMessage} - {ExceptionStackTracce}", msg.LogDatetime, msg.LogLevel, msg.Server, msg.Application, msg.ApplicationVersion, msg.GSScheduleId, msg.JGScheduleId, msg.JSScheduleId, msg.DeliveryChannel, msg.NatDins, msg.BatchId, msg.Message, msg.ExceptionMessage, msg.ExceptionStackTracce);
                    break; ;

                case LogLevel.Information:
                    _logger.LogInformation("{LogDatetime} - {LogLevel} - {Server} - {Application} - {ApplicationVersion} - {GSScheduleId} - {JGScheduleId} - {JSScheduleId} - {DeliveryChannel} - {NatDins} - {BatchId} - {Message} - {ExceptionMessage} - {ExceptionStackTracce}", msg.LogDatetime, msg.LogLevel, msg.Server, msg.Application, msg.ApplicationVersion, msg.GSScheduleId, msg.JGScheduleId, msg.JSScheduleId, msg.DeliveryChannel, msg.NatDins, msg.BatchId, msg.Message, msg.ExceptionMessage, msg.ExceptionStackTracce);
                    break;

                case LogLevel.Warning:
                    _logger.LogWarning("{LogDatetime} - {LogLevel} - {Server} - {Application} - {ApplicationVersion} - {GSScheduleId} - {JGScheduleId} - {JSScheduleId} - {DeliveryChannel} - {NatDins} - {BatchId} - {Message} - {ExceptionMessage} - {ExceptionStackTracce}", msg.LogDatetime, msg.LogLevel, msg.Server, msg.Application, msg.ApplicationVersion, msg.GSScheduleId, msg.JGScheduleId, msg.JSScheduleId, msg.BatchId, msg.DeliveryChannel, msg.NatDins, msg.Message, msg.ExceptionMessage, msg.ExceptionStackTracce);
                    break;

                case LogLevel.Error:
                    _logger.LogError(new Exception(msg.ExceptionMessage + ";" + msg.ExceptionStackTracce), "{LogDatetime} - {LogLevel} - {Server} - {Application} - {ApplicationVersion} - {GSScheduleId} - {JGScheduleId} - {JSScheduleId} - {DeliveryChannel} - {NatDins} - {BatchId} - {Message} - {ExceptionMessage} - {ExceptionStackTracce}", msg.LogDatetime, msg.LogLevel, msg.Server, msg.Application, msg.ApplicationVersion, msg.GSScheduleId, msg.JGScheduleId, msg.JSScheduleId, msg.DeliveryChannel, msg.NatDins, msg.BatchId, msg.Message, msg.ExceptionMessage, msg.ExceptionStackTracce);
                    break;

                case LogLevel.None:
                    break;
            }

            return new JsonResult(true);
        }

        /// <summary>
        /// Method to get the current config entries for the application. Returns as a string.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCurrentConfig")]
        public JsonResult GetCurrentConfig()
        {
            AppConfig cfg = new AppConfig();
            return new JsonResult(cfg);
        }

        /// <summary>
        /// Method to get the heartbeat of the service. Provided so that other apps can query the service
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Heartbeat")]
        public JsonResult Heartbeat()
        {
            return new JsonResult("running");
        }
    }
}

