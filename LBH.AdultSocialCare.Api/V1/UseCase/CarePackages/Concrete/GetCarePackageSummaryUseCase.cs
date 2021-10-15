using System;
using System.Linq;
using System.Threading.Tasks;
using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CarePackages;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;

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
            CalculateTotals(summary);

            return summary;
        }

        private static void NegateNetOffCosts(CarePackage package)
        {
            foreach (var reclaim in package.Reclaims.Where(r => r.ClaimCollector is ClaimCollector.Supplier))
            {
                reclaim.Cost = Decimal.Negate(reclaim.Cost);
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

        private static void CalculateTotals(CarePackageSummaryDomain summary)
        {
            summary.AdditionalWeeklyCost = summary.AdditionalWeeklyNeeds.Sum(d => d.Cost);
            summary.AdditionalOneOffCost = summary.AdditionalOneOffNeeds.Sum(d => d.Cost);

            summary.SubTotalCost = summary.CostOfPlacement + summary.AdditionalWeeklyCost;

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
