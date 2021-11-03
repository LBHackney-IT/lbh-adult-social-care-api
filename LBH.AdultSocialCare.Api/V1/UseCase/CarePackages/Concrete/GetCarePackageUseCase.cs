using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete
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

        public async Task<CarePackageResponse> GetCarePackageCoreAsync(Guid carePackageId)
        {
            var package = await _carePackageGateway
                .GetPackageAsync(carePackageId, PackageFields.ServiceUser | PackageFields.Settings)
                .EnsureExistsAsync($"Care package {carePackageId} not found");

            return package.ToDomain().ToResponse();
        }

        public async Task<BrokerPackageViewResponse> GetBrokerPackageViewListAsync(BrokerPackageViewQueryParameters queryParameters)
        {
            var result = await _carePackageGateway.GetBrokerPackageViewListAsync(queryParameters);
            return result.ToResponse();
        }
    }
}
