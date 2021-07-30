using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain;

namespace LBH.AdultSocialCare.Api.V1.Gateways.PrimarySupportReasonGateways
{
    public interface IPrimarySupportReasonGateway
    {
        Task<IEnumerable<PrimarySupportReasonDomain>> ListAsync();
    }
}
