using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCare;

namespace LBH.AdultSocialCare.Api.V1.Gateways.HomeCare.Interfaces
{
    public interface IHomeCareServiceTypeGateway
    {
        public Task<HomeCareServiceType> UpsertAsync(HomeCareServiceType service);

        public Task<HomeCareServiceType> GetAsync(int serviceId);

        public Task<IList<HomeCareServiceType>> ListAsync();

        public Task<bool> DeleteAsync(int serviceId);
    }
}
