using LBH.AdultSocialCare.Api.V1.Domain.OpportunityTimesPerMonthOptionDomains;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.OpportunityTimesPerMonthOptionGateways
{
    public interface IOpportunityTimesPerMonthOptionGateway
    {
        Task<IEnumerable<OpportunityTimesPerMonthOptionDomain>> GetOpportunityTimesPerMonthOptionsList();
    }
}
