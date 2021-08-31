using System;
using System.Linq;
using System.Net.Http;
using HttpServices.Services.Contracts;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace LBH.AdultSocialCare.Api.Tests
{
    public class MockWebApplicationFactory : WebApplicationFactory<Startup>
    {
        private TestRestClient _restClient;
        private DatabaseContext _databaseContext;

        public TestRestClient RestClient
        {
            get
            {
                if (_restClient is null)
                {
                    var httpClient = CreateClient();
                    _restClient = new TestRestClient(httpClient);
                }

                return _restClient;
            }
        }

        public DatabaseContext Database
        {
            get
            {
                if (_databaseContext is null)
                {
                    var scopeFactory = Server.Host.Services.GetService<IServiceScopeFactory>();
                    var scope = scopeFactory.CreateScope();
                    _databaseContext = scope.ServiceProvider.GetService<DatabaseContext>();
                }

                return _databaseContext;
            }
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            if (builder is null) throw new ArgumentNullException(nameof(builder));

            builder.ConfigureTestServices(services =>
            {
                services.RemoveAll<IRestClient>();

                ConfigureAuthentication(services);
                ConfigureDatabaseContext(services);
            });
        }

        protected override void ConfigureClient(HttpClient client)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));

            client.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        private static void ConfigureAuthentication(IServiceCollection services)
        {
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = "TestAuthentication";
                })
                .AddScheme<AuthenticationSchemeOptions, MockAuthenticationHandler>("TestAuthentication", options => { });
        }

        private static void ConfigureDatabaseContext(IServiceCollection services)
        {
            // Remove development database from services
            var dbContextDescriptor = services.SingleOrDefault(
                d => d.ServiceType ==
                     typeof(DbContextOptions<DatabaseContext>));

            if (dbContextDescriptor != null)
            {
                services.Remove(dbContextDescriptor);
            }

            // scoped instance will be cleaned with each API call, so it's impossible to operate with DB directly
            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseInMemoryDatabase($"HASC.API.E2E.TESTS.{DateTime.Now.Ticks}");
            }, ServiceLifetime.Singleton);
        }
    }
}
