using System;
using System.Linq;
using System.Threading.Tasks;
using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces
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
            var package = (await _carePackageGateway
                    .GetPackageAsync(packageId))
                .EnsureExists($"Care package {packageId} not found");

            var coreCost = package.Details
                .SingleOrDefault(d => d.Type is PackageDetailType.CoreCost)
                .EnsureExists($"Brokerage information for package {packageId} doesn't exists");

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
