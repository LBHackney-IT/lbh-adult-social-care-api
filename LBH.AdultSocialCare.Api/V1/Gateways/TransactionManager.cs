using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace LBH.AdultSocialCare.Api.V1.Gateways
{
    public class TransactionManager : ITransactionManager
    {
        private readonly DatabaseContext _context;

        public TransactionManager(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync().ConfigureAwait(false);
        }
    }
}
