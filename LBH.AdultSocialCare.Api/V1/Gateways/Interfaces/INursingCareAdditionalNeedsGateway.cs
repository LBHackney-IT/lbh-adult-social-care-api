using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCare;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Interfaces
{
    public interface INursingCareAdditionalNeedsGateway
    {
        public Task<NursingCareAdditionalNeed> UpsertAsync(NursingCareAdditionalNeed nursingCareAdditionalNeed);

        public Task<NursingCareAdditionalNeed> GetAsync(Guid nursingCareAdditionalNeedsId);

        public Task<bool> DeleteAsync(Guid nursingCareAdditionalNeedsId);
    }
}
