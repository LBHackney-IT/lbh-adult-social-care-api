using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete
{
    public class UpdateCarePackageReclaimUseCase : IUpdateCarePackageReclaimUseCase
    {
        private readonly ICarePackageReclaimGateway _carePackageReclaimGateway;

        public UpdateCarePackageReclaimUseCase(ICarePackageReclaimGateway carePackageReclaimGateway)
        {
            _carePackageReclaimGateway = carePackageReclaimGateway;
        }

        public async Task<bool> UpdateCarePackageReclaim(CarePackageReclaimForUpdateDomain carePackageReclaimForUpdateDomain)
        {
            return await _carePackageReclaimGateway.UpdateAsync(carePackageReclaimForUpdateDomain);
        }
    }
}
