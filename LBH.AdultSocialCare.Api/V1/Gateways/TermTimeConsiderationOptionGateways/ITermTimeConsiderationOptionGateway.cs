using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.Common;

namespace LBH.AdultSocialCare.Api.V1.Gateways.TermTimeConsiderationOptionGateways
{
    public interface ITermTimeConsiderationOptionGateway
    {
        Task<IEnumerable<TermTimeConsiderationOptionDomain>> GetTermTimeConsiderationOptionsList();
    }
}
