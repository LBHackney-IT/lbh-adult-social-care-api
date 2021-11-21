using System;
using System.IO;
using System.Threading.Tasks;
using Amazon.Lambda.Core;
using Amazon.Lambda.SQSEvents;
using LBH.AdultSocialCare.Functions.Payruns.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using JsonSerializer = Amazon.Lambda.Serialization.Json.JsonSerializer;

namespace LBH.AdultSocialCare.Functions.Payruns
{
#pragma warning disable CA1052
    public class LambdaEntryPoint
    {
        [LambdaSerializer(typeof(JsonSerializer))]
        public static async Task HandleEvent(SQSEvent sqsEvent)
        {
            // Lambda constructor is called just one time so create services on each request
            // to ensure that scoped services lifetime (especially DBContext) is short
            var services = InitServices();
            var serviceScopeFactory = (IServiceScopeFactory) services.GetService(typeof(IServiceScopeFactory));

            using (var serviceScope = serviceScopeFactory.CreateScope())
            {
                var logger = services.GetRequiredService<ILogger<LambdaEntryPoint>>();
                var payrunGenerator = serviceScope.ServiceProvider.GetRequiredService<PayrunGenerator>();

                logger.LogInformation("Received SQS event {SqsEvent}", JsonConvert.SerializeObject(sqsEvent, Formatting.Indented));

                try
                {
                    await payrunGenerator.GenerateAsync();
                }
                catch (Exception ex)
                {
                    logger.LogError("Unhandled exception {Exception}", ex);
                    throw;
                }
            }
        }

        private static IServiceProvider InitServices()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            var services = new ServiceCollection();
            services.AddSingleton(config);

            var startup = new Startup(config, new AwsHostEnvironment());
            startup.ConfigureServices(services);

            var serviceProvider = services.BuildServiceProvider();
            Startup.ConfigureHttpContext(serviceProvider);

            return serviceProvider;
        }
    }
#pragma warning restore CA1052
}
