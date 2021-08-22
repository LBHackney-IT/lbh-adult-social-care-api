using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCare;

namespace LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCare.Interfaces
{
    public interface IResidentialCareApprovePackageGateway
    {
        public Task<ResidentialCareApprovePackageDomain> GetAsync(Guid residentialCarePackageId);
    }
}
