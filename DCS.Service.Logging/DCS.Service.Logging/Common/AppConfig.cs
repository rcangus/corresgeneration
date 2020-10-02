using System;
using System.Configuration;
using System.Reflection;

namespace DCS.Service.Logging.Common
{
    public class AppConfig
    {
        /// <summary>
        /// The Connection SAtring for the Outbound database
        /// </summary>
        /// public string OutboundCorroGen { get { return ConfigurationManager.ConnectionStrings["OutboundCorroGen"].ConnectionString; } }
        public static string OutboundCorroGen { get { return ConfigurationManager.ConnectionStrings["OutboundCorroGen"].ConnectionString; } }
        //public static string OutboundCorroGen => ConfigurationManager.ConnectionStrings["OutboundCorroGen"].ConnectionString;

        /// <summary>
        /// The connections tring for the hangfire database
        /// </summary>
        public string HangfireDb { get { return ConfigurationManager.ConnectionStrings["Hangfire"].ConnectionString; } }
        //public static string HangfireDb => ConfigurationManager.ConnectionStrings["Hangfire"].ConnectionString;

        public string LoggingDatabase { get; set; }

        /// <summary>
        /// The environment we are in. e.g. DEM,DEQ, etc
        /// </summary>
        public string Env => ConfigurationManager.AppSettings.Get("Env");
        //public static string Env => ConfigurationManager.AppSettings.Get("Env");

        /// <summary>
        /// The numebr of days to filte the corresrequests on. Positive value only
        /// </summary>
        public string DaysToFilter => ConfigurationManager.AppSettings.Get("DaysToFilter");

        /// <summary>
        /// The number of worker threads that Hangfire will use
        /// </summary>
        public string HangfireWorkerCount => ConfigurationManager.AppSettings.Get("HangfireWorkerCount");

        /// <summary>
        /// Teh user string to record batchhostry updates against
        /// </summary>
        public string UserToRecordAgainst => ConfigurationManager.AppSettings.Get("UserToRecordAgainst");

        /// <summary>
        /// The name of the Event Source for the WIndows EWvent log
        /// </summary>
        public string EventLogServiceName => ConfigurationManager.AppSettings.Get("EventLogServiceName");

        /// <summary>
        /// The path to the service log file
        /// </summary>
        public string LogFilePath => ConfigurationManager.AppSettings.Get("LogFilePath");


        /// <summary>
        /// The API REST Endpopint to use
        /// </summary>
        public string APIURL => ConfigurationManager.AppSettings.Get("APIURL");

        /// <summary>
        /// Returns the version of the application
        /// </summary>
        public Version Version => Assembly.GetExecutingAssembly().GetName().Version;

        /// <summary>
        /// Returns the name of the server that is currently executing the code
        /// </summary>
        public string Server => Environment.MachineName;
    }
}
