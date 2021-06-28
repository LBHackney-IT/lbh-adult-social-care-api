using HttpServices.Services.Concrete;
using HttpServices.Services.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

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

        public static void ConfigureSwagger(this IServiceCollection services, List<ApiVersionDescription> apiVersions, string apiName) => services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("Token", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Your Hackney API Key",
                Name = "X-Api-Key",
                Type = SecuritySchemeType.ApiKey
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme, Id = "Token"
                            }
                        },
                        new List<string>()
                    }
                });

            // Looks at the APIVersionAttribute [ApiVersion("x")] on controllers and decides whether or not
            // to include it in that version of the swagger document
            // Controllers must have this [ApiVersion("x")] to be included in swagger documentation!!
            c.DocInclusionPredicate((docName, apiDesc) =>
            {
                apiDesc.TryGetMethodInfo(out MethodInfo methodInfo);

                List<ApiVersion> versions = methodInfo?.DeclaringType?.GetCustomAttributes()
                    .OfType<ApiVersionAttribute>()
                    .SelectMany(attr => attr.Versions)
                    .ToList();

                return versions?.Any(v => $"{v.GetFormattedApiVersion()}" == docName) ?? false;
            });

            // Get every ApiVersion attribute specified and create swagger docs for them
            foreach (string version in apiVersions.Select(apiVersion => $"v{apiVersion.ApiVersion}"))
            {
                c.SwaggerDoc(version, new OpenApiInfo
                {
                    Title = $"{apiName}-api {version}",
                    Version = version,
                    Description =
                        $"{apiName} version {version}. Please check older versions for depreciated endpoints."
                });
            }

            c.CustomSchemaIds(x => x.FullName);

            // Set the comments path for the Swagger JSON and UI.
            string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

            if (File.Exists(xmlPath))
                c.IncludeXmlComments(xmlPath);
        });

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
