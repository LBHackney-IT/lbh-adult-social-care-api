using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCare;

namespace LBH.AdultSocialCare.Api.V1.Gateways.HomeCare.Interfaces
{
    public interface IHomeCareApproveBrokeredGateway
    {
        public Task<HomeCareApproveBrokeredDomain> GetAsync(Guid homeCarePackageId);
    }
}
