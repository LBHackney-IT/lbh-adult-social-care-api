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
        private readonly SqliteConnection _connection;

        public MockWebApplicationFactory()
        {
            var connectionString = $"DataSource=file:DB{Guid.NewGuid()}?mode=memory&cache=shared";

            _connection = new SqliteConnection(connectionString);
            _connection.Open(); // connection should stay open to keep SQLite in-memory database alive

            CreateDatabaseContext();

            DataGenerator = new DataGenerator(Database);
            RestClient = new TestRestClient(CreateClient())
            {
                // HACK: for some reason updates to existing entities done by API
                // aren't visible to database context in test (but new entities
                // created by API still visible to test context, as well as entities created by test
                // are visible to API). So, context is recreated to read updated entities in test db context
                AfterRequest = CreateDatabaseContext
            };
        }

        public TestRestClient RestClient { get; }
        public DatabaseContext Database { get; private set; }
        public DataGenerator DataGenerator { get; }

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
            var accessorMock = CreateHttpContextAccessor();

            services.RemoveAll<IHttpContextAccessor>();
            services.AddSingleton(provider => accessorMock);
        }

        private static IHttpContextAccessor CreateHttpContextAccessor()
        {
            var accessorMock = new Mock<IHttpContextAccessor>();
            var context = new DefaultHttpContext();
            var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.NameIdentifier, "aee45700-af9b-4ab5-bb43-535adbdcfb84") });

            context.User = new ClaimsPrincipal(identity);

            accessorMock
                .SetupGet(a => a.HttpContext)
                .Returns(context);

            return accessorMock.Object;
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

            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlite(_connection);
            });
        }

        private void CreateDatabaseContext()
        {
            var builder = new DbContextOptionsBuilder<DatabaseContext>();
            builder.UseSqlite(_connection);

            Database = new DatabaseContext(builder.Options, CreateHttpContextAccessor());
            Database.Database.EnsureCreated();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _connection?.Close();
                _connection?.Dispose();
                Database?.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
