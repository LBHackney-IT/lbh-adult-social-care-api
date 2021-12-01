using HttpServices.Services.Concrete;
using HttpServices.Services.Contracts;
using LBH.AdultSocialCare.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Security.Authentication;

namespace DataImporter.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureResidentApiClient(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddHttpClient<IResidentsService, ResidentsService>(client =>
                {
                    client.BaseAddress = new Uri(configuration["ResidentsAPI:BaseUrl"]);
                    client.DefaultRequestHeaders.Add("X-Api-Key", configuration["ResidentsAPI:ApiKey"]);
                })
                .ConfigureMessageHandlers();
        }

        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("Default");

            services.AddDbContext<DatabaseContext>(opt
                => opt.UseNpgsql(connectionString, b => b.MigrationsAssembly("LBH.AdultSocialCare.Data")));
        }


        private static IHttpClientBuilder ConfigureMessageHandlers(this IHttpClientBuilder builder)
        {
            return builder.ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
            {
                ClientCertificateOptions = ClientCertificateOption.Automatic,
                SslProtocols = SslProtocols.Tls12,
                AllowAutoRedirect = false,
                UseDefaultCredentials = true
            });
        }
    }
}
