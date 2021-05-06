using LBH.AdultSocialCare.Api.V1.Domain.HomeCareBrokerage;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCareBrokerage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.HomeCareBrokerageGateways
{
    public interface IHomeCareBrokerageGateway
    {
        public Task<HomeCareBrokerageCreationDomain> CreateAsync(Guid homeCarePackageId, HomeCareBrokerageCreationDomain homeCareBrokerageCreation);

        public Task<HomeCareBrokerageDomain> GetAsync(Guid homeCarePackageId);
    }
}
