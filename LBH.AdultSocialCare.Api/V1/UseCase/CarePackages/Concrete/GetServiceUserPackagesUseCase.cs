using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CarePackages;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete
{
    public class GetServiceUserPackagesUseCase : IGetServiceUserPackagesUseCase
    {
        private readonly ICarePackageGateway _carePackageGateway;
        private readonly IServiceUserGateway _serviceUserGateway;

        public GetServiceUserPackagesUseCase(ICarePackageGateway carePackageGateway, IServiceUserGateway serviceUserGateway)
        {
            _carePackageGateway = carePackageGateway;
            _serviceUserGateway = serviceUserGateway;
        }

        public async Task<ServiceUserPackagesViewResponse> ExecuteAsync(Guid serviceUserId)
        {
            // Check service user exists
            var serviceUser = await _serviceUserGateway.GetUsingIdAsync(serviceUserId).EnsureExistsAsync($"Service user with id {serviceUserId} not found");

            const PackageFields fields = PackageFields.Details | PackageFields.Reclaims;
            var userPackages = await _carePackageGateway.GetServiceUserPackagesAsync(serviceUserId, fields);
            var response = new ServiceUserPackagesViewResponse
            {
                ServiceUser = serviceUser.ToBasicDomain().ToResponse(),
                Packages = new List<ServiceUserPackageViewItemResponse>()
            };

            var packagesResponse = new List<ServiceUserPackageViewItemResponse>();

            foreach (var carePackage in userPackages)
            {
                var packageResponse = new ServiceUserPackageViewItemResponse
                {
                    PackageId = carePackage.Id,
                    PackageStatus = carePackage.Status.GetDisplayName(),
                    PackageType = carePackage.PackageType.GetDisplayName(),
                    DateAssigned = carePackage.DateAssigned,
                    GrossTotal = 0,
                    NetTotal = 0,
                    PackageItems = new List<CarePackageCostItemResponse>()
                };

                var coreCost = carePackage.Details
                    .SingleOrDefault(d => d.Type is PackageDetailType.CoreCost);

                var additionalNeeds = carePackage.Details
                    .Where(d => d.Type == PackageDetailType.AdditionalNeed).ToList();

                packageResponse.PackageItems = CollectPackageItems(carePackage, coreCost, additionalNeeds, carePackage.Reclaims.ToList());
                packagesResponse.Add(packageResponse);
            }

            response.Packages = packagesResponse;

            return response;
        }

        private static IEnumerable<CarePackageCostItemResponse> CollectPackageItems(CarePackage package, CarePackageDetail coreCost, IReadOnlyCollection<CarePackageDetail> additionalNeeds, IReadOnlyCollection<CarePackageReclaim> reclaims)
        {
            // Add core cost
            var carePackageCostItem = new List<CarePackageCostItemResponse>
            {
                new CarePackageCostItemResponse
                {
                    Id = package.Id,
                    Name = package.PackageType.GetDisplayName(),
                    Type = package.PackageType.GetDisplayName(),
                    CollectedBy = ClaimCollector.Hackney.GetDisplayName(),
                    Status = DateTimeOffset.Now.IsInRange(coreCost.StartDate,
                        coreCost.EndDate ?? DateTimeOffset.Now.AddYears(10))
                        ? "Active"
                        : "Ended",
                    StartDate = coreCost.StartDate,
                    EndDate = coreCost.EndDate,
                    WeeklyCost = coreCost.Cost
                }
            };

            // Add one off additional needs
            var oneOffAdditionalNeeds = additionalNeeds.Where(d => d.CostPeriod is PaymentPeriod.OneOff).ToList();
            carePackageCostItem.AddRange(oneOffAdditionalNeeds.Select(need => new CarePackageCostItemResponse
            {
                Id = need.Id,
                Name = "Additional needs payment / one-off",
                Type = "Additional Needs One Off",
                CollectedBy = ClaimCollector.Hackney.GetDisplayName(),
                Status = DateTimeOffset.Now.IsInRange(need.StartDate, need.EndDate ?? DateTimeOffset.Now.AddYears(10)) ? "Active" : "Ended",
                StartDate = need.StartDate,
                EndDate = need.EndDate,
                WeeklyCost = need.Cost
            }));

            // Add weekly additional needs
            var weeklyAdditionalNeeds = additionalNeeds.Where(d => d.CostPeriod is PaymentPeriod.Weekly).ToList();
            carePackageCostItem.AddRange(weeklyAdditionalNeeds.Select(need => new CarePackageCostItemResponse
            {
                Id = need.Id,
                Name = "Additional needs payment / wk",
                Type = "Additional Needs Weekly",
                CollectedBy = ClaimCollector.Hackney.GetDisplayName(),
                Status = DateTimeOffset.Now.IsInRange(need.StartDate, need.EndDate ?? DateTimeOffset.Now.AddYears(10)) ? "Active" : "Ended",
                StartDate = need.StartDate,
                EndDate = need.EndDate,
                WeeklyCost = need.Cost
            }));

            // add care charges
            var careCharges = reclaims.Where(r => r.Type == ReclaimType.CareCharge).ToList();
            carePackageCostItem.AddRange(careCharges.Select(careCharge => new CarePackageCostItemResponse
            {
                Id = careCharge.Id,
                Name = careCharge.SubType.GetDisplayName(),
                Type = "Package Reclaim - Care Charge",
                CollectedBy = careCharge.ClaimCollector.GetDisplayName(),
                Status = careCharge.Status.GetDisplayName(),
                StartDate = careCharge.StartDate,
                EndDate = careCharge.EndDate,
                WeeklyCost = careCharge.Cost
            }));

            // Add fnc
            var fncItems = reclaims.Where(r => r.Type == ReclaimType.Fnc).ToList();
            carePackageCostItem.AddRange(fncItems.Select(careCharge => new CarePackageCostItemResponse
            {
                Id = careCharge.Id,
                Name = careCharge.SubType.GetDisplayName(),
                Type = "Package Reclaim - Funded Nursing Care",
                CollectedBy = careCharge.ClaimCollector.GetDisplayName(),
                Status = careCharge.Status.GetDisplayName(),
                StartDate = careCharge.StartDate,
                EndDate = careCharge.EndDate,
                WeeklyCost = careCharge.Cost
            }));

            return carePackageCostItem;
        }
    }
}
