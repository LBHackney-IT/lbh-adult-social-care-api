using System;
using System.IO;
using System.Threading.Tasks;
using Amazon.Lambda.Core;
using Amazon.Lambda.Serialization.Json;
using Amazon.Lambda.SQSEvents;
using LBH.AdultSocialCare.Functions.Payruns.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LBH.AdultSocialCare.Functions.Payruns
{
    public class LambdaEntryPoint
    {
        private readonly ILogger<LambdaEntryPoint> _logger;
        private readonly DatabaseContext _database;

        // AWS entry point
        public LambdaEntryPoint() : this(InitServices())
        {
        }

        // Local runner / unit tests entry point
        public LambdaEntryPoint(IServiceProvider services)
        {
            _logger = services.GetService<ILogger<LambdaEntryPoint>>();

            var serviceScopeFactory = (IServiceScopeFactory) services.GetService(typeof(IServiceScopeFactory));
            var serviceScope = serviceScopeFactory.CreateScope();

            _database = serviceScope.ServiceProvider.GetRequiredService<DatabaseContext>();
        }

        [LambdaSerializer(typeof(JsonSerializer))]
        public async Task HandleEvent(SQSEvent sqsEvent)
        {
            _logger.LogInformation("Handler call {@SqsEvent}", sqsEvent.Records);

            foreach (var record in sqsEvent.Records)
            {
                _logger.LogInformation("{record.EventSource} Body = {record.Body}", record.EventSource, record.Body);
            }

            var supplier = await _database.Suppliers.FirstOrDefaultAsync();

            _logger.LogWarning("supplier is {SupplierName}", supplier.SupplierName);

            await Task.CompletedTask;
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

            return services.BuildServiceProvider();
        }
    }
}
