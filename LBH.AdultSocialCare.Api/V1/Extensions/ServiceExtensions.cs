using HttpServices.Services.Concrete;
using HttpServices.Services.Contracts;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Reflection;

namespace LBH.AdultSocialCare.Api.V1.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureTransactionsService(this IServiceCollection services, IConfiguration configuration) => services
            .AddHttpClient<ITransactionsService, TransactionsService>(client =>
            {
                client.BaseAddress = new Uri(configuration["HASCHttpClients:TransactionsBaseUrl"]);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("User-Agent", "HASC API");
            });

        public static void ConfigureIdentityService(this IServiceCollection services) => services
            .AddIdentity<User, Role>(options => options.SignIn.RequireConfirmedAccount = false)
            .AddEntityFrameworkStores<DatabaseContext>()
            .AddDefaultTokenProviders();

        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING") ??
                                      configuration.GetConnectionString("DatabaseConnectionString");

            string assemblyName = Assembly.GetCallingAssembly().GetName().Name;

            /*services.AddDbContext<DatabaseContext>(
                opt => opt.UseNpgsql(connectionString, b => b.MigrationsAssembly(assemblyName)).AddXRayInterceptor(true));*/

            services.AddDbContext<DatabaseContext>(opt
                => opt.UseNpgsql(connectionString, b => b.MigrationsAssembly(assemblyName)));
        }

        public static void ConfigureLogging(this IServiceCollection services, IConfiguration configuration)
        {
            // We rebuild the logging stack so as to ensure the console logger is not used in production.
            // See here: https://weblog.west-wind.com/posts/2018/Dec/31/Dont-let-ASPNET-Core-Default-Console-Logging-Slow-your-App-down
            services.AddLogging(config =>
            {
                // Clear out default configuration
                config.ClearProviders();

                config.AddConfiguration(configuration.GetSection("Logging"));
                config.AddDebug();
                config.AddEventSourceLogger();

                if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == Environments.Development)
                {
                    config.AddConsole();
                }
            });
        }
    }
}
