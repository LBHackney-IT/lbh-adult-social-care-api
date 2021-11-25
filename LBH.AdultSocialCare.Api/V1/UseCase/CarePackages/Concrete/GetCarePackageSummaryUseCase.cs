using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete
{
    public class GetCarePackageSummaryUseCase : IGetCarePackageSummaryUseCase
    {
        private readonly ICarePackageGateway _carePackageGateway;

        public GetCarePackageSummaryUseCase(ICarePackageGateway carePackageGateway)
        {
            _carePackageGateway = carePackageGateway;
        }

        public async Task<CarePackageSummaryDomain> ExecuteAsync(Guid packageId)
        {
            var package = await _carePackageGateway
                .GetPackageAsync(packageId, PackageFields.All)
                .EnsureExistsAsync($"Care package {packageId} not found");

            var coreCost = package.Details
                .FirstOrDefault(d => d.Type is PackageDetailType.CoreCost)
                .EnsureExists($"Core cost for package {packageId} not found");

            var additionalNeeds = package.Details
                .Where(d => d.Type == PackageDetailType.AdditionalNeed).ToList();

            NegateNetOffCosts(package);

            var summary = new CarePackageSummaryDomain
            {
                PackageType = package.PackageType.GetDisplayName(),
                Status = package.Status,
                PrimarySupportReason = package.PrimarySupportReason?.PrimarySupportReasonName,
                SchedulingPeriod = $"{package.PackageScheduling.GetDisplayName()} {package.PackageScheduling.ToDescription()}",

                StartDate = coreCost.StartDate,
                EndDate = coreCost.EndDate,
                CostOfPlacement = coreCost.Cost,

                Supplier = package.Supplier?.ToDomain(),
                ServiceUser = package.ServiceUser?.ToDomain(),
                Settings = package.Settings?.ToDomain(),

                AdditionalWeeklyNeeds = additionalNeeds.Where(d => d.CostPeriod is PaymentPeriod.Weekly).ToDomain(),
                AdditionalOneOffNeeds = additionalNeeds.Where(d => d.CostPeriod is PaymentPeriod.OneOff).ToDomain(),

                CareCharges = package.Reclaims.Where(r => r.Type is ReclaimType.CareCharge).ToDomain(),
                FundedNursingCare = package.Reclaims.FirstOrDefault(r => r.Type is ReclaimType.Fnc)?.ToDomain()
            };

            CalculateReclaimSubTotals(package, summary);
            CalculateTotals(summary, coreCost);

            return summary;
        }

        private static bool IsValidDateRange(DateTimeOffset startDate, DateTimeOffset? endDate)
        {
            var today = DateTimeOffset.Now.Date;
            switch (today >= startDate)
            {
                case true when (endDate == null || endDate.Value.Date >= today):
                    return true;
                default:
                    return false;
            }
        }

        private static void NegateNetOffCosts(CarePackage package)
        {
            foreach (var reclaim in package.Reclaims.Where(r => r.ClaimCollector is ClaimCollector.Supplier))
            {
                reclaim.Cost = decimal.Negate(reclaim.Cost);
            }
        }

        private static void CalculateReclaimSubTotals(CarePackage package, CarePackageSummaryDomain summary)
        {
            if (package.Reclaims.Any(r => r.ClaimCollector is ClaimCollector.Hackney))
            {
                summary.HackneyReclaims = new CarePackageSummaryReclaimsDomain();
            }

            if (package.Reclaims.Any(r => r.ClaimCollector is ClaimCollector.Supplier))
            {
                summary.SupplierReclaims = new CarePackageSummaryReclaimsDomain();
            }

            switch (summary.FundedNursingCare?.ClaimCollector)
            {
                case ClaimCollector.Hackney:
                    summary.HackneyReclaims.Fnc = summary.FundedNursingCare.Cost;
                    summary.HackneyReclaims.SubTotal += summary.FundedNursingCare.Cost;
                    break;

                case ClaimCollector.Supplier:
                    summary.SupplierReclaims.Fnc = summary.FundedNursingCare.Cost;
                    summary.SupplierReclaims.SubTotal += summary.FundedNursingCare.Cost;
                    break;
            }

            foreach (var reclaim in summary.CareCharges)
            {
                if (reclaim.Status == ReclaimStatus.Active && (DateTimeOffset.Now.Date >= reclaim.StartDate.Date) && (reclaim.EndDate == null || reclaim.EndDate.Value.Date >= DateTimeOffset.Now.Date))
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

        private static void CalculateTotals(CarePackageSummaryDomain summary, CarePackageDetail coreCost)
        {
            summary.AdditionalWeeklyCost = summary.AdditionalWeeklyNeeds.Where(d =>
                (DateTimeOffset.Now.Date > d.StartDate.Date) && (d.EndDate == null || d.EndDate.Value.Date >= DateTimeOffset.Now.Date)).Sum(d => d.Cost);
            summary.AdditionalOneOffCost = summary.AdditionalOneOffNeeds.Sum(d => d.Cost);

            if (IsValidDateRange(coreCost.StartDate, coreCost.EndDate))
            {
                summary.SubTotalCost = summary.CostOfPlacement + summary.AdditionalWeeklyCost;
            }
            else
            {
                summary.SubTotalCost = summary.AdditionalWeeklyCost;
            }

            if (summary.FundedNursingCare?.ClaimCollector is ClaimCollector.Supplier)
            {
                summary.FncPayment = summary.FundedNursingCare.Cost;
                summary.SubTotalCost += summary.FncPayment.Value;
            }

            summary.TotalWeeklyCost = summary.SubTotalCost;

            if (summary.SupplierReclaims != null)
            {
                // FNC is already included in SubTotalCost
                summary.TotalWeeklyCost += summary.SupplierReclaims.CareCharge;
            }
        }
    }
}
