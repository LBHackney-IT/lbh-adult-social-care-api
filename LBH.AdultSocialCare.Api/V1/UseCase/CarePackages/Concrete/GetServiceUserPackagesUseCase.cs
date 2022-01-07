using Common.Extensions;
using LBH.AdultSocialCare.Api.Helpers;
using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using LBH.AdultSocialCare.Data.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete
{
    public class GetServiceUserPackagesUseCase : IGetServiceUserPackagesUseCase
    {
        private readonly ICarePackageGateway _carePackageGateway;
        private readonly IServiceUserGateway _serviceUserGateway;
        private readonly ICarePackageHistoryGateway _carePackageHistoryGateway;
        private readonly ILogger<GetServiceUserPackagesUseCase> _logger;

        public GetServiceUserPackagesUseCase(ICarePackageGateway carePackageGateway, IServiceUserGateway serviceUserGateway, ICarePackageHistoryGateway carePackageHistoryGateway, ILogger<GetServiceUserPackagesUseCase> logger)
        {
            _carePackageGateway = carePackageGateway;
            _serviceUserGateway = serviceUserGateway;
            _carePackageHistoryGateway = carePackageHistoryGateway;
            _logger = logger;
        }

        public async Task<ServiceUserPackagesViewResponse> ExecuteAsync(Guid serviceUserId)
        {
            // Check service user exists
            var serviceUser = await _serviceUserGateway.GetByIdAsync(serviceUserId).EnsureExistsAsync($"Service user with id {serviceUserId} not found");

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
                var coreCost = carePackage.Details
                    .SingleOrDefault(d => d.Type is PackageDetailType.CoreCost);

                var packageResponse = new ServiceUserPackageViewItemResponse
                {
                    PackageId = carePackage.Id,
                    PackageStatus = CalculatePackageStatus(carePackage, coreCost),
                    PackageType = carePackage.PackageType.GetDisplayName(),
                    IsS117Client = carePackage.Settings?.IsS117Client,
                    IsS117ClientConfirmed = carePackage.Settings?.IsS117ClientConfirmed,
                    DateAssigned = carePackage.DateAssigned,
                    GrossTotal = 0,
                    NetTotal = 0,
                    SocialWorkerCarePlanFileId = carePackage.Resources?.Where(r => r.Type == PackageResourceType.CarePlanFile).OrderByDescending(x => x.DateCreated).FirstOrDefault()?.FileId,
                    SocialWorkerCarePlanFileName = carePackage.Resources?.Where(r => r.Type == PackageResourceType.CarePlanFile).OrderByDescending(x => x.DateCreated).FirstOrDefault()?.Name,
                    Notes = new List<CarePackageHistoryResponse>(),
                    PackageItems = new List<CarePackageCostItemResponse>()
                };

                var additionalNeeds = carePackage.Details
                    .Where(d => d.Type == PackageDetailType.AdditionalNeed).ToList();

                packageResponse.PackageItems = CollectPackageItems(carePackage, coreCost, additionalNeeds, carePackage.Reclaims.ToList());

                var preferences = FilterPreferences.PackageItemStatus();

                packageResponse.PackageItems = packageResponse.PackageItems.OrderBy(
                    item => preferences.IndexOf(item.Status)).ThenBy(x => x.StartDate);

                // Get care package history if package request i.e new, in-progress, not-approved
                if (carePackage.Status.In(PackageStatus.New, PackageStatus.InProgress, PackageStatus.NotApproved))
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

        private static string CalculatePackageStatus(CarePackage package, IPackageItem coreCost)
        {
            var today = DateTimeOffset.UtcNow.Date;
            return package.Status switch
            {
                PackageStatus.Approved when coreCost.EndDate != null &&
                                            coreCost.EndDate.GetValueOrDefault().Date < today => "Ended",
                PackageStatus.Approved when IsValidDateRange(coreCost.StartDate, coreCost.EndDate) => "Active",
                PackageStatus.Approved => "Future",
                _ => package.Status.GetDisplayName()
            };
        }

        private static string CalculateAnpStatus(CarePackage package, IPackageItem carePackageDetail)
        {
            var today = DateTimeOffset.UtcNow.Date;
            if (package.Status != PackageStatus.Approved)
                return package.Status.GetDisplayName();

            if (IsValidDateRange(carePackageDetail.StartDate, carePackageDetail.EndDate))
                return ReclaimStatus.Active.GetDisplayName();

            return ReclaimStatus.Pending.GetDisplayName();
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
                    Status = CalculatePackageStatus(package, coreCost),
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
                    //Status = coreCost != null ? CalculatePackageStatus(package, coreCost) : package.Status.GetDisplayName(),
                    Status = CalculateAnpStatus(package, need),
                    StartDate = need.StartDate,
                    EndDate = need.EndDate,
                    WeeklyCost = need.Cost
                }));
            }

            // add reclaims
            if (reclaims.Any())
            {
                foreach (var item in reclaims)
                {
                    var reclaim = new CarePackageCostItemResponse
                    {
                        Id = item.Id,
                        Name = item.SubType != null && Enum.IsDefined(typeof(ReclaimSubType), item.SubType) ? item.SubType.GetDisplayName() : GetCareChargeName(item.Type),
                        Type = GetCareChargeName(item.Type),
                        CollectedBy = item.ClaimCollector.GetDisplayName(),
                        Status = CalculateReclaimStatus(item).GetDisplayName(),
                        StartDate = item.StartDate,
                        EndDate = item.EndDate,
                        WeeklyCost = item.ClaimCollector == ClaimCollector.Hackney ? item.Cost : decimal.Negate(item.Cost)
                    };
                }

                carePackageCostItem.AddRange(reclaims.Select(reclaim => new CarePackageCostItemResponse
                {
                    Id = reclaim.Id,
                    Name = reclaim.SubType != null && Enum.IsDefined(typeof(ReclaimSubType), reclaim.SubType) ? reclaim.SubType.GetDisplayName() : GetCareChargeName(reclaim.Type),
                    Type = GetCareChargeName(reclaim.Type),
                    CollectedBy = reclaim.ClaimCollector.GetDisplayName(),
                    Status = CalculateReclaimStatus(reclaim).GetDisplayName(),
                    StartDate = reclaim.StartDate,
                    EndDate = reclaim.EndDate,
                    WeeklyCost = reclaim.SubType == ReclaimSubType.FncPayment || reclaim.ClaimCollector == ClaimCollector.Hackney ? reclaim.Cost : decimal.Negate(reclaim.Cost)
                }));
            }

            return carePackageCostItem;
        }

        private static ReclaimStatus CalculateReclaimStatus(CarePackageReclaim reclaim)
        {
            var today = DateTimeOffset.UtcNow.Date;
            if (reclaim.Status is ReclaimStatus.Cancelled || reclaim.Status is ReclaimStatus.Ended)
            {
                return reclaim.Status;
            }

            if (reclaim.EndDate != null && today > reclaim.EndDate.Value.Date)
            {
                return ReclaimStatus.Ended;
            }

            return today >= reclaim.StartDate.Date
                ? ReclaimStatus.Active
                : ReclaimStatus.Pending;
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
            var today = DateTimeOffset.UtcNow.Date;
            return (today >= startDate) switch
            {
                true when (endDate == null || endDate.Value.Date >= today) => true,
                _ => false
            };
        }
    }
}
