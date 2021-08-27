using System;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace LBH.AdultSocialCare.Api.Tests
{
    public static class DatabaseFactory
    {
        public static DatabaseContext GetInMemoryDatabase()
        {
            var dbContextOptions = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase($"HASC.API.TESTS.{DateTime.Now.Ticks}")
                .Options;

            return new DatabaseContext(dbContextOptions, null);
        }
    }
}
