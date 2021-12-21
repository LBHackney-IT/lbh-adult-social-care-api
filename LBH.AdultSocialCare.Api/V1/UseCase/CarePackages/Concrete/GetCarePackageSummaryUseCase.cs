using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces;
using LBH.AdultSocialCare.Data.Constants.Enums;
using System;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.Core;
using LBH.AdultSocialCare.Data.Entities.CarePackages;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete
{
    public class GetCarePackageSummaryUseCase : IGetCarePackageSummaryUseCase
    {
        private readonly ICarePackageGateway _carePackageGateway;

        private CarePackage _package;
        private CarePackageSummaryDomain _summary;

        public GetCarePackageSummaryUseCase(ICarePackageGateway carePackageGateway)
        {
            _carePackageGateway = carePackageGateway;
        }

        public async Task<CarePackageSummaryDomain> ExecuteAsync(Guid packageId)
        {
            _package = await _carePackageGateway
                .GetPackageAsync(packageId, PackageFields.All)
                .EnsureExistsAsync($"Care package {packageId} not found");

            var coreCost = _package.Details
                .FirstOrDefault(d => d.Type is PackageDetailType.CoreCost)
                .EnsureExists($"Core cost for package {packageId} not found");

            var additionalNeeds = _package.Details
                .Where(d => d.Type == PackageDetailType.AdditionalNeed).ToList();

            _summary = new CarePackageSummaryDomain
            {
                PackageType = _package.PackageType.GetDisplayName(),
                Status = _package.Status,
                PrimarySupportReason = _package.PrimarySupportReason?.PrimarySupportReasonName,
                SchedulingPeriod = $"{_package.PackageScheduling.GetDisplayName()} {_package.PackageScheduling.ToDescription()}",

                StartDate = coreCost.StartDate,
                EndDate = coreCost.EndDate,
                CostOfPlacement = coreCost.Cost,

                Supplier = _package.Supplier?.ToDomain(),
                ServiceUser = _package.ServiceUser?.ToDomain(),
                Settings = _package.Settings?.ToDomain(),

                AdditionalWeeklyNeeds = additionalNeeds.Where(d => d.CostPeriod is PaymentPeriod.Weekly).ToDomain(),
                AdditionalOneOffNeeds = additionalNeeds.Where(d => d.CostPeriod is PaymentPeriod.OneOff).ToDomain(),

                CareCharges = _package.Reclaims.Where(r =>
                    r.Type is ReclaimType.CareCharge &&
                    r.Status != ReclaimStatus.Cancelled).ToDomain()
            };

            FillFundedNursingCare();
            FillReclaimsSubTotals();

            _summary.TotalCostOfPlacement = _summary.CostOfPlacement + _summary.FncPayment;
            _summary.AdditionalWeeklyCost = _package.GetAdditionalWeeklyCost();
            _summary.OneOffCost = _package.GetAdditionalOneOffCost();

            _summary.TotalWeeklyCost =
                _summary.TotalCostOfPlacement
                + _summary.AdditionalWeeklyCost
                - (_summary.SupplierReclaims?.SubTotal ?? 0.0m);

            // intentionally separated from calculations to stress that this for display purposes only
            NegateReclaimTotals(_summary.HackneyReclaims, _summary.SupplierReclaims);

            return _summary;
        }

        private void FillFundedNursingCare()
        {
            _summary.FundedNursingCare = _package.Reclaims
                .FirstOrDefault(r =>
                    r.Status != ReclaimStatus.Cancelled &&
                    r.Type is ReclaimType.Fnc &&
                    r.SubType is ReclaimSubType.FncPayment)?
                .ToDomain();

            _summary.FncPayment = _summary.FundedNursingCare?.Cost ?? 0.0m;

            var fncResource = _package.Resources?
                .OrderByDescending(r => r.DateCreated)
                .FirstOrDefault(r => r.Type is PackageResourceType.FncAssessmentFile);

            if (_summary.FundedNursingCare != null)
            {
                _summary.FundedNursingCare.AssessmentFileId = fncResource?.FileId;
                _summary.FundedNursingCare.AssessmentFileName = fncResource?.Name;
            }
        }

        private void FillReclaimsSubTotals()
        {
            var reclaims = _package.Reclaims
                .Where(r => r.Status != ReclaimStatus.Cancelled)
                .ToList();

            if (reclaims.Any(r => r.ClaimCollector is ClaimCollector.Hackney))
            {
                _summary.HackneyReclaims = new CarePackageSummaryReclaimsDomain();
                FillReclaimsForCollector(_summary.HackneyReclaims, ClaimCollector.Hackney);
            }

            if (reclaims.Any(r => r.ClaimCollector is ClaimCollector.Supplier))
            {
                _summary.SupplierReclaims = new CarePackageSummaryReclaimsDomain();
                FillReclaimsForCollector(_summary.SupplierReclaims, ClaimCollector.Supplier);
            }
        }

        private void FillReclaimsForCollector(CarePackageSummaryReclaimsDomain reclaimTotals, ClaimCollector collector)
        {
            if (_summary.FundedNursingCare != null)
            {
                reclaimTotals.Fnc = _summary.FundedNursingCare.ClaimCollector == collector
                    ? _summary.FundedNursingCare.Cost
                    : 0.0m;
            }

            reclaimTotals.CareCharge = _package.GetCareChargesCost(collector);
            reclaimTotals.SubTotal = reclaimTotals.Fnc + reclaimTotals.CareCharge;
        }

        private static void NegateReclaimTotals(params CarePackageSummaryReclaimsDomain[] reclaimTotals)
        {
            foreach (var reclaimTotal in reclaimTotals)
            {
                if (reclaimTotal is null) continue;

                reclaimTotal.Fnc = Decimal.Negate(reclaimTotal.Fnc);
                reclaimTotal.CareCharge = Decimal.Negate(reclaimTotal.CareCharge);
                reclaimTotal.SubTotal = Decimal.Negate(reclaimTotal.SubTotal);
            }
        }
    }
}
