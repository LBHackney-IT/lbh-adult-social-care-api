using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Clients.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Clients.Concrete
{
    public class GetClientPackagesCountUseCase : IGetClientPackagesCountUseCase
    {
        private readonly INursingCarePackageGateway _nursingCarePackageGateway;
        private readonly IResidentialCarePackageGateway _residentialCarePackageGateway;

        public GetClientPackagesCountUseCase(INursingCarePackageGateway nursingCarePackageGateway, IResidentialCarePackageGateway residentialCarePackageGateway)
        {
            _nursingCarePackageGateway = nursingCarePackageGateway;
            _residentialCarePackageGateway = residentialCarePackageGateway;
        }
        public async Task<int> GetCountAsync(Guid clientId, int? packageTypeId)
        {
            var packagesCount = 0;

            if (!packageTypeId.HasValue || packageTypeId == PackageTypesConstants.NursingCarePackageId)
            {
                packagesCount += await _nursingCarePackageGateway
                    .GetClientPackagesCountAsync(clientId).ConfigureAwait(false);
            }

            if (!packageTypeId.HasValue || packageTypeId == PackageTypesConstants.ResidentialCarePackageId)
            {
                packagesCount += await _residentialCarePackageGateway
                    .GetClientPackagesCountAsync(clientId).ConfigureAwait(false);
            }

            return packagesCount;
        }
    }
}