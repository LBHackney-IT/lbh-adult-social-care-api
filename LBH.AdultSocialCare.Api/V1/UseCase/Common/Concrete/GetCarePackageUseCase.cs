using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;

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

        public async Task<CarePackageDomain> GetSingleAsync(Guid packageId)
        {
            var package = await _carePackageGateway
                .GetPackageAsync(packageId, PackageFields.ServiceUser | PackageFields.Settings | PackageFields.PrimarySupportReason)
                .EnsureExistsAsync($"Care package {packageId} not found");

            return package.ToDomain();
        }

        public async Task<CarePackageSettingsResponse> GetCarePackageSettingsAsync(Guid carePackageId)
        {
            var settings = await _carePackageGateway.GetCarePackageSettingsAsync(carePackageId).EnsureExistsAsync($"Settings for care package with id {carePackageId} not found");
            return settings.ToResponse();
        }

        public async Task<BrokerPackageViewResponse> GetBrokerPackageViewListAsync(BrokerPackageViewQueryParameters queryParameters)
        {
            var result = await _carePackageGateway.GetBrokerPackageViewListAsync(queryParameters);
            return result.ToResponse();
        }
    }
}
