using Logging.Services.Shared.Common;
using Logging.Services.Shared.Queues;
using Hangfire;
using Hangfire.Server;
using System.ComponentModel;

namespace Logging.Services.Shared.Interfaces
{
    public interface ICustomLogger
    {
        [Queue(CustomLoggerQueues.CustomLoggerHighPriorityQueueLogMessage)]
        [JobDisplayName("CustomLogger HighPriority Start - {0}")]
        [DisplayName("CustomLogger HighPriority Start - {0}")]
        bool LogMessage(LogMsg msg, PerformContext context);

        [Queue(CustomLoggerQueues.CustomLoggerLowPriorityQueueLogMessage)]
        [JobDisplayName("CustomLogger LowPriority Start - {0}")]
        [DisplayName("CustomLogger LowPriority Start - {0}")]
        bool LogMessageLowPriority(LogMsg msg, PerformContext context);

    }
}
