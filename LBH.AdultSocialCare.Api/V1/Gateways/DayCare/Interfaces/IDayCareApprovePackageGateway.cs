using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.DayCare;

namespace LBH.AdultSocialCare.Api.V1.Gateways.DayCare.Interfaces
{
    public interface IDayCareApprovePackageGateway
    {
        public Task<DayCareApprovePackageDomain> GetAsync(Guid dayCarePackageId);
    }
}
