using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCare;

namespace LBH.AdultSocialCare.Api.V1.Gateways.HomeCare.Interfaces
{
    public interface IHomeCareBrokerageGateway
    {
        public Task<HomeCareBrokerageCreationDomain> CreateAsync(Guid homeCarePackageId, HomeCareBrokerageCreationDomain homeCareBrokerageCreation);

        public Task<HomeCareBrokerageDomain> GetAsync(Guid homeCarePackageId);
    }
}
