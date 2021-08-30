using System;
using System.Security.Claims;
using AutoMapper;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Profiles;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace LBH.AdultSocialCare.Api.Tests
{
    public class BaseInMemoryDatabaseTest : IDisposable
    {
        // is called before _each_ test
        protected BaseInMemoryDatabaseTest()
        {
            var config = new MapperConfiguration(options =>
            {
                options.AddProfile<MappingProfile>();
            });

            Mapper = config.CreateMapper();

            DomainToEntityFactory.Configure(Mapper);
            EntityToDomainFactory.Configure(Mapper);

            Context = CreateDatabaseContext();
        }

        protected DatabaseContext Context { get; }
        protected IMapper Mapper { get; }

        private static DatabaseContext CreateDatabaseContext()
        {
            var dbContextOptions = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase($"HASC.API.TESTS.{DateTime.Now.Ticks}")
                .Options;

            var identity = new ClaimsIdentity();
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, "aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            var httpContext = new DefaultHttpContext
            {
                User = new ClaimsPrincipal(identity)
            };

            var httpContextAccessor = Mock.Of<IHttpContextAccessor>(a => a.HttpContext == httpContext);

            return new DatabaseContext(dbContextOptions, httpContextAccessor);
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
                Context?.Dispose();
            }
        }

        #endregion
    }
}
