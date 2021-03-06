using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Data.Constants.Enums;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete
{
    public class GetCarePackageBrokerageUseCase : IGetCarePackageBrokerageUseCase
    {
        private readonly ICarePackageGateway _carePackageGateway;

        public GetCarePackageBrokerageUseCase(ICarePackageGateway carePackageGateway)
        {
            _carePackageGateway = carePackageGateway;
        }

        public async Task<CarePackageBrokerageDomain> ExecuteAsync(Guid packageId)
        {
            var package = await _carePackageGateway
                .GetPackageAsync(packageId, PackageFields.Details)
                .EnsureExistsAsync($"Care package {packageId} not found");

            var coreCost = package.Details
                .SingleOrDefault(d => d.Type is PackageDetailType.CoreCost)
                .EnsureExists($"Brokerage information for package {packageId} doesn't exists", HttpStatusCode.NoContent);

            return new CarePackageBrokerageDomain
            {
                CoreCost = coreCost.Cost,
                StartDate = coreCost.StartDate,
                EndDate = coreCost.EndDate,
                SupplierId = package.SupplierId,

                Details = package.Details
                    .Where(d => d.Type != PackageDetailType.CoreCost)
                    .ToDomain().ToList()
            };
        }
    }
}
