using System;
using System.Security.Claims;
using LBH.AdultSocialCare.Api.Tests.V1.Constants;
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
            var connectionString = $"DataSource=file:DB{Guid.NewGuid()}?mode=memory&cache=shared";
            _connection = new SqliteConnection(connectionString);
            _connection.Open();

            var dbContextOptions = new DbContextOptionsBuilder<DatabaseContext>()
                .UseSqlite(_connection)
                .Options;

            return new DatabaseContext(dbContextOptions, CreateHttpContextAccessor());
        }

        private static IHttpContextAccessor CreateHttpContextAccessor()
        {
            var identity = new ClaimsIdentity();
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, UserConstants.DefaultApiUserId));

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
