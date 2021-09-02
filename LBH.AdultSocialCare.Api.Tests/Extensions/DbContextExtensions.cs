using Microsoft.EntityFrameworkCore;

namespace LBH.AdultSocialCare.Api.Tests.Extensions
{
    public static class DbContextExtensions
    {
        public static void ClearData<T>(this DbSet<T> dbSet) where T : class
        {
            dbSet.RemoveRange(dbSet);
        }
    }
}
