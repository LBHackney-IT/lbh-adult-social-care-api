using HttpServices.Services.Contracts;
using LBH.AdultSocialCare.Api.Tests.V1.Constants;
using LBH.AdultSocialCare.Api.Tests.V1.DataGenerators;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using LBH.AdultSocialCare.Api.V1.Services.Queuing;
using LBH.AdultSocialCare.Data;

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
            _connection.CreateFunction("comparedates", (Func<DateTimeOffset?, DateTimeOffset?, int>) CompareDates);

            CreateDatabaseContext();

            Generator = new DatabaseTestDataGenerator(DatabaseContext);

            OutgoingRestClient = new Mock<IRestClient>();
            PayrunsQueue = new Mock<IQueueService>();

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
        public DatabaseContext DatabaseContext { get; private set; }
        public DatabaseTestDataGenerator Generator { get; }

        public Mock<IRestClient> OutgoingRestClient { get; }
        public Mock<IQueueService> PayrunsQueue { get; }

        protected override TestServer CreateServer(IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration((context, configBuilder) =>
            {
                ((ConfigurationBuilder) configBuilder).AddInMemoryCollection(
                    new Dictionary<string, string>
                    {
                        ["HASCHttpClients:TransactionsBaseUrl"] = "http://127.0.0.1",
                        ["ResidentsAPI:BaseUrl"] = "http://127.0.0.1",
                        ["DocumentAPI:BaseUrl"] = "http://127.0.0.1",
                        ["DocumentAPI:ClaimBearerToken"] = "17456",
                        ["DocumentAPI:PostBearerToken"] = "18811938",
                        ["DocumentAPI:GetBearerToken"] = "10711453"
                    });
            });
            return base.CreateServer(builder);
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            if (builder is null) throw new ArgumentNullException(nameof(builder));

            builder.ConfigureTestServices(services =>
            {
                ReplaceService(services, OutgoingRestClient.Object);
                ReplaceService(services, PayrunsQueue.Object);

                ConfigureHttpContextAccessor(services);
                ConfigureAuthentication(services);
                ConfigureDatabaseContext(services);
            });
        }

        private static void ReplaceService<TService>(IServiceCollection services, TService replacement) where TService : class
        {
            services.RemoveAll<TService>();
            services.AddScoped(provider => replacement);
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
            var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.NameIdentifier, UserConstants.DefaultApiUserId) });

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

            DatabaseContext = new DatabaseContext(builder.Options, CreateHttpContextAccessor());
            DatabaseContext.Database.EnsureCreated();
        }

        private int CompareDates(DateTimeOffset? date1, DateTimeOffset? date2)
        {
            if (!date1.HasValue && !date2.HasValue)
            {
                return 0;
            }
            else if (!date1.HasValue)
            {
                return -1;
            }
            else if (!date2.HasValue)
            {
                return 1;
            }
            else
            {
                return date1.Value.Date.CompareTo(date2.Value.Date);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _connection?.Close();
                _connection?.Dispose();
                DatabaseContext?.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
