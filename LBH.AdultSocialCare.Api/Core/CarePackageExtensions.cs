using System;
using System.Linq;
using Common.Extensions;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;

namespace LBH.AdultSocialCare.Api.Core
{
    public static class CarePackageExtensions
    {
        public static CarePackageDetail GetCoreCostDetail(this CarePackage package)
        {
            return package.Details.FirstOrDefault(d => d.Type is PackageDetailType.CoreCost);
        }

        public static decimal GetCoreCost(this CarePackage package)
        {
            return package.GetCoreCostDetail()?.Cost ?? 0.0m;
        }

        public static decimal GetAdditionalWeeklyCost(this CarePackage package, DateTimeOffset? targetDate = null)
        {
            return package.Details
                .Where(detail =>
                    detail.Type is PackageDetailType.AdditionalNeed &&
                    detail.CostPeriod is PaymentPeriod.Weekly &&
                    (targetDate is null || targetDate.Value.IsInRange(detail.StartDate, detail.EndDate ?? DateTimeOffset.MaxValue)))
                .Sum(detail => detail.Cost);
        }

        public static decimal GetAdditionalOneOffCost(this CarePackage package, DateTimeOffset? targetDate = null)
        {
            return package.Details
                .Where(detail =>
                    detail.Type is PackageDetailType.AdditionalNeed &&
                    detail.CostPeriod is PaymentPeriod.OneOff &&
                    (targetDate is null || targetDate.Value.IsInRange(detail.StartDate, detail.EndDate ?? DateTimeOffset.MaxValue)))
                .Sum(detail => detail.Cost);
        }

        public static decimal GetCareChargesCost(this CarePackage package, ClaimCollector? collector = null, DateTimeOffset? targetDate = null)
        {
            return package.Reclaims
                .Where(reclaim =>
                    reclaim.Type is ReclaimType.CareCharge &&
                    reclaim.Status != ReclaimStatus.Cancelled &&
                    (collector is null || reclaim.ClaimCollector == collector) &&
                    (targetDate is null || targetDate.Value.IsInRange(reclaim.StartDate, reclaim.EndDate ?? DateTimeOffset.MaxValue)))
                .Sum(reclaim => reclaim.Cost);
        }

        public static decimal GetFncCost(this CarePackage package, DateTimeOffset? targetDate = null)
        {
            return package.Reclaims
                .FirstOrDefault(reclaim =>
                    reclaim.Type is ReclaimType.Fnc &&
                    reclaim.SubType is ReclaimSubType.FncPayment &&
                    reclaim.Status != ReclaimStatus.Cancelled &&
                    (targetDate is null || targetDate.Value.IsInRange(reclaim.StartDate, reclaim.EndDate ?? DateTimeOffset.MaxValue)))?
                .Cost ?? 0.0m;
        }
    }
}
