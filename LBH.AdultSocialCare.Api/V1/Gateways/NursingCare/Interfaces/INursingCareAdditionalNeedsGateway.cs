using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCareAdditionalNeedsDomains;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCare;

namespace LBH.AdultSocialCare.Api.V1.Gateways.NursingCare.Interfaces
{
    public interface INursingCareAdditionalNeedsGateway
    {
        public Task<NursingCareAdditionalNeed> UpsertAsync(NursingCareAdditionalNeed nursingCareAdditionalNeed);

        public Task<NursingCareAdditionalNeed> GetAsync(Guid nursingCareAdditionalNeedsId);

        public Task<bool> DeleteAsync(Guid nursingCareAdditionalNeedsId);

        Task<IEnumerable<AdditionalNeedsPaymentTypeDomain>> GetListOfTypeOfPaymentOptionList();
    }
}
