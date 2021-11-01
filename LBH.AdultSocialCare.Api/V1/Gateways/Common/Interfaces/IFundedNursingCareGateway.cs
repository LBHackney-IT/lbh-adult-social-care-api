using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.Common;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces
{
    public interface IFundedNursingCareGateway
    {
        Task<decimal> GetFundedNursingCarePriceAsync(DateTimeOffset dateTime);

        Task<IEnumerable<FundedNursingCarePriceDomain>> GetFundedNursingCarePricesAsync();

        Task<IEnumerable<FundedNursingCarePriceDomain>> GetFundedNursingCarePricingInRangeAsync(DateTimeOffset startDate, DateTimeOffset endDate);
    }
}
