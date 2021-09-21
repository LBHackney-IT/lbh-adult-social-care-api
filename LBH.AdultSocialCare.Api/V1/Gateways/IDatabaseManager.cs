using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways
{
    public interface IDatabaseManager
    {
        Task<IDbContextTransaction> BeginTransactionAsync();

        void Save(string errorMessage);

        Task SaveAsync(string errorMessage);
    }
}
