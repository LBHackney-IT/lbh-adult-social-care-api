using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Interfaces
{
    public interface IResidentialCareAdditionalNeedsGateway
    {
        public Task<ResidentialCareAdditionalNeeds> UpsertAsync(ResidentialCareAdditionalNeeds residentialCareAdditionalNeeds);

        public Task<ResidentialCareAdditionalNeeds> GetAsync(Guid residentialCareAdditionalNeedsId);
    }
}
