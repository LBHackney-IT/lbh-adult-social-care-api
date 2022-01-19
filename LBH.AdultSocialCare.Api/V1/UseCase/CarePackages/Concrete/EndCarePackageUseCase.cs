using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.Core;
using LBH.AdultSocialCare.Data.Constants.Enums;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete
{
    public class EndCarePackageUseCase : IEndCarePackageUseCase
    {
        private readonly ICarePackageGateway _carePackageGateway;
        private readonly IDatabaseManager _dbManager;

        public EndCarePackageUseCase(ICarePackageGateway carePackageGateway, IDatabaseManager dbManager)
        {
            _carePackageGateway = carePackageGateway;
            _dbManager = dbManager;
        }

        public async Task ExecuteAsync(Guid packageId, DateTimeOffset endDate, string notes)
        {
            var package = await _carePackageGateway
                .GetPackageAsync(packageId, PackageFields.Reclaims | PackageFields.Details, true)
                .EnsureExistsAsync($"Care package {packageId} not found");

            var coreCost = package.Details.FirstOrDefault(d => d.Type == PackageDetailType.CoreCost);
            if (coreCost == null)
            {
                // End package, set history and return
                package.Status = PackageStatus.Ended;
                package.AddHistoryEntry(
                    $"{HistoryStatus.BrokeredEnded.GetDisplayName()}: {endDate:yyyy-MM-dd}",
                    HistoryStatus.BrokeredEnded, notes);

                await _dbManager.SaveAsync();
                return;
            }

            // Validate - Select end date not before start date
            if (endDate < coreCost.StartDate)
            {
                throw new ApiException(
                    $"Package end date cannot be before start date of {coreCost.StartDate:yyyy-MM-dd}", HttpStatusCode.BadRequest);
            }

            var today = DateTimeOffset.UtcNow.Date;

            // Update package detail end dates
            foreach (var detail in package.Details)
            {
                if (detail.EndDate == null || detail.EndDate.Value > endDate)
                {
                    detail.EndDate = endDate;

                    if (detail.Type is PackageDetailType.AdditionalNeed) // core cost represents package itself
                    {
                        package.AddHistoryEntry(
                            $"Additional Need {detail.StartDate:yyyy-MM-dd} - {detail.EndDate:yyyy-MM-dd} ended");
                    }
                }
            }

            if (endDate < today)
            {
                // Mark package as ended
                package.Status = PackageStatus.Ended;

                // End active package reclaims
                var reclaims = package.Reclaims.Where(r => r.Status.In(ReclaimStatus.Active, ReclaimStatus.Pending));

                foreach (var reclaim in reclaims)
                {
                    // If reclaim in future, cancel
                    if (reclaim.StartDate >= endDate)
                    {
                        reclaim.Status = ReclaimStatus.Cancelled;
                        package.AddHistoryEntry($"{reclaim.SubType.GetDisplayName()} cancelled");
                    }
                    else
                    {
                        reclaim.Status = ReclaimStatus.Ended;
                        reclaim.EndDate = endDate;
                        package.AddHistoryEntry($"{reclaim.SubType.GetDisplayName()} ended");
                    }
                }
            }

            package.AddHistoryEntry(
                $"{HistoryStatus.BrokeredEnded.GetDisplayName()}: {endDate:yyyy-MM-dd}",
                HistoryStatus.BrokeredEnded, notes);

            await _dbManager.SaveAsync();
        }
    }
}
