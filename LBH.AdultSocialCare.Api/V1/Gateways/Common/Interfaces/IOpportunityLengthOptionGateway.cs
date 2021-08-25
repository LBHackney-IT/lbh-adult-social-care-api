using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.Common;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces
{
    public interface IOpportunityLengthOptionGateway
    {
        Task<IEnumerable<OpportunityLengthOptionDomain>> GetOpportunityLengthOptionsList();
    }
}