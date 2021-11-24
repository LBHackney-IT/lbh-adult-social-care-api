using DataImporter.Services;
using LBH.AdultSocialCare.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Security.Claims;

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

            services.AddDbContext<DatabaseContext>(
                opt => opt.UseNpgsql(_configuration.GetConnectionString("Default"), b => b.MaxBatchSize(100)));
        }

        public static void ConfigureHttpContext(IServiceProvider services)
        {
            var identity = new ClaimsIdentity();
            var httpContextAccessor = services.GetRequiredService<IHttpContextAccessor>();
            var userIdClaim = new Claim(ClaimTypes.NameIdentifier, "aee45700-af9b-4ab5-bb43-535adbdcfb84");
            identity.AddClaim(userIdClaim);

            httpContextAccessor.HttpContext = new DefaultHttpContext();
            httpContextAccessor.HttpContext.User = new ClaimsPrincipal(identity);
        }

    }
}
