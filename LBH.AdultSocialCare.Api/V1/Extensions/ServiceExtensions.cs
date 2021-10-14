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
using System.Diagnostics;
using System.Net.Http;
using System.Reflection;
using System.Security.Authentication;
using System.Text;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace LBH.AdultSocialCare.Api.V1.Extensions
{

    public static class ServiceExtensions
    {

        public static void ConfigureTransactionsApiClient(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddHttpClient<ITransactionsService, TransactionsService>(client =>
                {
                    client.BaseAddress = new Uri(configuration["HASCHttpClients:TransactionsBaseUrl"]);
                    client.DefaultRequestHeaders.Add("x-api-key", configuration["HASCHttpClients:TransactionsApiKey"]);
                })
                .ConfigureMessageHandlers();
        }

        public static void ConfigureResidentApiClient(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddHttpClient<IResidentsService, ResidentsService>(client =>
                {
                    client.BaseAddress = new Uri(configuration["ResidentsAPI:BaseUrl"]);
                })
                .ConfigureMessageHandlers();
        }

        public static void ConfigureIdentityService(this IServiceCollection services) => services.AddIdentity<User, Role>(
                o =>
                {
                    o.SignIn.RequireConfirmedAccount = false;
                    o.Password.RequireDigit = true;
                    o.Password.RequireLowercase = false;
                    o.Password.RequireUppercase = false;
                    o.Password.RequireNonAlphanumeric = false;
                    o.Password.RequiredLength = 8;
                    o.User.RequireUniqueEmail = true;
                })
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

        public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("JwtSettings");

            // var secretKey = Environment.GetEnvironmentVariable("SECRET");
            var secretKey = jwtSettings.GetSection("securityKey").Value;

            services.AddAuthentication(opt =>
                {
                    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings.GetSection("validIssuer").Value,
                        ValidAudience = jwtSettings.GetSection("validAudience").Value,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                        ClockSkew = Debugger.IsAttached
                            ? TimeSpan.Zero
                            : TimeSpan.FromMinutes(10)
                    };
                });
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
