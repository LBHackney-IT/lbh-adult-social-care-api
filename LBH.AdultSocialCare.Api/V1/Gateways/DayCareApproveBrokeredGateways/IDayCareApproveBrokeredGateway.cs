using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.DayCare;

namespace LBH.AdultSocialCare.Api.V1.Gateways.DayCareApproveBrokeredGateways
{
    public interface IDayCareApproveBrokeredGateway
    {
        public Task<DayCareApproveBrokeredDomain> GetAsync(Guid dayCarePackageId);
    }
}
