using LBH.AdultSocialCare.Api.V1.Domain.TermTimeConsiderationOptionDomains;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.TermTimeConsiderationOptionGateways
{
    public interface ITermTimeConsiderationOptionGateway
    {
        Task<IEnumerable<TermTimeConsiderationOptionDomain>> GetTermTimeConsiderationOptionsList();
    }
}
