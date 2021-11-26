using DataImporter.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace DataImporter
{
    class Program
    {
        private readonly IConfiguration _configuration;
        static void Main(string[] args)
        {
            var serviceProvider = InitService();

            var supplierDataImport = serviceProvider.GetRequiredService<ISupplierDataImport>();
            var residentialDataImport = serviceProvider.GetRequiredService<IResidentialCareDataImport>();

            //supplierDataImport.Import("supplier-data.xlsx");
            residentialDataImport.Import("residential-data.xlsx");
        }


        private static IServiceProvider InitService()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            var services = new ServiceCollection();
            services.AddSingleton(config);

            var startup = new Startup(config);
            startup.ConfigureServices(services);

            var serviceProvider = services.BuildServiceProvider();
            Startup.ConfigureHttpContext(serviceProvider);

            return serviceProvider;
        }
    }
}
