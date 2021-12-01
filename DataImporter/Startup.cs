using DataImporter.Services;
using HttpServices.Services.Concrete;
using HttpServices.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Security.Claims;
using DataImporter.Extensions;

namespace DataImporter
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();

            services.AddScoped<ISupplierDataImport, SupplierDataImport>();
            services.AddScoped<IPackageDataImport, PackageDataImport>();

            services.ConfigureDbContext(_configuration);

            // Configure API clients
            services.AddTransient<IRestClient, JsonRestClient>();
            services.ConfigureResidentApiClient(_configuration);
        }

        public static void ConfigureHttpContext(IServiceProvider services)
        {
            var identity = new ClaimsIdentity();
            var httpContextAccessor = services.GetRequiredService<IHttpContextAccessor>();
            //var userIdClaim = new Claim(ClaimTypes.NameIdentifier, "aee45700-af9b-4ab5-bb43-535adbdcfb84");
            var userIdClaim = new Claim(ClaimTypes.NameIdentifier, "37782d93-6489-4b09-9112-a37b9735006b");

            identity.AddClaim(userIdClaim);

            httpContextAccessor.HttpContext = new DefaultHttpContext();
            httpContextAccessor.HttpContext.User = new ClaimsPrincipal(identity);
        }
    }
}
