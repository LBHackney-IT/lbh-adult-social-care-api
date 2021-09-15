using LBH.AdultSocialCare.Api.V1.Domain.NursingCare;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.NursingCare.Interfaces
{
    public interface IFundedNursingCareGateway
    {
        Task<FundedNursingCareDomain> UpsertFundedNursingCaseAsync(FundedNursingCareDomain fundedNursingCareDomain);

        Task<bool> DeleteFundedNursingCareAsync(Guid packageId);

        Task<decimal> GetFundedNursingCarePriceAsync(DateTimeOffset dateTime);

        Task<IEnumerable<FundedNursingCarePriceDomain>> GetFundedNursingCarePricesAsync();

        Task<IEnumerable<FundedNursingCarePriceDomain>> GetFundedNursingCarePricingInRangeAsync(DateTimeOffset startDate, DateTimeOffset endDate);

        Task<FundedNursingCareDomain> GetPackageFundedNursingCareAsync(Guid nursingCarePackageId);
    }
}
