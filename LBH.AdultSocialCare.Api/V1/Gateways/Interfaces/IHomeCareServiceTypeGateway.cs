using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCare;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Interfaces
{
    public interface IHomeCareServiceTypeGateway
    {
        public Task<HomeCareServiceType> UpsertAsync(HomeCareServiceType service);

        public Task<HomeCareServiceType> GetAsync(Guid serviceId);

        public Task<IList<HomeCareServiceType>> ListAsync();

        public Task<bool> DeleteAsync(Guid serviceId);
    }
}
