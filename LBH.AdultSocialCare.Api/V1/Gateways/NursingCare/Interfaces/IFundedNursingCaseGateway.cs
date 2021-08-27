using LBH.AdultSocialCare.Api.V1.Domain.NursingCare;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.NursingCare.Interfaces
{
    public interface IFundedNursingCaseGateway
    {
        Task<FundedNursingCareDomain> UpsertFundedNursingCaseAsync(FundedNursingCareDomain fundedNursingCareDomain);

        Task<bool> DeleteFundedNursingCareAsync(Guid packageId);

        Task<decimal> GetFundedNursingCarePriceAsync(DateTimeOffset dateTime);

        Task<FundedNursingCarePriceDomain> GetFundedNursingCarePricing(DateTimeOffset dateTime);

        Task<IEnumerable<FundedNursingCarePriceDomain>> GetFundedNursingCarePricingInRange(DateTimeOffset startDate, DateTimeOffset endDate);

        Task<FundedNursingCareDomain> GetPackageFundedNursingCare(Guid nursingCarePackageId);
    }
}
