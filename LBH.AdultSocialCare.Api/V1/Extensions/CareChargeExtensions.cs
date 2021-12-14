using Common.Exceptions.CustomExceptions;
using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace LBH.AdultSocialCare.Api.V1.Extensions
{
    public static class CareChargeExtensions
    {
        public static void CalculateTotals(CarePackageSummaryDomain summary, CarePackageDetail coreCost, DateTimeOffset currentDate)
        {
            summary.AdditionalWeeklyCost = summary.AdditionalWeeklyNeeds.Where(d => IsValidDateRange(currentDate, d.StartDate, d.EndDate))
                .Sum(d => d.Cost);
            summary.AdditionalOneOffCost = summary.AdditionalOneOffNeeds.Sum(d => d.Cost);

            summary.SubTotalCost = 0;

            if (IsValidDateRange(currentDate.Date, coreCost.StartDate, coreCost.EndDate))
            {
                summary.SubTotalCost = summary.CostOfPlacement + summary.AdditionalWeeklyCost;

                if (summary.FundedNursingCare is { ClaimCollector: ClaimCollector.Supplier })
                {
                    summary.FncPayment = summary.FundedNursingCare.Cost;
                }
            }

            summary.TotalWeeklyCost = summary.SubTotalCost;

            if (summary.SupplierReclaims != null)
            {
                // FNC is already included in SubTotalCost
                summary.TotalWeeklyCost += summary.SupplierReclaims.CareCharge;
                summary.TotalWeeklyCost += summary.SupplierReclaims.Fnc;
            }
        }

        public static bool IsValidDateRange(DateTimeOffset currentDate, DateTimeOffset startDate, DateTimeOffset? endDate)
        {
            var today = currentDate.Date;
            switch (today >= startDate.Date)
            {
                case true when (endDate == null || endDate.Value.Date >= today):
                    return true;

                default:
                    return false;
            }
        }

        public static void NegateNetOffCosts(CarePackage package)
        {
            foreach (var reclaim in package.Reclaims.Where(r => r.ClaimCollector is ClaimCollector.Supplier))
            {
                reclaim.Cost = decimal.Negate(reclaim.Cost);
            }
        }

        public static void RemoveNegativeCosts(CarePackage package)
        {
            foreach (var reclaim in package.Reclaims.Where(r => r.ClaimCollector is ClaimCollector.Supplier))
            {
                reclaim.Cost = decimal.Round(Math.Abs(reclaim.Cost), 2);
            }
        }

        public static void EnsureValidPackageTotals(CarePackage package)
        {
            var coreCost = package.Details
                .FirstOrDefault(d => d.Type is PackageDetailType.CoreCost)
                .EnsureExists($"Core cost for package {package.Id} not found");

            var additionalNeeds = package.Details
                .Where(d => d.Type == PackageDetailType.AdditionalNeed).ToList();

            CareChargeExtensions.NegateNetOffCosts(package);

            var summary = new CarePackageSummaryDomain
            {
                StartDate = coreCost.StartDate,
                EndDate = coreCost.EndDate,
                CostOfPlacement = coreCost.Cost,

                AdditionalWeeklyNeeds = additionalNeeds.Where(d => d.CostPeriod is PaymentPeriod.Weekly).ToDomain(),
                AdditionalOneOffNeeds = additionalNeeds.Where(d => d.CostPeriod is PaymentPeriod.OneOff).ToDomain(),

                CareCharges = package.Reclaims.Where(r => r.Type is ReclaimType.CareCharge).ToDomain(),
                FundedNursingCare = package.Reclaims.FirstOrDefault(r => r.Type is ReclaimType.Fnc)?.ToDomain()
            };

            var validReclaimStatuses = new[] { ReclaimStatus.Active, ReclaimStatus.Ended, ReclaimStatus.Pending };
            var startDates = new List<DateTimeOffset> { coreCost.StartDate };
            startDates.AddRange(summary.CareCharges.Where(cc => cc.Status.In(validReclaimStatuses)).Select(careCharge => careCharge.StartDate).ToList());
            startDates = startDates.Distinct().ToList();

            foreach (var startDate in startDates)
            {
                CareChargeExtensions.CalculateReclaimSubTotals(package, summary, coreCost, startDate.Date, validReclaimStatuses);
                CareChargeExtensions.CalculateTotals(summary, coreCost, startDate.Date);

                var reclaimsTotal = Math.Abs(summary.SupplierReclaims?.SubTotal ?? 0) + Math.Abs(summary.HackneyReclaims?.SubTotal ?? 0);
                var packageSubTotal = summary.SubTotalCost;

                if (reclaimsTotal > packageSubTotal)
                {
                    throw new ApiException(
                        $"Not allowed. Reclaim total {decimal.Round(reclaimsTotal, 2)} at date {startDate.Date: yyyy-MM-dd} is greater that package cost of {decimal.Round(packageSubTotal, 2)}",
                        HttpStatusCode.BadRequest);
                }
            }

            CareChargeExtensions.RemoveNegativeCosts(package);
        }

        public static void CalculateReclaimSubTotals(CarePackage package, CarePackageSummaryDomain summary, CarePackageDetail coreCost, DateTimeOffset currentDate, ReclaimStatus[] validReclaimStatuses)
        {
            if (package.Reclaims.Any(r => r.ClaimCollector is ClaimCollector.Hackney))
            {
                summary.HackneyReclaims = new CarePackageSummaryReclaimsDomain();
            }

            if (package.Reclaims.Any(r => r.ClaimCollector is ClaimCollector.Supplier))
            {
                summary.SupplierReclaims = new CarePackageSummaryReclaimsDomain();
            }

            if (summary.FundedNursingCare != null)
            {
                switch (summary.FundedNursingCare.ClaimCollector)
                {
                    case ClaimCollector.Hackney:
                        summary.HackneyReclaims.Fnc = summary.FundedNursingCare.Cost;
                        if (currentDate.Date >= coreCost.StartDate)
                        {
                            summary.HackneyReclaims.SubTotal += summary.FundedNursingCare.Cost;
                        }
                        break;

                    case ClaimCollector.Supplier:
                        summary.SupplierReclaims.Fnc = summary.FundedNursingCare.Cost;
                        if (currentDate.Date >= coreCost.StartDate)
                        {
                            summary.SupplierReclaims.SubTotal += summary.FundedNursingCare.Cost;
                        }
                        break;
                }
            }

            foreach (var reclaim in summary.CareCharges)
            {
                if (reclaim.Status.In(validReclaimStatuses) && IsValidDateRange(currentDate, reclaim.StartDate, reclaim.EndDate))
                {
                    switch (reclaim.ClaimCollector)
                    {
                        case ClaimCollector.Hackney:
                            summary.HackneyReclaims.CareCharge += reclaim.Cost;
                            summary.HackneyReclaims.SubTotal += reclaim.Cost;
                            break;

                        case ClaimCollector.Supplier:
                            summary.SupplierReclaims.CareCharge += reclaim.Cost;
                            summary.SupplierReclaims.SubTotal += reclaim.Cost;
                            break;
                    }
                }
            }
        }
    }
}
