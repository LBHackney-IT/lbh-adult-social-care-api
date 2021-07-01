using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCare;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Interfaces
{
    public interface IResidentialCareAdditionalNeedsGateway
    {
        public Task<ResidentialCareAdditionalNeed> UpsertAsync(ResidentialCareAdditionalNeed residentialCareAdditionalNeed);

        public Task<ResidentialCareAdditionalNeed> GetAsync(Guid residentialCareAdditionalNeedsId);

        public Task<bool> DeleteAsync(Guid residentialCareAdditionalNeedsId);
    }
}
