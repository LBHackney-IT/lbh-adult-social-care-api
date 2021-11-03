using Common.Exceptions.CustomExceptions;
using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete
{
    public class EnsureSingleActivePackageTypePerUserUseCase : IEnsureSingleActivePackageTypePerUserUseCase
    {
        private readonly ICarePackageGateway _carePackageGateway;

        public EnsureSingleActivePackageTypePerUserUseCase(ICarePackageGateway carePackageGateway)
        {
            _carePackageGateway = carePackageGateway;
        }

        public async Task ExecuteAsync(Guid serviceUserId, PackageType packageType, Guid? excludePackageId = null)
        {
            var packagesCount = await _carePackageGateway.GetServiceUserActivePackagesCount(serviceUserId, packageType, excludePackageId);

            if (packagesCount > 0)
            {
                throw new ApiException($"User has an active {packageType.GetDisplayName()} already");
            }
        }
    }
}
