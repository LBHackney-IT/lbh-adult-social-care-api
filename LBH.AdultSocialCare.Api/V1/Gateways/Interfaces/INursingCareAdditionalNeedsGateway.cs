using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Interfaces
{
    public interface INursingCareAdditionalNeedsGateway
    {
        public Task<NursingCareAdditionalNeeds> UpsertAsync(NursingCareAdditionalNeeds nursingCareAdditionalNeeds);

        public Task<NursingCareAdditionalNeeds> GetAsync(Guid nursingCareAdditionalNeedsId);

        public Task<bool> DeleteAsync(Guid nursingCareAdditionalNeedsId);
    }
}
