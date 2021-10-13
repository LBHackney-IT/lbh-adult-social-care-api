using LBH.AdultSocialCare.Api.V1.Domain.NursingCare;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.NursingCare.Interfaces
{
    public interface IFundedNursingCareGateway
    {
        Task<decimal> GetFundedNursingCarePriceAsync(DateTimeOffset dateTime);

        Task<IEnumerable<FundedNursingCarePriceDomain>> GetFundedNursingCarePricesAsync();

        Task<IEnumerable<FundedNursingCarePriceDomain>> GetFundedNursingCarePricingInRangeAsync(DateTimeOffset startDate, DateTimeOffset endDate);
    }
}
