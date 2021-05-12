using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.StageDomains;

namespace LBH.AdultSocialCare.Api.V1.Gateways.HomeCareStageGateways
{
    public interface IHomeCareStageGateway
    {
        public Task<IEnumerable<StageDomain>> ListAsync();
    }
}
