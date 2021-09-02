using System;
using System.Security.Claims;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace LBH.AdultSocialCare.Api.Tests
{
    public class BaseInMemoryDatabaseTest : BaseTest, IDisposable
    {
        private SqliteConnection _connection;
        // is called before _each_ test
        protected BaseInMemoryDatabaseTest()
        {
            Context = CreateDatabaseContext();
            DataGenerator = new DataGenerator(Context);

            Context.Database.EnsureCreated();
        }

        protected DatabaseContext Context { get; }

        protected DataGenerator DataGenerator { get; }

        private DatabaseContext CreateDatabaseContext()
        {
            var connectionString = new SqliteConnectionStringBuilder{ DataSource = ":memory:" }.ToString();
            _connection = new SqliteConnection(connectionString);
            _connection.Open();

            var dbContextOptions = new DbContextOptionsBuilder<DatabaseContext>()
                .UseSqlite(_connection)
                // .UseInMemoryDatabase($"HASC.API.UNIT.TESTS.{DateTime.Now.Ticks}")
                .Options;

            return new DatabaseContext(dbContextOptions, CreateHttpContextAccessor());
        }

        private static IHttpContextAccessor CreateHttpContextAccessor()
        {
            var identity = new ClaimsIdentity();
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, "aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            var httpContext = new DefaultHttpContext
            {
                User = new ClaimsPrincipal(identity)
            };

            return Mock.Of<IHttpContextAccessor>(a => a.HttpContext == httpContext);
        }

        #region IDisposable implementation

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _connection?.Close();
                _connection?.Dispose();

                Context?.Dispose();
            }
        }

        #endregion
    }
}
