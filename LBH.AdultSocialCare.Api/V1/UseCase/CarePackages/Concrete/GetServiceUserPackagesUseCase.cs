using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.Helpers;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete
{
    public class GetServiceUserPackagesUseCase : IGetServiceUserPackagesUseCase
    {
        private readonly ICarePackageGateway _carePackageGateway;
        private readonly IServiceUserGateway _serviceUserGateway;
        private readonly ICarePackageHistoryGateway _carePackageHistoryGateway;

        public GetServiceUserPackagesUseCase(ICarePackageGateway carePackageGateway, IServiceUserGateway serviceUserGateway, ICarePackageHistoryGateway carePackageHistoryGateway)
        {
            _carePackageGateway = carePackageGateway;
            _serviceUserGateway = serviceUserGateway;
            _carePackageHistoryGateway = carePackageHistoryGateway;
        }

        public async Task<ServiceUserPackagesViewResponse> ExecuteAsync(Guid serviceUserId)
        {
            // Check service user exists
            var serviceUser = await _serviceUserGateway.GetByIdAsync(serviceUserId).EnsureExistsAsync($"Service user with id {serviceUserId} not found");
            var packageRequestStatuses = new[]
            {
                PackageStatus.New, PackageStatus.InProgress, PackageStatus.NotApproved
            };

            const PackageFields fields = PackageFields.Details | PackageFields.Reclaims | PackageFields.Settings | PackageFields.Resources;
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
                    IsS117Client = carePackage.Settings?.IsS117Client,
                    IsS117ClientConfirmed = carePackage.Settings?.IsS117ClientConfirmed,
                    DateAssigned = carePackage.DateAssigned,
                    GrossTotal = 0,
                    NetTotal = 0,
                    Resource = carePackage.Resources.ToDomain().ToResponse(),
                    Notes = new List<CarePackageHistoryResponse>(),
                    PackageItems = new List<CarePackageCostItemResponse>()
                };

                var coreCost = carePackage.Details
                    .SingleOrDefault(d => d.Type is PackageDetailType.CoreCost);

                var additionalNeeds = carePackage.Details
                    .Where(d => d.Type == PackageDetailType.AdditionalNeed).ToList();

                packageResponse.PackageItems = CollectPackageItems(carePackage, coreCost, additionalNeeds, carePackage.Reclaims.ToList());

                var preferences = FilterPreferences.PackageItemStatus();

                packageResponse.PackageItems = packageResponse.PackageItems.OrderBy(
                    item => preferences.IndexOf(item.Status));

                // Get care package history if package request i.e new, in-progress, not-approved
                if (packageRequestStatuses.Contains(carePackage.Status))
                {
                    var packageHistory = await _carePackageHistoryGateway.ListAsync(carePackage.Id);
                    packageResponse.Notes = packageHistory.OrderByDescending(h => h.Id).ToResponse();
                }

                var (grossTotal, netTotal) = CalculateTotals(coreCost, additionalNeeds, carePackage.Reclaims.ToList());
                packageResponse.GrossTotal = grossTotal;
                packageResponse.NetTotal = netTotal;

                packagesResponse.Add(packageResponse);
            }

            response.Packages = packagesResponse;

            return response;
        }

        private static IEnumerable<CarePackageCostItemResponse> CollectPackageItems(CarePackage package, CarePackageDetail coreCost, IReadOnlyCollection<CarePackageDetail> additionalNeeds, IReadOnlyCollection<CarePackageReclaim> reclaims)
        {
            var carePackageCostItem = new List<CarePackageCostItemResponse>();
            // Add core cost
            if (coreCost != null)
            {
                carePackageCostItem.Add(new CarePackageCostItemResponse
                {
                    Id = package.Id,
                    Name = package.PackageType.GetDisplayName(),
                    Type = package.PackageType.GetDisplayName(),
                    CollectedBy = ClaimCollector.Hackney.GetDisplayName(),
                    Status = package.Status.GetDisplayName(),
                    StartDate = coreCost.StartDate,
                    EndDate = coreCost.EndDate,
                    WeeklyCost = coreCost.Cost
                });
            }

            // Add additional needs
            if (additionalNeeds.Any())
            {
                carePackageCostItem.AddRange(additionalNeeds.Select(need => new CarePackageCostItemResponse
                {
                    Id = need.Id,
                    Name = GetAdditionalNeedName(need.CostPeriod),
                    Type = "Additional Needs",
                    CollectedBy = ClaimCollector.Hackney.GetDisplayName(),
                    Status = package.Status.GetDisplayName(),
                    StartDate = need.StartDate,
                    EndDate = need.EndDate,
                    WeeklyCost = need.Cost
                }));
            }

            // add reclaims
            if (reclaims.Any())
            {
                carePackageCostItem.AddRange(reclaims.Select(reclaim => new CarePackageCostItemResponse
                {
                    Id = reclaim.Id,
                    Name = Enum.IsDefined(typeof(ReclaimSubType), reclaim.SubType) ? reclaim.SubType.GetDisplayName() : GetCareChargeName(reclaim.Type),
                    Type = GetCareChargeName(reclaim.Type),
                    CollectedBy = reclaim.ClaimCollector.GetDisplayName(),
                    Status = reclaim.Status.GetDisplayName(),
                    StartDate = reclaim.StartDate,
                    EndDate = reclaim.EndDate,
                    WeeklyCost = reclaim.ClaimCollector == ClaimCollector.Hackney ? reclaim.Cost : decimal.Negate(reclaim.Cost)
                }));
            }

            return carePackageCostItem;
        }

        private static string GetAdditionalNeedName(PaymentPeriod paymentPeriod)
        {
            return paymentPeriod switch
            {
                PaymentPeriod.OneOff => "Additional needs payment / one-off",
                PaymentPeriod.Weekly => "Additional needs payment / wk",
                PaymentPeriod.Hourly => "Additional needs payment / hr",
                PaymentPeriod.Fixed => "Additional needs payment / fixed",
                _ => "Additional needs payment"
            };
        }

        private static string GetCareChargeName(ReclaimType type)
        {
            return type switch
            {
                ReclaimType.CareCharge => "Package Reclaim - Care Charge",
                ReclaimType.Fnc => "Package Reclaim - Funded Nursing Care",
                _ => "Package Reclaim"
            };
        }

        private static (decimal, decimal) CalculateTotals(CarePackageDetail coreCost, IReadOnlyCollection<CarePackageDetail> additionalNeeds, IReadOnlyCollection<CarePackageReclaim> reclaims)
        {
            decimal grossTotal = 0;
            decimal netTotal = 0;

            // Add core cost
            if (coreCost != null && IsValidDateRange(coreCost.StartDate, coreCost.EndDate))
            {
                grossTotal += coreCost.Cost;
                netTotal += coreCost.Cost;
            }

            // Add weekly additional needs only
            var weeklyAdditionalNeeds = additionalNeeds.Where(d => d.CostPeriod is PaymentPeriod.Weekly).ToList();
            foreach (var need in weeklyAdditionalNeeds.Where(need => IsValidDateRange(need.StartDate, need.EndDate)))
            {
                grossTotal += need.Cost;
                netTotal += need.Cost;
            }

            // Deduct reclaims collected by supplier from package net cost
            netTotal = reclaims.Where(reclaim => reclaim.Status == ReclaimStatus.Active && reclaim.ClaimCollector == ClaimCollector.Supplier && IsValidDateRange(reclaim.StartDate, reclaim.EndDate))
                .Aggregate(netTotal, (current, reclaim) => current - reclaim.Cost);

            return (grossTotal, netTotal);
        }

        private static bool IsValidDateRange(DateTimeOffset startDate, DateTimeOffset? endDate)
        {
            var today = DateTimeOffset.Now.Date;
            return (today >= startDate) switch
            {
                true when (endDate == null || endDate.Value.Date >= today) => true,
                _ => false
            };
        }
    }
}
