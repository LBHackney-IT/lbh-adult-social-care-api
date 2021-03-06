using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.RequestFeatures.Parameters;

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
                .GetPackageAsync(carePackageId, PackageFields.ServiceUser | PackageFields.Settings | PackageFields.Resources)
                .EnsureExistsAsync($"Care package {carePackageId} not found");

            var result = package.ToDomain();

            result.SocialWorkerCarePlanFileId = package.Resources?.Where(r => r.Type == PackageResourceType.CarePlanFile)
                .OrderByDescending(x => x.DateCreated).FirstOrDefault()?.FileId;
            result.SocialWorkerCarePlanFileName = package.Resources?.Where(r => r.Type == PackageResourceType.CarePlanFile)
                .OrderByDescending(x => x.DateCreated).FirstOrDefault()?.Name;

            return result.ToResponse();
        }

        public async Task<BrokerPackageViewResponse> GetBrokerPackageViewListAsync(BrokerPackageViewQueryParameters queryParameters)
        {
            var result = await _carePackageGateway.GetBrokerPackageViewListAsync(queryParameters);
            return result.ToResponse();
        }
    }
}
