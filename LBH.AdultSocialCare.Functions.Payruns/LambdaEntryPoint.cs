using System;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;
using Amazon.Lambda.Core;
using Amazon.Lambda.SQSEvents;
using LBH.AdultSocialCare.Functions.Payruns.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using JsonSerializer = Amazon.Lambda.Serialization.Json.JsonSerializer;

namespace LBH.AdultSocialCare.Functions.Payruns
{
    public class LambdaEntryPoint
    {
        private readonly ILogger<LambdaEntryPoint> _logger;
        private readonly PayrunGenerator _payrunGenerator;

        // AWS entry point
        // ReSharper disable once UnusedMember.Global
        public LambdaEntryPoint() : this(InitServices())
        {

        }

        // Local runner / unit tests entry point
        public LambdaEntryPoint(IServiceProvider services)
        {
            var identity = new ClaimsIdentity();
            var httpContextAccessor = services.GetRequiredService<IHttpContextAccessor>();

            httpContextAccessor.HttpContext = new DefaultHttpContext();
            httpContextAccessor.HttpContext.User = new ClaimsPrincipal(identity);

            _logger = services.GetService<ILogger<LambdaEntryPoint>>();

            var serviceScopeFactory = (IServiceScopeFactory) services.GetService(typeof(IServiceScopeFactory));
            var serviceScope = serviceScopeFactory.CreateScope();

            _payrunGenerator = serviceScope.ServiceProvider.GetRequiredService<PayrunGenerator>();
        }

        [LambdaSerializer(typeof(JsonSerializer))]
        public async Task HandleEvent(SQSEvent sqsEvent)
        {
            _logger.LogInformation("Received SQS event {SqsEvent}", JsonConvert.SerializeObject(sqsEvent, Formatting.Indented));

            try
            {
                await _payrunGenerator.GenerateAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("Unhandled exception {Exception}", ex);
                throw;
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

            return services.BuildServiceProvider();
        }
    }
}
