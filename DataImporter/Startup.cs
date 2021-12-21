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
            var userIdClaim = new Claim(ClaimTypes.NameIdentifier, "75996f73-3a1a-4efa-8729-eb4a48c465b0");

            identity.AddClaim(userIdClaim);

            httpContextAccessor.HttpContext = new DefaultHttpContext();
            httpContextAccessor.HttpContext.User = new ClaimsPrincipal(identity);
        }
    }
}
