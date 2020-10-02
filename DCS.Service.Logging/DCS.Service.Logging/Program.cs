using DCS.Service.Logging.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Configuration;

namespace DCS.Service.Logging
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseWindowsService()
                //.ConfigureLogging(logging =>
                //{
                //    AppConfig cfg = new AppConfig();
                //    logging.ClearProviders();
                //    logging.AddEventLog(logSettigns =>
                //    {
                //        logSettigns.SourceName = cfg.EventLogServiceName + cfg.Env;
                //    });

                //    logging.AddFile(cfg.LogFilePath, isJson: true);
                //    logging.AddSeq(Configuration.GetSection("Seq"));
                //})
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureKestrel(serverOptions =>
                    {
                        serverOptions.Limits.MaxConcurrentConnections = 50000;
                        serverOptions.Limits.RequestHeadersTimeout = TimeSpan.FromMinutes(5);

                    });
                    AppConfig cfg = new AppConfig();
                    webBuilder.UseUrls(cfg.APIURL);
                    webBuilder.UseStartup<Startup>();


                });
                }
}
