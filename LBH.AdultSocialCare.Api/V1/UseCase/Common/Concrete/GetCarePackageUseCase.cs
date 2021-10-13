using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Concrete
{
    public class GetCarePackageUseCase : IGetCarePackageUseCase
    {
        private readonly ICarePackageGateway _carePackageGateway;

        public GetCarePackageUseCase(ICarePackageGateway carePackageGateway)
        {
            _carePackageGateway = carePackageGateway;
        }

        public async Task<IEnumerable<CarePackageListItemResponse>> GetAllAsync()
        {
            var packages = await _carePackageGateway.GetAllPackagesAsync();
            return packages.ToResponse();
        }

        public async Task<CarePackageResponse> GetSingleAsync(Guid packageId)
        {
            var package = await _carePackageGateway
                .GetPackageAsync(packageId, PackageFields.ServiceUser | PackageFields.Settings)
                .EnsureExistsAsync($"Care package {packageId} not found");

            return package.ToDomain().ToResponse();
        }

        public async Task<CarePackageCoreResponse> GetCarePackageCoreAsync(Guid carePackageId)
        {
            var corePackage = await _carePackageGateway.GetCarePackageCoreAsync(carePackageId).EnsureExistsAsync($"Settings for care package with id {carePackageId} not found");
            return corePackage.ToResponse();
        }

        public async Task<BrokerPackageViewResponse> GetBrokerPackageViewListAsync(BrokerPackageViewQueryParameters queryParameters)
        {
            var result = await _carePackageGateway.GetBrokerPackageViewListAsync(queryParameters);
            return result.ToResponse();
        }
    }
}
