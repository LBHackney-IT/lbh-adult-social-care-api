using LBH.AdultSocialCare.Api.V1.Domain.HomeCareApproveBrokeredDomains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.HomeCareApproveBrokeredGateways
{
    public interface IHomeCareApproveBrokeredGateway
    {
        public Task<HomeCareApproveBrokeredDomain> GetAsync(Guid homeCarePackageId);
    }
}
