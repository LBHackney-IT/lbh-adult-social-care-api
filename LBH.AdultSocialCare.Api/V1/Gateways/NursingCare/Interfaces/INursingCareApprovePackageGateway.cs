using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCare;

namespace LBH.AdultSocialCare.Api.V1.Gateways.NursingCare.Interfaces
{
    public interface INursingCareApprovePackageGateway
    {
        public Task<NursingCareApprovePackageDomain> GetAsync(Guid nursingCarePackageId);
    }
}
