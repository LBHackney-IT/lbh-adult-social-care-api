using System.Threading.Tasks;
using LBH.AdultSocialCare.Data;
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
