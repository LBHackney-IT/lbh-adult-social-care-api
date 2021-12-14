using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using System;
using System.Linq;
using Common.Extensions;

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

            if (IsValidDateRange(currentDate, coreCost.StartDate, coreCost.EndDate))
            {
                summary.SubTotalCost = summary.CostOfPlacement + summary.AdditionalWeeklyCost;

                if (summary.FundedNursingCare is { ClaimCollector: ClaimCollector.Supplier })
                {
                    summary.FncPayment = summary.FundedNursingCare.Cost;
                    summary.SubTotalCost += summary.FncPayment.Value;
                }
            }

            summary.TotalWeeklyCost = summary.SubTotalCost;

            if (summary.SupplierReclaims != null)
            {
                // FNC is already included in SubTotalCost
                summary.TotalWeeklyCost += summary.SupplierReclaims.CareCharge;
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
