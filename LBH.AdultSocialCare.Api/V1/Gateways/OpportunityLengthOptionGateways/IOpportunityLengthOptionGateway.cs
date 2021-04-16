using LBH.AdultSocialCare.Api.V1.Domain.OpportunityLengthOptionDomains;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.OpportunityLengthOptionGateways
{
    public interface IOpportunityLengthOptionGateway
    {
        Task<IEnumerable<OpportunityLengthOptionDomain>> GetOpportunityLengthOptionsList();
    }
}
