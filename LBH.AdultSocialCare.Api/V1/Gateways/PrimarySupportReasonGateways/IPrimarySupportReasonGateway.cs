using LBH.AdultSocialCare.Api.V1.Domain.PackageDomains;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.PrimarySupportReasonGateways
{
    public interface IPrimarySupportReasonGateway
    {
        Task<IEnumerable<PrimarySupportReasonDomain>> ListAsync();
    }
}
