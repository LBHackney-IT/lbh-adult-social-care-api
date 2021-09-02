using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace LBH.AdultSocialCare.Api.V1.Gateways
{
    public interface ITransactionManager
    {
        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}
