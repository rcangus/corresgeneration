using DCS.Shared.Logging.Common;
using DCS.Shared.Logging.Queues;
using Hangfire;
using Hangfire.Server;
using System.ComponentModel;

namespace DCS.Shared.Logging.Interfaces
{
    public interface IDCSLogger
    {
        [Queue(DCSLoggerQueues.DCSLoggerQueueLogMessage)]
        [JobDisplayName("DataRetrieve Start - {0}")]
        [DisplayName("DataRetrieve Start - {0}")]
        bool LogMessage(DCSLogMsg msg, PerformContext context);

    }
}
