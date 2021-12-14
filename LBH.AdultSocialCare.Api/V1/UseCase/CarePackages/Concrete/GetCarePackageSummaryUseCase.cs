using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Extensions;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces;
using LBH.AdultSocialCare.Data.Constants.Enums;
using System;
using System.Linq;
using System.Threading.Tasks;

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

            CareChargeExtensions.NegateNetOffCosts(package);

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

            var fncResource = package.Resources?.OrderByDescending(r => r.DateCreated)
                .FirstOrDefault(r => r.Type == PackageResourceType.FncAssessmentFile);

            if (summary.FundedNursingCare != null)
            {
                summary.FundedNursingCare.AssessmentFileId = fncResource?.FileId;
                summary.FundedNursingCare.AssessmentFileName = fncResource?.Name;
            }

            var currentDate = DateTimeOffset.Now.Date;
            var validReclaimStatuses = new[] { ReclaimStatus.Active };

            CareChargeExtensions.CalculateReclaimSubTotals(package, summary, coreCost, currentDate, validReclaimStatuses);
            CareChargeExtensions.CalculateTotals(summary, coreCost, currentDate);

            return summary;
        }
    }
}
