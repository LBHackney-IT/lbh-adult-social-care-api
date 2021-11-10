using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Amazon.Lambda.SQSEvents;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Functions.Payruns.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LBH.AdultSocialCare.Functions.Payruns
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly IHostEnvironment _environment;

        public Startup(IConfiguration configuration, IHostEnvironment environment)
        {
            _configuration = configuration;
            _environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DatabaseContext>(
                opt => opt.UseNpgsql(_configuration.GetConnectionString("Default")));

            services.AddLogging(ConfigureLogging);
        }

        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.Run(async context => await HandleRequest(context, app.ApplicationServices));
            }
        }

        private void ConfigureLogging(ILoggingBuilder logging)
        {
            var loggingConfig = _configuration.GetSection("Logging");

            logging.ClearProviders();
            logging.AddConfiguration(loggingConfig);
            logging.AddEventSourceLogger();

            if (_environment.IsDevelopment())
            {
                logging.AddDebug();
                logging.AddConsole();
            }
            else
            {
                logging.AddLambdaLogger(new LambdaLoggerOptions(loggingConfig));
            }
        }

        private static async Task HandleRequest(HttpContext context, IServiceProvider services)
        {
            using var streamReader = new StreamReader(context.Request.Body);

            var jsonRequest = await streamReader.ReadToEndAsync();
            var sqsEvent = new SQSEvent
            {
                Records = new List<SQSEvent.SQSMessage>
                {
                    new SQSEvent.SQSMessage
                    {
                        Body = jsonRequest
                    }
                }
            };

            await new LambdaEntryPoint(services).HandleEvent(sqsEvent);
        }
    }
}
