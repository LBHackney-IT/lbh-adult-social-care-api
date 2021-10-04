using System;
using System.Linq;
using System.Threading.Tasks;
using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Concrete
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
                .GetPackageAsync(packageId)
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

                StartDate = coreCost.StartDate,
                EndDate = coreCost.EndDate,
                CostOfPlacement = coreCost.Cost,

                Supplier = package.Supplier.ToDomain(),
                ServiceUser = package.ServiceUser.ToDomain(),
                Settings = package.CarePackageSettings.ToDomain(),

                AdditionalWeeklyNeeds = additionalNeeds.Where(d => d.CostPeriod is PaymentPeriod.Weekly).ToDomain(),
                AdditionalOneOffNeeds = additionalNeeds.Where(d => d.CostPeriod is PaymentPeriod.OneOff).ToDomain(),

                FundedNursingCare = package.Reclaims.FirstOrDefault(r => r.Type is ReclaimType.Fnc)?.ToDomain(),
                CareCharges = package.Reclaims.FirstOrDefault(r => r.Type is ReclaimType.CareCharge)?.ToDomain()
            };

            FillSubTotalReclaimedByHackney(summary);
            FillSubTotalReclaimedBySupplier(summary);

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

        private static void FillSubTotalReclaimedByHackney(CarePackageSummaryDomain summary)
        {
            if (summary.FundedNursingCare?.ClaimCollector is ClaimCollector.Hackney)
            {
                summary.HackneyReclaims ??= new CarePackageSummaryReclaimsDomain();
                summary.HackneyReclaims.Fnc = summary.FundedNursingCare.Cost;
                summary.HackneyReclaims.SubTotal += summary.FundedNursingCare.Cost;
            }

            if (summary.CareCharges?.ClaimCollector is ClaimCollector.Hackney)
            {
                summary.HackneyReclaims ??= new CarePackageSummaryReclaimsDomain();
                summary.HackneyReclaims.CareCharge = summary.CareCharges.Cost;
                summary.HackneyReclaims.SubTotal += summary.CareCharges.Cost;
            }
        }

        private static void FillSubTotalReclaimedBySupplier(CarePackageSummaryDomain summary)
        {
            if (summary.FundedNursingCare?.ClaimCollector is ClaimCollector.Supplier)
            {
                summary.SupplierReclaims ??= new CarePackageSummaryReclaimsDomain();
                summary.SupplierReclaims.Fnc = summary.FundedNursingCare.Cost;
                summary.SupplierReclaims.SubTotal += summary.FundedNursingCare.Cost;
            }

            if (summary.CareCharges?.ClaimCollector is ClaimCollector.Supplier)
            {
                summary.SupplierReclaims ??= new CarePackageSummaryReclaimsDomain();
                summary.SupplierReclaims.CareCharge = summary.CareCharges.Cost;
                summary.SupplierReclaims.SubTotal += summary.CareCharges.Cost;
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
