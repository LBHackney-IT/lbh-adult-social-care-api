using DataImporter.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading.Tasks;

namespace DataImporter
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var serviceProvider = InitService();

            var supplierDataImport = serviceProvider.GetRequiredService<ISupplierDataImport>();
            var packageDataImport = serviceProvider.GetRequiredService<IPackageDataImport>();

            //supplierDataImport.Import("supplier-data.xlsx");
            // await packageDataImport.Import("residential-data.xlsx");
            await packageDataImport.Import("nursing-data.xlsx");
        }


        private static IServiceProvider InitService()
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environmentName}.json", true, true)
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
