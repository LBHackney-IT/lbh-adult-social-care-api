using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCare;

namespace LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCare.Interfaces
{
    public interface IResidentialCareAdditionalNeedsGateway
    {
        public Task<ResidentialCareAdditionalNeed> UpsertAsync(ResidentialCareAdditionalNeed residentialCareAdditionalNeed);

        public Task<ResidentialCareAdditionalNeed> GetAsync(Guid residentialCareAdditionalNeedsId);

        public Task<bool> DeleteAsync(Guid residentialCareAdditionalNeedsId);
    }
}
