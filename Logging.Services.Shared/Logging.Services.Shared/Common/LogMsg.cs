using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Logging.Services.Shared.Common
{
    public class LogMsg
    {
        private static readonly HttpClient client = new HttpClient();

        [JsonPropertyName("log_date_time")]
        public DateTime LogDatetime { get; set; }

        [JsonPropertyName("log_level")]
        public LogLevel LogLevel { get; set; }

        [JsonPropertyName("server")]
        public string Server { get; set; }

        [JsonPropertyName("application_name")]
        public string Application { get; set; }

        [JsonPropertyName("application_version")]
        public string ApplicationVersion { get; set; }

        [JsonPropertyName("gs_schedule_id")]
        public Guid GSScheduleId { get; set; }

        [JsonPropertyName("jg_schedule_id")]
        public Guid JGScheduleId { get; set; }

        [JsonPropertyName("js_schedule_id")]
        public Guid JSScheduleId { get; set; }

        public int DeliveryChannel { get; set; }

        public string NatDins { get; set; }

        [JsonPropertyName("batch_id")]
        public long BatchId { get; set; }

        public string ExceptionMessage { get; set; }
        public string ExceptionStackTracce { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();

            sb.Append("LogDateTime: ");
            sb.Append(LogDatetime.ToString("yyyy-MM-dd HH:ss:mm"));
            sb.Append("; ");
            sb.Append("LogLevel: ");
            sb.Append(LogLevel.ToString());
            sb.Append("; ");
            sb.Append("Server: ");
            sb.Append(Server);
            sb.Append("; ");
            sb.Append("Application: ");
            sb.Append(Application);
            sb.Append("; ");
            sb.Append("ApplicationVersion: ");
            sb.Append(ApplicationVersion);
            sb.Append("; ");
            sb.Append("GSScheduleId: ");
            sb.Append(GSScheduleId.ToString());
            sb.Append("; ");
            sb.Append("JGScheduleId: ");
            sb.Append(JSScheduleId);
            sb.Append("; ");
            sb.Append("JSScheduleId: ");
            sb.Append(JSScheduleId);
            sb.Append("; ");
            sb.Append("DeliveryChannel: ");
            sb.Append(DeliveryChannel);
            sb.Append("; ");
            sb.Append("NatDins: ");
            sb.Append(NatDins);
            sb.Append("; ");
            sb.Append("BatchId: ");
            sb.Append(BatchId);
            sb.Append("; ");
            sb.Append("ExceptionMessage: ");
            sb.Append(ExceptionMessage);
            sb.Append("; ");
            sb.Append("ExceptionStackTracce: ");
            sb.Append(ExceptionStackTracce);
            sb.Append("; ");
            sb.Append("Message: ");
            sb.Append(Message);

            return sb.ToString();

        }

        public string ToJsonString()
        {
            return JsonSerializer.Serialize<LogMsg>(this);
        }

        /// <summary>
        /// Method to write to a central logging service as well as the passed in fileLogger
        /// </summary>
        /// <param name="fileLogger">The instantiated ILogger isntance. Can be anything</param>
        /// <param name="logServiceUrl">The URL to use for the central logging service. If empty then it is not called</param>
        /// <param name="level">The log level to use</param>
        /// <param name="logMsg">TODO: Remove this</param>
        /// <param name="messageToLog">The message to log</param>
        /// <param name="ex">If you want to record exception details pass this in. Otherwise leave as null</param>
        /// <returns></returns>
        public async Task WriteLogEntry(ILogger fileLogger, string logServiceUrl, LogLevel level, string messageToLog, Exception ex)
        {
            this.LogLevel = level;
            this.Message = messageToLog;

            try
            {
                switch (this.LogLevel)
                {
                    case LogLevel.Trace:
                        fileLogger.LogTrace("{LogDatetime} - {LogLevel} - {Server} - {Application} - {ApplicationVersion} - {GSScheduleId} - {JGScheduleId} - {JSScheduleId} - {DeliveryChannel} - {NatDins} - {BatchId} - {Message} - {ExceptionMessage} - {ExceptionStackTracce}", this.LogDatetime, this.LogLevel, this.Server, this.Application, this.ApplicationVersion, this.GSScheduleId, this.JGScheduleId, this.JSScheduleId,this.DeliveryChannel, this.NatDins, this.BatchId, this.Message, this.ExceptionMessage, this.ExceptionStackTracce);
                        break;
                    case LogLevel.Debug:
                        fileLogger.LogDebug("{LogDatetime} - {LogLevel} - {Server} - {Application} - {ApplicationVersion} - {GSScheduleId} - {JGScheduleId} - {JSScheduleId} - {DeliveryChannel} - {NatDins} - {BatchId} - {Message} - {ExceptionMessage} - {ExceptionStackTracce}", this.LogDatetime, this.LogLevel, this.Server, this.Application, this.ApplicationVersion, this.GSScheduleId, this.JGScheduleId, this.JSScheduleId, this.DeliveryChannel, this.NatDins, this.BatchId, this.Message, this.ExceptionMessage, this.ExceptionStackTracce);
                        break;
                    case LogLevel.Information:
                        fileLogger.LogInformation("{LogDatetime} - {LogLevel} - {Server} - {Application} - {ApplicationVersion} - {GSScheduleId} - {JGScheduleId} - {JSScheduleId} - {DeliveryChannel} - {NatDins} - {BatchId} - {Message} - {ExceptionMessage} - {ExceptionStackTracce}", this.LogDatetime, this.LogLevel, this.Server, this.Application, this.ApplicationVersion, this.GSScheduleId, this.JGScheduleId, this.JSScheduleId, this.DeliveryChannel, this.NatDins, this.BatchId, this.Message, this.ExceptionMessage, this.ExceptionStackTracce);
                        break;
                    case LogLevel.Warning:
                        fileLogger.LogWarning("{LogDatetime} - {LogLevel} - {Server} - {Application} - {ApplicationVersion} - {GSScheduleId} - {JGScheduleId} - {JSScheduleId} - {DeliveryChannel} - {NatDins} - {BatchId} - {Message} - {ExceptionMessage} - {ExceptionStackTracce}", this.LogDatetime, this.LogLevel, this.Server, this.Application, this.ApplicationVersion, this.GSScheduleId, this.JGScheduleId, this.JSScheduleId, this.DeliveryChannel, this.NatDins, this.BatchId, this.Message, this.ExceptionMessage, this.ExceptionStackTracce);
                        break;
                    case LogLevel.Error:
                        if (ex == null)
                        {
                            fileLogger.LogError(null, "{LogDatetime} - {LogLevel} - {Server} - {Application} - {ApplicationVersion} - {GSScheduleId} - {JGScheduleId} - {JSScheduleId} - {DeliveryChannel} - {NatDins} - {BatchId} - {Message} - {ExceptionMessage} - {ExceptionStackTracce}", this.LogDatetime, this.LogLevel, this.Server, this.Application, this.ApplicationVersion, this.GSScheduleId, this.JGScheduleId, this.JSScheduleId, this.DeliveryChannel, this.NatDins, this.BatchId, this.Message, this.ExceptionMessage, this.ExceptionStackTracce);
                        } else
                        {
                            fileLogger.LogError(ex, "{LogDatetime} - {LogLevel} - {Server} - {Application} - {ApplicationVersion} - {GSScheduleId} - {JGScheduleId} - {JSScheduleId} - {DeliveryChannel} - {NatDins} - {BatchId} - {Message} - {ExceptionMessage} - {ExceptionStackTracce}", this.LogDatetime, this.LogLevel, this.Server, this.Application, this.ApplicationVersion, this.GSScheduleId, this.JGScheduleId, this.JSScheduleId, this.DeliveryChannel, this.NatDins, this.BatchId, this.Message, this.ExceptionMessage, this.ExceptionStackTracce);
                        }
                        break;
                    case LogLevel.Critical:
                        fileLogger.LogCritical("{LogDatetime} - {LogLevel} - {Server} - {Application} - {ApplicationVersion} - {GSScheduleId} - {JGScheduleId} - {JSScheduleId} - {DeliveryChannel} - {NatDins} - {BatchId} - {Message} - {ExceptionMessage} - {ExceptionStackTracce}", this.LogDatetime, this.LogLevel, this.Server, this.Application, this.ApplicationVersion, this.GSScheduleId, this.JGScheduleId, this.JSScheduleId, this.DeliveryChannel, this.NatDins, this.BatchId, this.Message, this.ExceptionMessage, this.ExceptionStackTracce);
                        break;
                    case LogLevel.None:

                        break;
                    default:
                        break;
                }
                if (!string.IsNullOrWhiteSpace(logServiceUrl))
                {
                    StringContent content = new StringContent(JsonSerializer.Serialize(this), Encoding.UTF8, "application/json");
                    using (var response = await client.PostAsync(logServiceUrl, content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                    }
                }

            }
            catch (Exception writeLogEx)
            {
                fileLogger.LogError($"Error logging to central logger: {writeLogEx.Message} = {writeLogEx.StackTrace}");
            }
        }
    }
}
