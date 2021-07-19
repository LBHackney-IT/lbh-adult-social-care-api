using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCare;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Interfaces
{
    public interface IHomeCareServiceTypeGateway
    {
        public Task<HomeCareServiceType> UpsertAsync(HomeCareServiceType service);

        public Task<HomeCareServiceType> GetAsync(int serviceId);

        public Task<IList<HomeCareServiceType>> ListAsync();

        public Task<bool> DeleteAsync(int serviceId);
    }
}
