using System;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;
using Common.Exceptions.CustomExceptions;

namespace LBH.AdultSocialCare.Api.V1.Gateways
{
    public class DatabaseManager : IDatabaseManager
    {
        private readonly DatabaseContext _context;

        public DatabaseManager(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync().ConfigureAwait(false);
        }

        public void Save(string errorMessage)
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new DbSaveFailedException($"{errorMessage} {ex.InnerException?.Message}", ex);
            }
        }

        public async Task SaveAsync(string errorMessage)
        {
            try
            {
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new DbSaveFailedException($"{errorMessage} {ex.InnerException?.Message}", ex);
            }
        }
    }
}
