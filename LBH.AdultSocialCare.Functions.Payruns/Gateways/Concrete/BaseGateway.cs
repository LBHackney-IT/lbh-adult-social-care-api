using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Functions.Payruns.Gateways.Interfaces;

namespace LBH.AdultSocialCare.Functions.Payruns.Gateways.Concrete
{
    public abstract class BaseGateway : IGateway
    {
        protected BaseGateway(DatabaseContext dbContext)
        {
            DbContext = dbContext;
        }

        protected DatabaseContext DbContext { get; }

        public async Task SaveAsync()
        {
            await DbContext.SaveChangesAsync();
        }
    }
}
