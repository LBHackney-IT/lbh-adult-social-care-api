using System;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using HttpServices.Services.Contracts;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;

namespace LBH.AdultSocialCare.Api.Tests
{
    public class MockWebApplicationFactory : WebApplicationFactory<Startup>
    {
        private TestRestClient _restClient;
        private DatabaseContext _databaseContext;
        private DataGenerator _dataGenerator;
        private SqliteConnection _connection;

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
                    _databaseContext.Database.EnsureCreated();
                }

                return _databaseContext;
            }
        }

        public DataGenerator DataGenerator => _dataGenerator ??= new DataGenerator(Database);

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            if (builder is null) throw new ArgumentNullException(nameof(builder));

            builder.ConfigureTestServices(services =>
            {
                services.RemoveAll<IRestClient>();
                services.AddScoped(provider => Mock.Of<IRestClient>()); // TODO: Configure to intercept Transaction API calls

                ConfigureHttpContextAccessor(services);
                ConfigureAuthentication(services);
                ConfigureDatabaseContext(services);
            });
        }

        private static void ConfigureHttpContextAccessor(IServiceCollection services)
        {
            services.RemoveAll<IHttpContextAccessor>();

            var accessorMock = new Mock<IHttpContextAccessor>();
            var context = new DefaultHttpContext();
            var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.NameIdentifier, "aee45700-af9b-4ab5-bb43-535adbdcfb84") });

            context.User = new ClaimsPrincipal(identity);

            accessorMock
                .SetupGet(a => a.HttpContext)
                .Returns(context);

            services.AddSingleton(provider => accessorMock.Object);
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

        private void ConfigureDatabaseContext(IServiceCollection services)
        {
            // Remove development database from services
            var dbContextDescriptor = services.SingleOrDefault(
                d => d.ServiceType ==
                     typeof(DbContextOptions<DatabaseContext>));

            if (dbContextDescriptor != null)
            {
                services.Remove(dbContextDescriptor);
            }

            var connectionString = new SqliteConnectionStringBuilder { DataSource = ":memory:" }.ToString();
            _connection = new SqliteConnection(connectionString);
            _connection.Open();

            // scoped instance will be cleaned with each API call, so it's impossible to operate with DB directly
            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlite(_connection);
                // options
                //     .UseInMemoryDatabase($"HASC.API.E2E.TESTS.{DateTime.Now.Ticks}")
                //     .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning));
            }, ServiceLifetime.Singleton);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _connection?.Close();
                _connection?.Dispose();
                _databaseContext?.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
