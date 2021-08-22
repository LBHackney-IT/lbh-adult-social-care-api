using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCare;

namespace LBH.AdultSocialCare.Api.V1.Gateways.HomeCare.Interfaces
{
    public interface IHomeCareApprovePackageGateway
    {
        public Task<HomeCareApprovePackageDomain> GetAsync(Guid homeCarePackageId);
    }
}
