using LBH.AdultSocialCare.Api.V1.Domain.HomeCareBrokerage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.HomeCareStageGateways
{
    public interface IHomeCareStageGateway
    {
        public Task<IEnumerable<HomeCareStageDomain>> ListAsync();
    }
}
