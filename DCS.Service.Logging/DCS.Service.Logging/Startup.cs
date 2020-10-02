using Hangfire;
using Hangfire.JobsLogger;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using DCS.Service.Logging.Common;
using DCS.Shared.Logging.Interfaces;
using DCS.Shared.Logging.Queues;
using Microsoft.Extensions.Logging;

namespace DCS.Service.Logging
{
    public class Startup
    {
        AppConfig cfg = new AppConfig();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(loggingBuilder =>
            {
                AppConfig cfg = new AppConfig();
                loggingBuilder.ClearProviders();

                loggingBuilder.AddFile(Configuration.GetSection("Logging"))
                                .AddEventLog(logSettigns =>
                                {
                                    logSettigns.SourceName = cfg.EventLogServiceName + cfg.Env;
                                })
                               .AddSeq(Configuration.GetSection("Seq"));

                //    logging.AddSeq(Configuration.GetSection("Seq"));
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "DCS Logging API",
                    Version = "v1",
                    Description = "The DCS Logging API used to manage the Dcs.Services.Logging service via a REST endpoint",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "ATO",
                        Email = "dcs@ato.gov.au",
                        Url = new Uri("https://www.ato.gov.au")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "use under licx",
                        Url = new Uri("https://exmaple.com/license")
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });


        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DCS.Service.Logging API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
