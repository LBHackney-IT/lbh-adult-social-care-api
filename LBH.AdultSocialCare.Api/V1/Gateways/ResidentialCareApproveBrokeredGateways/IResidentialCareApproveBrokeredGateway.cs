using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCareApproveBrokeredDomains;

namespace LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCareApproveBrokeredGateways
{
    public interface IResidentialCareApproveBrokeredGateway
    {
        public Task<ResidentialCareApproveBrokeredDomain> GetAsync(Guid residentialCarePackageId);
    }
}
